using System.Media;

namespace LightsOut
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Board : Form
    {
        private AllLevels levels;
        private LevelData levelData;
        private Light[] lights = [];

        private int moves = 0;
        private int level = 0;
        private string levelName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Board()
        {
            InitializeComponent();
            PreloadAllLevelsData();
            GenerateLevelFromLevels();
        }

        private void PreloadLevelsData()
        {
            MessageBox.Show("Do not call this method.", "error");
            return;

            cbxLevelSelect.Items.Clear();
            string[] files = FileUtil.GetFileFromLevelsFolder();
            foreach (string file in files)
            {
                cbxLevelSelect.Items.Add(Path.GetFileName(file));
            }
            cbxLevelSelect.SelectedIndex = 0;
        }

        private void PreloadAllLevelsData()
        {
            cbxLevelSelect.Items.Clear();
            levels = new AllLevels().LoadLevels();
            foreach (LevelData ld in levels.Levels)
            {
                cbxLevelSelect.Items.Add(ld.Name);
            }
            cbxLevelSelect.SelectedIndex = 0;
        }

        private void GenerateGameBoardsAndSelect()
        {
            btnSaveLevel.Enabled = false;
            gbxGameBoard_3x3.Visible = false;
            gbxGameBoard_4x4.Visible = false;
            gbxGameBoard_5x5.Visible = false;

            Light[] lights_5x5 = [
                        light_5x5_00, light_5x5_01, light_5x5_02, light_5x5_03, light_5x5_04,
                        light_5x5_10, light_5x5_11, light_5x5_12, light_5x5_13, light_5x5_14,
                        light_5x5_20, light_5x5_21, light_5x5_22, light_5x5_23, light_5x5_24,
                        light_5x5_30, light_5x5_31, light_5x5_32, light_5x5_33, light_5x5_34,
                        light_5x5_40, light_5x5_41, light_5x5_42, light_5x5_43, light_5x5_44];

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
                case 5:
                    gbxGameBoard_5x5.Visible = true;
                    lights = lights_5x5;
                    break;
                default:
                    gbxGameBoard_4x4.Visible = true;
                    lights = lights_4x4;
                    break;
            }

            InitializeBoardLights();
            ConnectNeighbors();

            pbxWinImage.Visible = false;
        }

        private void InitializeBoardLights()
        {
            // Set On off button and Index value
            for (var i = 0; i < lights.Length; i++)
            {
                lights[i].Init(i);
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
            MessageBox.Show("Do not call this method.", "error");
            return;

            moves = 0;
            levelName = cbxLevelSelect.Text;
            levelData = new LevelData().LoadLevelDataFromJson(levelName);
            level = levelData.Level;

            GenerateGameBoardsAndSelect();

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

            lblLog.Text = DebugBoardState();
            UpdateUI();
        }

        private void GenerateLevelFromLevels()
        {
            moves = 0;
            levelName = cbxLevelSelect.Text;
            levelData = new LevelData(levels.Levels[cbxLevelSelect.SelectedIndex]);
            level = levelData.Level;

            GenerateGameBoardsAndSelect();

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

            lblLog.Text = DebugBoardState();
            UpdateUI();
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

            pbxWinImage.BringToFront();
            pbxWinImage.Visible = true;
            foreach (var light in lights)
            {
                light.Enabled = false;
            }
        }


        #region Buttons
        private void Light_Click(object sender, EventArgs e)
        {
            Light? light = sender as Light;
            OnCLickLight(light);
            CheckWin();
        }

        private void LoadLevel_Click(object sender, EventArgs e)
        {
            //GenerateLevelFromFile();
            GenerateLevelFromLevels();
            UpdateUI();
        }

        private void LoadPreviousLevel_Click(object sender, EventArgs e)
        {
            int index = cbxLevelSelect.SelectedIndex;
            index = Math.Max(index - 1, 0);
            cbxLevelSelect.SelectedIndex = index;
            LoadLevel_Click(this, EventArgs.Empty);
        }

        private void LoadNextLevel_Click(object sender, EventArgs e)
        {
            int index = cbxLevelSelect.SelectedIndex;
            index = Math.Min(index + 1, cbxLevelSelect.Items.Count - 1);
            cbxLevelSelect.SelectedIndex = index;
            LoadLevel_Click(this, EventArgs.Empty);
        }

        private void ReloadLevel_Click(object sender, EventArgs e)
        {
            LoadLevel_Click(this, EventArgs.Empty);
        }
        #endregion
    }
}