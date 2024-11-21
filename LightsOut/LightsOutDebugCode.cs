namespace LightsOut
{
    partial class Board
    {
#if DEBUG
        /// <summary>
        /// String representing the intital data in the user database.
        /// </summary>
        public const string USER_DATA_BACKUP = @"{ ""Levels"": [ { ""Level"": 1, ""Size"": 3, ""MinMoves"": 2, ""BestScore"": 9000, ""Stars"": 0, ""Board"": [ 0, 1, 0, 0, 1, 0, 0, 0, 1 ], ""Name"": ""Level 1"", ""StarText"": ""☆☆☆"" } ], ""SelectedIndex"": 0, ""MaxIndex"": 0, ""CurrentLevel"": { ""Level"": 1, ""Size"": 3, ""MinMoves"": 2, ""BestScore"": 9000, ""Stars"": 0, ""Board"": [ 0, 1, 0, 0, 1, 0, 0, 0, 1 ], ""Name"": ""Level 1"", ""StarText"": ""☆☆☆"" } }";

        #region Generation
        private void GenerateRandomLevel()
        {
            moves = 0;
            int size = GetBoardSizeForRandomGen();
            GenerateGameBoardsAndSelect();
            Random rnd = new();
            int minMoves = -1;

            // numMinMoves is a NumericUpDown control where we have seleected a desired
            // value for minimum moves. Loop until we have a solution that equals our
            // desired value.
            while (minMoves != numMinMoves.Value)
            {
                foreach (var light in lights)
                {
                    light.TurnOff();
                }

                List<int> used = [];
                int iterations = rnd.Next(size * size + 1);
                for (int i = 0; i < iterations; i++)
                {
                    int randLight = rnd.Next(0, size * size);

                    // We do this so that we can only ever touch each light once.
                    while (used.Contains(randLight))
                    {
                        randLight = rnd.Next(0, size * size);
                    }
                    used.Add(randLight);

                    lights[randLight].ClickLight();

                }

                levelData = new LevelData(handler.Levels.Count, size, 0);
                levelData.UpdateBoard(lights);
                levelData.MinMoves = Solver.GetSolutionMatrix(levelData).Sum();
                lblLog.Text = DebugBoardState();

                // If we did not select a value for min moves, take the current solution.
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
                    this.Width = this.Width switch
                    {
                        675 => 510,
                        510 => 675,
                        _ => 510,
                    };
                    break;
                default:
                    break;
            }
        }

        private void SaveLevelToFile_Click(object sender, EventArgs e)
        {
            cbxLevelSelect.Items.Add(levelData.Name);
            handler.Levels.Add(levelData);
            cbxLevelSelect.SelectedIndex = cbxLevelSelect.Items.Count - 1;

            handler.SaveGameData();
            string fileName = $"{levelData}_generated";
            MessageBox.Show($"{fileName} created!", "Level Saved");
            btnSaveLevel.Enabled = false;
        }

        #endregion

        #region DebugPanel
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
        #endregion
#endif
    }
}
