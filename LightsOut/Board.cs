using Newtonsoft.Json;

namespace LightsOut
{
    public partial class frmLightsOut : Form
    {
        private readonly Image? OnButton = Properties.Resources.ButtonOn;
        private readonly Image? OffButton = Properties.Resources.ButtonOff;

        private Light[] lights = new Light[16];
        private LevelData levelData;
        private int moves = 0;
        private int level = 1;
        private string levelName = "Levels_1.json";
        bool debug = false;

        public frmLightsOut()
        {
            InitializeComponent();
            this.Width = 500;
            GenerateGameBoard();

            LoadLevels();
            GenerateLevelFromFile();
        }

        private void LoadLevels()
        {
            cbxLevelSelect.Items.Clear();
            string[] files = FileUtil.GetFiles();
            foreach (string file in files)
            {
                cbxLevelSelect.Items.Add(Path.GetFileName(file));
            }
            cbxLevelSelect.SelectedIndex = 0;
        }

        private void GenerateLevelFromFile()
        {
            moves = 0;
            levelName = cbxLevelSelect.Text;
            levelData = new LevelData().LoadLevelDataFromJson(levelName);
            level = levelData.Level;

            for (var i = 0; i < levelData.Board.Length; i++)
            {
                if (levelData.Board[i] == 0)
                {
                    lights[i].TurnOff();
                }
                else
                {
                    lights[i].TurnOn();
                }
            }
#if DEBUG
            lblLog.Text = DebugBoardState();
#endif
            UpdateUI();
            EnableLights();
        }

        private void GenerateRandomLevel()
        {
            moves = 0;
            level += 1;
            int size = 4;
            Random rnd = new Random();
            List<int> used = new List<int>();
            int numMoves = rnd.Next(4, size * size + 1); // Can adjust difficulty
            for (int i = 0; i < numMoves; i++)
            {
                int randLight = rnd.Next(0, size * size);
                // We do this so that we can only ever touch each light once.
                while (used.Contains(randLight))
                {
                    randLight = rnd.Next(0, size * size);
                }
                used.Add(randLight);

                lights[randLight].ClickLight();

#if DEBUG
                lblLog.Text = DebugBoardState();
#endif
            }

            levelData.UpdateBoard(lights);
            levelData.Level = level;
            levelData.Size = size;
            levelData.MinMoves = Solver.GetSolutionMatrix(levelData).Sum();

            UpdateUI();
            EnableLights();
        }

        private void UpdateUI()
        {
            gbxStats.Text = $"Level {levelData.Level}";
            lblSize.Text = $"{levelData.Size} x {levelData.Size}";
            lblGoal.Text = $"{levelData.MinMoves}";
            lblMoves.Text = moves.ToString();
        }

        private void UpdateMoves()
        {
            moves += 1;
            lblMoves.Text = moves.ToString();
#if DEBUG
            lblLog.Text = DebugBoardState();
#endif
        }

        private void CheckWin()
        {
            foreach (var light in lights)
            {
                if (light.State == LightState.On)
                {
                    return;
                }
            }

            DisableLights();
        }

        private void DisableLights()
        {
            pictureBox1.BringToFront();
            pictureBox1.Visible = true;
            foreach (var light in lights)
            {
                light.Enabled = false;
            }
        }

        private void EnableLights()
        {
            pictureBox1.Visible = false;
            foreach (var light in lights)
            {
                light.Enabled = true;
            }
        }

        private void SolveOne()
        {
            var solution = Solver.GetSolutionMatrix(levelData);
            for (int i = 0; i < lights.Length; i++)
            {
                if (solution[i] == 1)
                {
                    lights[i].ClickLight();

                    levelData.UpdateBoard(lights);
                    UpdateMoves();
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
                    lights[i].ClickLight();

                    levelData.UpdateBoard(lights);
                    UpdateMoves();
                    await Task.Delay(500);
                }
            }
            CheckWin();
        }
#if DEBUG
        private string DebugBoardState()
        {
            String output = "";
            for (int i = 0; i < levelData.Board.Length; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    output += "\n";
                }
                output += levelData.Board[i] + ", ";
            }

            return output;
        }

        private void btnSaveLevel_Click(object sender, EventArgs e)
        {
            levelData = new LevelData(levelData);
            var solution = Solver.GetSolutionMatrix(levelData);
            levelData.MinMoves = solution.Sum();
            string ProjectDir = "C:\\Users\\GlassToe\\Documents\\Calhoun Comminity College\\Fall 24\\CIS 285 - Object-Oriented Programming (11022)\\Final Project\\OOP-Final-Project-Lights-Out\\LightsOut\\Resources\\Levels\\";
            var data = JsonConvert.SerializeObject(levelData);
            File.WriteAllText(FileUtil.GetFile($"Levels_{level}.json"), data);
            File.WriteAllText($"{ProjectDir}Levels_{level}.json", data);
            LoadLevels();
            MessageBox.Show(Directory.GetCurrentDirectory());
        }
#endif
    }
}