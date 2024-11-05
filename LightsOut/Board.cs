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

            //GenerateLevelFromFile();
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
            else if(rb5x5.Checked)
            {
                return 5;
            }
            return 4;
        }
#endif
    }
}