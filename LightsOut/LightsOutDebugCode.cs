using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut
{
    partial class Board
    {
        private void GenerateRandomLevel()
        {
            moves = 0;
            level += 1;
            levelData.Size = GetBoardSizeForRandomGen();
            GenerateGameBoardsAndSelect();
            Random rnd = new Random();
            levelData.MinMoves = -1;

            while (levelData.MinMoves != numMinMoves.Value)
            {
                foreach (var light in lights)
                {
                    light.TurnOff();
                }
                List<int> used = new List<int>();
                int iterations = rnd.Next(levelData.Size * levelData.Size + 1);
                for (int i = 0; i < iterations; i++)
                {
                    int randLight = rnd.Next(0, levelData.Size * levelData.Size);
                    // We do this so that we can only ever touch each light once.
                    while (used.Contains(randLight))
                    {
                        randLight = rnd.Next(0, levelData.Size * levelData.Size);
                    }
                    used.Add(randLight);

                    lights[randLight].ClickLight();
                    //levelData.UpdateBoard(lights);

                }
                levelData = new LevelData(level, levelData.Size, 0);
                levelData.UpdateBoard(lights);
                levelData.MinMoves = Solver.GetSolutionMatrix(levelData).Sum();
                lblLog.Text = DebugBoardState();

                if (numMinMoves.Value == 0)
                {
                    break;
                }
            }
        }


        private void SolveOne()
        {
            var solution = Solver.GetSolutionMatrix(levelData);
            for (int i = 0; i < lights.Length; i++)
            {
                if (solution[i] == 1)
                {
                    OnCLickLight(lights[i]);
                    CheckWin();
                    return;
                }
            }
        }


        private async void SolvePuzzle()
        {
            var solution = Solver.GetSolutionMatrix(levelData);
            for (int i = 0; i < lights.Length; i++)
            {
                if (solution[i] == 1)
                {
                    OnCLickLight(lights[i]);
                    await Task.Delay(500);
                }
            }
            CheckWin();
        }


        private string DebugBoardState()
        {
            String output = "";
            if (levelData.Size == 4)
            {
                for (int i = 0; i < levelData.Board.Length; i++)
                {
                    if (i % 4 == 0 && i != 0)
                    {
                        output += "\n";
                    }
                    output += levelData.Board[i] + ", ";
                }
            }
            else
            {
                for (int i = 0; i < levelData.Board.Length; i++)
                {
                    if (i % 3 == 0 && i != 0)
                    {
                        output += "\n";
                    }
                    output += levelData.Board[i] + ", ";
                }
            }

            return output;
        }





        private void SolveAll_Click(object sender, EventArgs e)
        {
            SolvePuzzle();
        }

        private void SolveOne_Click(object sender, EventArgs e)
        {
            SolveOne();
        }

        private void GenerateRandom_Click(object sender, EventArgs e)
        {
            GenerateRandomLevel();
            UpdateUI();
        }

        private void ShowHideDebug_Click(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "d":
                case "D":
                    if (debug)
                    {
                        debug = false;
                        this.Width = 500;
                    }
                    else
                    {
                        debug = true;
                        this.Width = 675;
                    }

                    break;
                default:
                    break;
            }
        }

        private void SaveLevelToFile_Click(object sender, EventArgs e)
        {
            levelData = new LevelData(levelData);
            var solution = Solver.GetSolutionMatrix(levelData);
            levelData.MinMoves = solution.Sum();
            string ProjectDir = "C:\\Users\\GlassToe\\Documents\\Calhoun Comminity College\\Fall 24\\CIS 285 - Object-Oriented Programming (11022)\\Final Project\\OOP-Final-Project-Lights-Out\\LightsOut\\Resources\\Levels\\";
            var data = JsonConvert.SerializeObject(levelData);
            File.WriteAllText(FileUtil.GetLevelFile($"Levels_{level}.json"), data);
            File.WriteAllText($"{ProjectDir}Levels_{level}.json", data);
            PreloadLevelsData();
        }
    }
}
