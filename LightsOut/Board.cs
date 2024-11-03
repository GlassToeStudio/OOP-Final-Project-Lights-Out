namespace LightsOut
{
    public partial class frmLightsOut : Form
    {
        private readonly Image? OnButton = Properties.Resources.ButtonOn3;
        private readonly Image? OffButton = Properties.Resources.ButtonOff3;

        private readonly Light[] lights;
        private LevelData levelData;
        private int moves = 0;
        private int level = 1;
        private string levelName = "Levels_1.json";

        public frmLightsOut()
        {
            InitializeComponent();
            LoadLevelFilesIntoComboBox();

            lights = [light_00, light_01, light_02, light_03,
                      light_10, light_11, light_12, light_13,
                      light_20, light_21, light_22, light_23,
                      light_30, light_31, light_32, light_33];

            ConnectLightNeighbors();
            LoadLevelFromFile();
            UpdateUI();
        }

        private void SetInitialState()
        {
            for (var i = 0; i < levelData.Board.Length; i++)
            {
                lights[i].SetButtons(OnButton, OffButton);
                lights[i].index = i;

                if (levelData.Board[i] == 0)
                {
                    lights[i].TurnOff();
                }
                else
                {
                    lights[i].TurnOn();
                }
            }
        }

        private void ConnectLightNeighbors()
        {
            var size = 4 * 4;

            for (int pos = 0; pos < size; pos++)
            {
                var n1 = pos - 4;
                var n2 = pos + 4;

                var n3 = pos - 1;
                var n4 = pos + 1;

                if (n1 >= 0)
                {
                    lights[pos].AddNeighbor(lights[n1]);
                }

                if (n2 < size)
                {
                    lights[pos].AddNeighbor(lights[n2]);
                }

                if (pos % 4 != 0)
                {
                    lights[pos].AddNeighbor(lights[n3]);
                }

                if (n4 % 4 != 0)
                {
                    lights[pos].AddNeighbor(lights[n4]);
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
                    lights[i].ClickLight();
                    UpdateLevelDataBoardState();
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
                    UpdateLevelDataBoardState();
                    UpdateMoves();
                    await Task.Delay(500);
                }
            }
            CheckWin();
        }

        private void LoadLevelFromFile()
        {
            moves = 0;
            levelName = cbxLevelSelect.Text;
            levelData = new LevelData().LoadLevelDataFromJson(levelName);
            level = levelData.Level;

            SetInitialState();
            UpdateLevelDataBoardState();
            UpdateUI();

            pictureBox1.Visible = false;
            foreach (var light in lights)
            {
                light.Enabled = true;
            }
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

                lblLog.Text = DebugBoardState();
            }


            UpdateLevelDataBoardState();
            levelData.Level = level;
            levelData.Size = size;
            levelData.MinMoves = Solver.GetSolutionMatrix(levelData).Sum();
            UpdateUI();
            pictureBox1.Visible = false;
            foreach (var light in lights)
            {
                light.Enabled = true;
            }
        }

        private void UpdateLevelDataBoardState()
        {
            foreach (var light in lights)
            {
                levelData.Board[light.index] = (int)light.State;
            }
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
            lblLog.Text = DebugBoardState();
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
            lblLog.Text = "You Win!\nPlay Again?";
            pictureBox1.Visible = true;

            foreach (var light in lights)
            {
                light.Enabled = false;
            }
        }
    
        private void btnLight_Click(object sender, EventArgs e)
        {
            Light? light = sender as Light;
            light.ClickLight();
            UpdateLevelDataBoardState();
            UpdateMoves();
            CheckWin();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            SolvePuzzle();
        }

        private void btnSolveOne_Click(object sender, EventArgs e)
        {
            SolveOne();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateRandomLevel();
            lblLog.Text = DebugBoardState();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadLevelFromFile();       
        }

        private void LoadLevelFilesIntoComboBox()
        {
            string[] files = FileUtil.GetFiles();
            foreach (string file in files)
            {
                cbxLevelSelect.Items.Add(Path.GetFileName(file));
            }
            cbxLevelSelect.SelectedIndex = 0;
        }

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
    }
}