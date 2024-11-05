using Newtonsoft.Json;
using System.Media;

namespace LightsOut
{
    public partial class Board : Form
    {
        private readonly Image? OnButton = Properties.Resources.ButtonOn;
        private readonly Image? OffButton = Properties.Resources.ButtonOff;

        private Light[] lights = [];
        private LevelData levelData;
        private int moves = 0;
        private int level = 1;
        private string levelName = "Levels_1.json";
        bool debug = false;

        public Board()
        {
            InitializeComponent();
            PreloadLevelsData();
            levelData = new LevelData().LoadLevelDataFromJson(levelName);
            GenerateGameBoard();
            GenerateLevelFromFile();
        }

        private void PreloadLevelsData()
        {
            cbxLevelSelect.Items.Clear();
            string[] files = FileUtil.GetFileFromLevelsFolder();
            foreach (string file in files)
            {
                cbxLevelSelect.Items.Add(Path.GetFileName(file));
            }
            cbxLevelSelect.SelectedIndex = 0;

        }
        private void GenerateGameBoard()
        {
            gbxGameBoard_3x3.Visible = false;
            gbxGameBoard_4x4.Visible = false;
            //Light[] lights_5x5 = new Light[25];

            Light[] lights_4x4 = [
                        light_4x4_00, light_4x4_01, light_4x4_02, light_4x4_03,
                        light_4x4_10, light_4x4_11, light_4x4_12, light_4x4_13,
                        light_4x4_20, light_4x4_21, light_4x4_22, light_4x4_23,
                        light_4x4_30, light_4x4_31, light_4x4_32, light_4x4_33];

            Light[] lights_3x3 = [
                        light_3x3_00, light_3x3_01, light_3x3_02,
                        light_3x3_10, light_3x3_11, light_3x3_12,
                        light_3x3_20, light_3x3_21, light_3x3_22];

            switch (levelData.Size)
            {
                case 3:
                    gbxGameBoard_3x3.Visible = true;
                    lights = lights_3x3;
                    break;
                case 4:
                    gbxGameBoard_4x4.Visible = true;
                    lights = lights_4x4;
                    break;
                default:
                    gbxGameBoard_4x4.Visible = true;
                    lights = lights_4x4;
                    break;
            }

            InitializeBoardLights();
            ConnectNeighbors();
        }

        private void InitializeBoardLights()
        {
            // Set On off button and index value
            for (var i = 0; i < lights.Length; i++)
            {
                lights[i].Neighbors.Clear();
                lights[i].SetButtons(OnButton, OffButton);
                lights[i].index = i;
                lights[i].TurnOff();
            }
        }
        private void ConnectNeighbors()
        {
            // Connect neighbors
            var size = lights.Length;

            for (int pos = 0; pos < size; pos++)
            {
                var n1 = pos - levelData.Size;
                var n2 = pos + levelData.Size;

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

                if (pos % levelData.Size != 0)
                {
                    lights[pos].AddNeighbor(lights[n3]);
                }

                if (n4 % levelData.Size != 0)
                {
                    lights[pos].AddNeighbor(lights[n4]);
                }
            }
        }
        private void GenerateLevelFromFile()
        {
            moves = 0;
            levelName = cbxLevelSelect.Text;
            levelData = new LevelData().LoadLevelDataFromJson(levelName);
            level = levelData.Level;
            GenerateGameBoard();
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
        }

        private void GenerateRandomLevel()
        {
            moves = 0;
            level += 1;
            levelData.Size = GetBoardSizeForRandomGen();
            GenerateGameBoard();
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
#if DEBUG
                lblLog.Text = DebugBoardState();
#endif
                if (numMinMoves.Value == 0)
                {
                    break;
                }
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
            pbxWinImage.BringToFront();
            pbxWinImage.Visible = true;
            foreach (var light in lights)
            {
                light.Enabled = false;
            }
        }

        private void EnableLights()
        {
            pbxWinImage.Visible = false;
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
                    OnCLickLight(lights[i]);
                    CheckWin();
                    return;
                }
            }
        }

        private void OnCLickLight(Light light)
        {
            using (var clickSound = new SoundPlayer())
            {
                clickSound.SoundLocation = FileUtil.GetSoundFile("Snap-sound-effect.wav");
                clickSound.Play();
            }
            light.ClickLight();

            levelData.UpdateBoard(lights);
            UpdateMoves();
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
#if DEBUG


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
#endif

        #region Buttons
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
        #endregion
    }
}