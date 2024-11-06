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
            txtFileName.Text = $"Levels_{level}";
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
                        this.Width = 500;
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
            LevelData ld = new LevelData(levelData);
            var solution = Solver.GetSolutionMatrix(ld);
            ld.MinMoves = solution.Sum();
            string ProjectDir = "C:\\Users\\GlassToe\\Documents\\Calhoun Comminity College\\Fall 24\\CIS 285 - Object-Oriented Programming (11022)\\Final Project\\OOP-Final-Project-Lights-Out\\LightsOut\\Resources\\Levels\\";
            string fileName = $"Levels_{level}.json";
            if(cbxLevelSelect.Items.Contains(fileName))
            {
                MessageBox.Show($"{fileName} Exists, choose a new name!", "File Exists!");
                return;
            }


            var data = JsonConvert.SerializeObject(ld);
            File.WriteAllText(FileUtil.GetLevelFile(fileName), data);
            File.WriteAllText($"{ProjectDir}{fileName}", data);
            levelData = ld;
            MessageBox.Show($"{fileName} created!", "Level Saved");
            PreloadLevelsData();
        }

        #endregion

        #region Validation
        private void txtFileName_Leave(object sender, EventArgs e)
        {
            txtFileName_Validating(this, new CancelEventArgs());
        }

        private void txtFileName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                level = int.Parse(txtFileName.Text.Split("_")[1]);
                string fileName = $"{txtFileName.Text}.json";
                if (cbxLevelSelect.Items.Contains(fileName))
                {
                    MessageBox.Show($"{fileName} Exists, choose a new name!", "File Exists!");
                    return;
                }
            }
            catch
            {
                e.Cancel = true;
                level = int.Parse((cbxLevelSelect.Text.Split("_")[1]).Replace
                    (".json", ""));
                txtFileName.Text = $"Levels_{level}";
            }
        }

        #endregion
       
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
    }
}
