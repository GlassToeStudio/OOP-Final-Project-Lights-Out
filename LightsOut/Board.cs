namespace LightsOut
{
    public partial class frmLightsOut : Form
    {
        private readonly Image? OnButton = Properties.Resources.ButtonOn3;
        private readonly Image? OffButton = Properties.Resources.ButtonOff3;

        private readonly Light[] lights;
        private LevelData levelData;
        private int moves = 0;
        int level = 1;

        public frmLightsOut()
        {
            InitializeComponent();
            levelData = new LevelData().LoadLevelDataFromJson("Levels_22.json");

            lights = [light_00, light_01, light_02, light_03,
                      light_10, light_11, light_12, light_13,
                      light_20, light_21, light_22, light_23,
                      light_30, light_31, light_32, light_33];


            SetInitialState();
            ConnectGemNeighbors();
            GenerateRandomLevel();

        }

        private void SetInitialState()
        {
            moves = 0;
            lblSize.Text = $"{levelData.Size} x {levelData.Size}";
            lblGoal.Text = $"{levelData.MinMoves}";
            lblMoves.Text = moves.ToString();

            for (var i = 0; i < levelData.Board.Length; i++)
            {
                lights[i].SetButtons(OffButton, OnButton);
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

        private void ConnectGemNeighbors()
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

        private void Light_Click(object sender, EventArgs e)
        {
            Light? light = sender as Light;
            light.ClickLight();
            UpdateLevelData();
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

        private void SolveOne()
        {
            var solution = Solver.GetSolutionMatrix(levelData);
            for (int i = 0; i < lights.Length; i++)
            {
                if (solution[i] == 1)
                {
                    lights[i].ClickLight();
                    UpdateLevelData();
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
                    UpdateLevelData();
                    UpdateMoves();
                    await Task.Delay(500);
                }
            }
            CheckWin();
        }

        private void UpdateLevelData()
        {
            foreach (var light in lights)
            {
                levelData.Board[light.index] = (int)light.State;
            }
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

            foreach (var light in lights)
            {
                light.Enabled = false;
            }
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

        private async void GenerateRandomLevel()
        {
            int size = 4;
            int[] board = new int[size * size];
            int numMoves = 0;
            Random rnd = new Random();
            List<int> used = new List<int>();
            levelData = new LevelData(level + 1, size, 0);

            SetInitialState();
            ConnectGemNeighbors();

            numMoves = rnd.Next(4, 12); // Can adjust difficulty
            for (int i = 0; i < numMoves; i++)
            { 
                int randLight = rnd.Next(0, board.Length);
                while (used.Contains(randLight) )
                {
                    randLight = rnd.Next(0, board.Length);
                }
                used.Add(randLight);

                lights[randLight].ClickLight();

                UpdateLevelData();
                await Task.Delay(0);

                lblLog.Text = DebugBoardState();
            }

            var solution = Solver.GetSolutionMatrix(levelData);
            levelData.MinMoves = Array.FindAll(solution, x => x == 1).Length;
            lblSize.Text = $"{levelData.Size} x {levelData.Size}";
            lblGoal.Text = $"{levelData.MinMoves}";

            foreach (var light in lights)
            {
                light.Enabled = true;
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            GenerateRandomLevel();
            lblLog.Text = DebugBoardState();
        }
    }
}