using System.Media;

namespace LightsOut
{
    /// <summary>
    /// Main UI containing buttons and game board.
    /// </summary>
    public partial class Board : Form
    {
        private int moves = 0;
        private Light[] lights = [];
        private LevelData levelData = new();
        private DataHandler handler = new();

        /// <summary>
        /// Construct board, preload all game data, levels, etc. and generate the first level or 
        /// last level the user played.
        /// </summary>
        public Board()
        {
            InitializeComponent();
            PreloadAllLevelsData();
            GenerateLevelFromLevels();
        }

        /// <summary>
        /// Load all pre-made levels from disk and created the data handler object.
        /// For debugging mode, add all levels to a dropdown list so each level can
        /// be manually loaded.
        /// </summary>
        private void PreloadAllLevelsData()
        {
            handler = new DataHandler();
#if DEBUG
            // Dropdown list of all level data for manual selecting and loading.
            cbxLevelSelect.Items.Clear();
            foreach (LevelData ld in handler.Levels)
            {
                cbxLevelSelect.Items.Add(ld.Name);
            }
            cbxLevelSelect.SelectedIndex = 0;
#endif
        }

        /// <summary>
        /// Generate game board from the current LevelData.
        /// 
        /// All three sized boards and created but only the current board is visible.
        /// The debug save level button is disabled and only enabled when a random
        /// board is generated.
        /// </summary>
        private void GenerateGameBoardsAndSelect()
        {
            btnSaveLevel.Enabled = false;
            gbxGameBoard_3x3.Visible = false;
            gbxGameBoard_4x4.Visible = false;
            gbxGameBoard_5x5.Visible = false;

            switch (levelData.Size)
            {
                case 3:
                    gbxGameBoard_3x3.Visible = true;
                    lights = [
                        light_3x3_00, light_3x3_01, light_3x3_02,
                        light_3x3_10, light_3x3_11, light_3x3_12,
                        light_3x3_20, light_3x3_21, light_3x3_22];
                    break;
                case 4:
                    gbxGameBoard_4x4.Visible = true;
                    lights = [
                        light_4x4_00, light_4x4_01, light_4x4_02, light_4x4_03,
                        light_4x4_10, light_4x4_11, light_4x4_12, light_4x4_13,
                        light_4x4_20, light_4x4_21, light_4x4_22, light_4x4_23,
                        light_4x4_30, light_4x4_31, light_4x4_32, light_4x4_33];
                    break;
                case 5:
                    gbxGameBoard_5x5.Visible = true;
                    lights = [
                        light_5x5_00, light_5x5_01, light_5x5_02, light_5x5_03, light_5x5_04,
                        light_5x5_10, light_5x5_11, light_5x5_12, light_5x5_13, light_5x5_14,
                        light_5x5_20, light_5x5_21, light_5x5_22, light_5x5_23, light_5x5_24,
                        light_5x5_30, light_5x5_31, light_5x5_32, light_5x5_33, light_5x5_34,
                        light_5x5_40, light_5x5_41, light_5x5_42, light_5x5_43, light_5x5_44];
                    break;
                default:
                    gbxGameBoard_4x4.Visible = true;
                    lights = [
                        light_4x4_00, light_4x4_01, light_4x4_02, light_4x4_03,
                        light_4x4_10, light_4x4_11, light_4x4_12, light_4x4_13,
                        light_4x4_20, light_4x4_21, light_4x4_22, light_4x4_23,
                        light_4x4_30, light_4x4_31, light_4x4_32, light_4x4_33];
                    break;
            }

            InitializeBoardLights();
            ConnectNeighbors();
        }

        /// <summary>
        /// Call the Init() method on each Light on the board.
        /// </summary>
        private void InitializeBoardLights()
        {
            for (var i = 0; i < lights.Length; i++)
            {
                lights[i].Init(i);
            }
        }

        /// <summary>
        /// For each light, add it neighbors to its neighbors list.
        /// </summary>
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

        /// <summary>
        /// Generate and initialize a new board from a given LevelData object. 
        /// </summary>
        private void GenerateLevelFromLevels()
        {
            moves = 0;
            levelData = handler.Level;

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
            
            UpdateUI();
#if DEBUG
            cbxLevelSelect.SelectedIndex = handler.SelectedIndex;
            lblLog.Text = DebugBoardState();
#endif
        }

        /// <summary>
        /// For the given Light, call its ClickLight method and play a sound.
        /// Update board data for LevelData object and update moves.
        /// </summary>
        /// <param name="light"></param>
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

        /// <summary>
        /// Update all relevant info on the user interface.
        /// </summary>
        private void UpdateUI()
        {
            gbxStats.Text = levelData.Name;                         // Name
            lblSize.Text = $"{levelData.Size} x {levelData.Size}";  // Size
            lblGoal.Text = $"{levelData.MinMoves}";                 // Goal
            lblMoves.Text = moves.ToString();                       // Moves
            pnlStars.Text = levelData.StarText;                     // Stars ★
                                                                    // Best Score
            lblBest.Text = levelData.BestScore == 9000 ? "---" : $"{levelData.BestScore}";                
        }

        /// <summary>
        /// Update the number of moves taken so far to complete this level.
        /// Update the debug board in the UI.
        /// </summary>
        private void UpdateMoves()
        {
            moves += 1;
            lblMoves.Text = moves.ToString();
#if DEBUG
            lblLog.Text = DebugBoardState();
#endif
        }

        /// <summary>
        /// Check if the board is in a winning state. (All lights off)
        /// If so, update the UI and save user data.
        /// Disable all lights until a new level is loaded. (Lights are enabled in their Init() method.
        /// </summary>
        private void CheckWin()
        {
            foreach (var light in lights)
            {
                if (light.State == LightState.On)
                {
                    return;
                }
            }
            levelData = handler.UpdateUserData( moves);

            foreach (var light in lights)
            {
               light.Enabled = false;
            }

            UpdateUI();
            SaveUserData();

            // Might want a better way to show the user they have won.
            MessageBox.Show($"YOU WIN\n{levelData.StarText}", "WINNER!");
        }

        /// <summary>
        /// Save user data to disk
        /// </summary>
        private void SaveUserData()
        {
            handler.SaveUserData();
        }

        #region Buttons
        /// <summary>
        /// Called when a light is clicked. Click the light and check for winning condition.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Light_Click(object sender, EventArgs e)
        {
            Light? light = sender as Light;
            OnCLickLight(light);
            CheckWin();
        }

        /// <summary>
        /// Called when the Load Level button is clicked and when the Next, Previous, and Reload buttons are clicked.
        /// Generate a level based on which button called this method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadLevel_Click(object sender, EventArgs e)
        {
#if DEBUG
            // If we are trying to load from the level list in the combo box
            // we can check if the EventArgs are not empty. If not, this call
            // comes from the Load button and not another function call.
            if (!e.Equals(EventArgs.Empty))
            { 
                handler.UpdateIndex(cbxLevelSelect.SelectedIndex);
            }
#endif
            GenerateLevelFromLevels();
            UpdateUI();
        }

        /// <summary>
        /// Increment level index in the DataHandler and load next level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadNextLevel_Click(object sender, EventArgs e)
        {
            handler.IncrementLevel();
            LoadLevel_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Decrement level index in the DataHandler and load previous level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPreviousLevel_Click(object sender, EventArgs e)
        {
            handler.DecrementLevel();
            LoadLevel_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Reload this level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadLevel_Click(object sender, EventArgs e)
        {
            LoadLevel_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Save user data when the program exits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Board_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserData();
        }
        #endregion
    }
}