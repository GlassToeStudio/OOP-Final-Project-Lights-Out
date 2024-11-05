using Newtonsoft.Json;

namespace LightsOut
{
    partial class Board
    {
		private void Light_Click(object sender, EventArgs e)
		{
            Light? light = sender as Light;
			OnCLickLight(light);
			CheckWin();
		}

		private void LoadLevel_Click(object sender, EventArgs e)
		{
			GenerateLevelFromFile();
            UpdateUI();
            EnableLights();
        }
#if DEBUG

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
            EnableLights();
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
#endif
    }
}
