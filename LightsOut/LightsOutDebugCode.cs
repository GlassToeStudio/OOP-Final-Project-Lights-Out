using Newtonsoft.Json;
using System.ComponentModel;

namespace LightsOut
{
    partial class Board
    {
        #region Generation
        private void GenerateRandomLevel()
        {
            moves = 0;
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

                }
                levelData = new LevelData(rnd.Next(1000,9000), levelData.Size, 0);
                levelData.UpdateBoard(lights);
                levelData.MinMoves = Solver.GetSolutionMatrix(levelData).Sum();
                lblLog.Text = DebugBoardState();

                if (numMinMoves.Value == 0)
                {
                    break;
                }
            }

            btnSaveLevel.Enabled = true;
           
            txtFileName.Text = $"{levelData}_generated";
        }

        private int GetBoardSizeForRandomGen()
        {
            if (rb3x3.Checked)
            {
                return 3;
            }
            else if (rb4x4.Checked)
            {
                return 4;
            }
            else if (rb5x5.Checked)
            {
                return 5;
            }
            return 4;
        }
        #endregion

        #region Solver
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

        #endregion

        #region Buttons
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
                    if (this.Width == 675)
                    {
                        this.Width = 510;
                    }
                    else
                    {
                        this.Width = 675;
                    }

                    break;
                default:
                    break;
            }
        }

        private void SaveLevelToFile_Click(object sender, EventArgs e)
        {
            //string ProjectDir = "C:\\Users\\GlassToe\\Documents\\Calhoun Comminity College\\Fall 24\\CIS 285 - Object-Oriented Programming (11022)\\Final Project\\OOP-Final-Project-Lights-Out\\LightsOut\\Resources\\Levels\\";
           
            //cbxLevelSelect.Items.Add(levelData.Name);
            //LevelDatabase.Levels.Add(levelData);
            //cbxLevelSelect.SelectedIndex = cbxLevelSelect.Items.Count - 1;

            //string fileName = $"{levelData}_generated";
            //var data = JsonConvert.SerializeObject(LevelDatabase);
            //File.WriteAllText(FileUtil.GetLevelDatabase("Levels.json"), data);
            //File.WriteAllText($"{ProjectDir}Levels.json", data);
            //MessageBox.Show($"{fileName} created!", "Level Saved");
            //btnSaveLevel.Enabled = false;
        }

        #endregion

        private string DebugBoardState()
        {
            string onglyph = "⦿";
            string offglyph = "○";

            string output = "";

            for (int i = 0; i < levelData.Board.Length; i++)
            {
                if (i % levelData.Size == 0 && i != 0)
                {
                    output += "\n";
                } 
                output += $"{(levelData.Board[i] == 0 ? offglyph : onglyph)} ";
            }

            return output;
        }
    }
}
