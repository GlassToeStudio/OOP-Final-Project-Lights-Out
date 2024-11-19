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
            moves = 0;
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
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].Init(i);
            }
        }

        /// <summary>
        /// For each light, add it neighbors to its neighbors list.
        /// <para/><see cref="Light.Neighbors"/> are those <see cref="Light"/>s touching in each cardinal direction.
        /// <code>
        /// Ex:
        ///  size = 4
        ///  length = 16
        ///  
        /// LevelData.Board = [• n • • n L n • • n • • • • • •]
        /// 
        ///     • n • •
        ///     n L n •
        ///     • n • •
        ///     • • • •
        ///     • • • •
        ///
        /// LevelData.Board = [• 1 • • 4 5 6 • • 9 • • • • • •]
        /// 
        ///     • 1 • •
        ///     4 5 6 •
        ///     • 9 • •
        ///     • • • •
        /// </code>
        /// </summary>
        private void ConnectNeighbors()
        {
            int length = lights.Length;
            int size = levelData.Size;

            for (int pos = 0; pos < length; pos++)
            {
                int nAbove = pos - size; // Above
                int nBelow = pos + size; // Below
                int nLeft = pos - 1;    // Left
                int nRight = pos + 1;    // Right

                // Above                    // nAbove = pos - size >= 0 => True
                if (nAbove >= 0)            // nAbove =   5 - 4 = 1 > 0 => True; 5 has neighbor above at 1
                {
                    lights[pos].AddNeighbor(lights[nAbove]);
                }
                // Below                    // nBelow = pos + size  < 16 => True
                if (nBelow < length)        // nBelow =   5 + 4 = 9 < 16 => True; 5 has neighbor below at 9
                {
                    lights[pos].AddNeighbor(lights[nBelow]);
                }
                // Left                     // pos % 4 != 0 => True at            nLeft = pos - 1
                if (pos % size != 0)        //   5 % 4 != 0 => True; 5 has neighbor left at 5 - 1 = 4
                {
                    lights[pos].AddNeighbor(lights[nLeft]);
                }
                // Right                    // nRight = pos + 1     % 4 == 0 => True
                if (nRight % size != 0)     // nRight =   5 + 1 = 6 % 4 != 0 => True; 5 has neighbor right at 6
                {
                    lights[pos].AddNeighbor(lights[nRight]);
                }
            }
        }

        /// <summary>
        /// Generate and initialize a new game from a given <see cref="LevelData"/> object. 
        /// </summary>
        private void GenerateLevelFromLevels()
        {
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
        /// For the given <see cref="Light"/>, call its <see cref="Light.ClickLight"/> method and play a sound.
        /// Update <see cref="LevelData.Board"/> data for the current <see cref="LevelData"/> object and update <see cref="moves"/>.
        /// </summary>
        /// <param name="light"></param>
        private void OnCLickLight(Light light)
        {
            using (var clickSound = new SoundPlayer())
            {
                clickSound.SoundLocation = FileUtil.GetSoundFile("LightClick.wav");
                clickSound.Play();
            }
            light.ClickLight();

            levelData.UpdateBoard(lights);
            UpdateMoves();
        }

        /// <summary>
        /// Update all relevant <see cref="LevelData"/> info on the user interface.
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
        /// Update the number of <see cref="moves"/> taken so far to complete this level.
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
        /// Check if the board is in a winning state. (All <see cref="Light"/>s <see cref="LightState.Off"/>)
        /// If so, update the UI and save <see cref="DataHandler.user"/> data.
        /// Disable all <see cref="Light"/>s until a new level is loaded.
        /// (<see cref="Light"/>s are enabled in their <see cref="Light.Init"/>method.
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
        /// Save user data to disk. See <see cref="DataHandler.user"/>
        /// </summary>
        private void SaveUserData()
        {
            handler.SaveUserData();
        }

        #region Buttons
        /// <summary>
        /// Called when a <see cref="Light"/> <see cref="Button"/> is clicked with the mouse. Call <see cref="OnCLickLight"/> for the <see cref="Light"/> and check for winning condition.
        /// </summary>
        /// <param name="sender">Object (<see cref="Light"/>) that triggerd this event.</param>
        /// <param name="e">Not used.</param>
        private void Light_Click(object sender, EventArgs e)
        {
            Light? light = sender as Light;
            OnCLickLight(light);
            CheckWin();
        }

        /// <summary>
        /// Perform all actions required to initialze a new level. Current <see cref="LevelData"/> is controlled by <see cref="DataHandler.Level"/>.
        /// <para>Called when the Debug button, <see cref="btnLoad"/>, is clicked or when the <see cref="btnNext"/>, <see cref="btnPrevious"/>, and <see cref="btnRedo"/> buttons are clicked.</para>
        /// </summary>
        /// <param name="sender">Object (<see cref="btnLoad"/>) that triggerd this event.</param>
        /// <param name="e">If <see cref="EventArgs.Empty"/>, event was triggered by another button. </param>
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
        /// Increment level index in the <see cref="DataHandler"/> and load next level.
        /// <para> Calls <see cref="LoadLevel_Click"/>.</para>
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used</param>
        private void LoadNextLevel_Click(object sender, EventArgs e)
        {
            handler.IncrementLevel();
            LoadLevel_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Decrement level index in the <see cref="DataHandler"/> and load previous level.
        /// <para> Calls <see cref="LoadLevel_Click"/>.</para>
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used</param>
        private void LoadPreviousLevel_Click(object sender, EventArgs e)
        {
            handler.DecrementLevel();
            LoadLevel_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Reload this level.
        /// <para> Calls <see cref="LoadLevel_Click"/>.</para>
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used</param>
        private void ReloadLevel_Click(object sender, EventArgs e)
        {
            LoadLevel_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Save user data when the program exits.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used</param>
        private void Board_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserData();
        }
        #endregion
    }
}