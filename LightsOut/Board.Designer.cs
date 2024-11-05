namespace LightsOut
{
    partial class Board
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            light_4x4_33 = new Light();
            light_4x4_32 = new Light();
            light_4x4_31 = new Light();
            light_4x4_30 = new Light();
            light_4x4_23 = new Light();
            light_4x4_22 = new Light();
            light_4x4_21 = new Light();
            light_4x4_20 = new Light();
            light_4x4_13 = new Light();
            light_4x4_12 = new Light();
            light_4x4_11 = new Light();
            light_4x4_10 = new Light();
            light_4x4_03 = new Light();
            light_4x4_02 = new Light();
            light_4x4_01 = new Light();
            light_4x4_00 = new Light();
            gbxGameBoard_4x4 = new GroupBox();
            pbxWinImage = new PictureBox();
            lblLog = new Label();
            btnSolveAll = new Button();
            gbxStats = new GroupBox();
            lblMoves = new Label();
            lblGoal = new Label();
            lblMovesLabel = new Label();
            lblGoalLabel = new Label();
            lblSize = new Label();
            lblSizeLabel = new Label();
            btnSolveOne = new Button();
            btnGenerateRandom = new Button();
            btnLoad = new Button();
            cbxLevelSelect = new ComboBox();
            bgxDebug = new GroupBox();
            numMinMoves = new NumericUpDown();
            lblMinMovesInput = new Label();
            rb5x5 = new RadioButton();
            rb4x4 = new RadioButton();
            rb3x3 = new RadioButton();
            btnSaveLevel = new Button();
            gbxGameBoard_3x3 = new GroupBox();
            light_3x3_22 = new Light();
            light_3x3_21 = new Light();
            light_3x3_20 = new Light();
            light_3x3_12 = new Light();
            light_3x3_11 = new Light();
            light_3x3_10 = new Light();
            light_3x3_02 = new Light();
            light_3x3_01 = new Light();
            light_3x3_00 = new Light();
            gbxGameBoard_4x4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxWinImage).BeginInit();
            gbxStats.SuspendLayout();
            bgxDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMinMoves).BeginInit();
            gbxGameBoard_3x3.SuspendLayout();
            SuspendLayout();
            // 
            // light_4x4_33
            // 
            light_4x4_33.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_33.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_33.FlatAppearance.BorderSize = 0;
            light_4x4_33.FlatStyle = FlatStyle.Flat;
            light_4x4_33.index = 15;
            light_4x4_33.Location = new Point(230, 235);
            light_4x4_33.Name = "light_4x4_33";
            light_4x4_33.OffButton = Properties.Resources.ButtonOff;
            light_4x4_33.OnButton = Properties.Resources.ButtonOn;
            light_4x4_33.Size = new Size(75, 75);
            light_4x4_33.State = LightState.Off;
            light_4x4_33.TabIndex = 15;
            light_4x4_33.UseVisualStyleBackColor = true;
            light_4x4_33.Click += Light_Click;
            // 
            // light_4x4_32
            // 
            light_4x4_32.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_32.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_32.FlatAppearance.BorderSize = 0;
            light_4x4_32.FlatStyle = FlatStyle.Flat;
            light_4x4_32.index = 14;
            light_4x4_32.Location = new Point(155, 235);
            light_4x4_32.Name = "light_4x4_32";
            light_4x4_32.OffButton = Properties.Resources.ButtonOff;
            light_4x4_32.OnButton = Properties.Resources.ButtonOn;
            light_4x4_32.Size = new Size(75, 75);
            light_4x4_32.State = LightState.Off;
            light_4x4_32.TabIndex = 14;
            light_4x4_32.UseVisualStyleBackColor = true;
            light_4x4_32.Click += Light_Click;
            // 
            // light_4x4_31
            // 
            light_4x4_31.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_31.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_31.FlatAppearance.BorderSize = 0;
            light_4x4_31.FlatStyle = FlatStyle.Flat;
            light_4x4_31.index = 13;
            light_4x4_31.Location = new Point(80, 235);
            light_4x4_31.Name = "light_4x4_31";
            light_4x4_31.OffButton = Properties.Resources.ButtonOff;
            light_4x4_31.OnButton = Properties.Resources.ButtonOn;
            light_4x4_31.Size = new Size(75, 75);
            light_4x4_31.State = LightState.Off;
            light_4x4_31.TabIndex = 13;
            light_4x4_31.UseVisualStyleBackColor = true;
            light_4x4_31.Click += Light_Click;
            // 
            // light_4x4_30
            // 
            light_4x4_30.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_30.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_30.FlatAppearance.BorderSize = 0;
            light_4x4_30.FlatStyle = FlatStyle.Flat;
            light_4x4_30.index = 12;
            light_4x4_30.Location = new Point(5, 235);
            light_4x4_30.Name = "light_4x4_30";
            light_4x4_30.OffButton = Properties.Resources.ButtonOff;
            light_4x4_30.OnButton = Properties.Resources.ButtonOn;
            light_4x4_30.Size = new Size(75, 75);
            light_4x4_30.State = LightState.Off;
            light_4x4_30.TabIndex = 12;
            light_4x4_30.UseVisualStyleBackColor = true;
            light_4x4_30.Click += Light_Click;
            // 
            // light_4x4_23
            // 
            light_4x4_23.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_23.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_23.FlatAppearance.BorderSize = 0;
            light_4x4_23.FlatStyle = FlatStyle.Flat;
            light_4x4_23.index = 11;
            light_4x4_23.Location = new Point(230, 160);
            light_4x4_23.Name = "light_4x4_23";
            light_4x4_23.OffButton = Properties.Resources.ButtonOff;
            light_4x4_23.OnButton = Properties.Resources.ButtonOn;
            light_4x4_23.Size = new Size(75, 75);
            light_4x4_23.State = LightState.Off;
            light_4x4_23.TabIndex = 11;
            light_4x4_23.UseVisualStyleBackColor = true;
            light_4x4_23.Click += Light_Click;
            // 
            // light_4x4_22
            // 
            light_4x4_22.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_22.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_22.FlatAppearance.BorderSize = 0;
            light_4x4_22.FlatStyle = FlatStyle.Flat;
            light_4x4_22.index = 10;
            light_4x4_22.Location = new Point(155, 160);
            light_4x4_22.Name = "light_4x4_22";
            light_4x4_22.OffButton = Properties.Resources.ButtonOff;
            light_4x4_22.OnButton = Properties.Resources.ButtonOn;
            light_4x4_22.Size = new Size(75, 75);
            light_4x4_22.State = LightState.Off;
            light_4x4_22.TabIndex = 10;
            light_4x4_22.UseVisualStyleBackColor = true;
            light_4x4_22.Click += Light_Click;
            // 
            // light_4x4_21
            // 
            light_4x4_21.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_21.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_21.FlatAppearance.BorderSize = 0;
            light_4x4_21.FlatStyle = FlatStyle.Flat;
            light_4x4_21.index = 9;
            light_4x4_21.Location = new Point(80, 160);
            light_4x4_21.Name = "light_4x4_21";
            light_4x4_21.OffButton = Properties.Resources.ButtonOff;
            light_4x4_21.OnButton = Properties.Resources.ButtonOn;
            light_4x4_21.Size = new Size(75, 75);
            light_4x4_21.State = LightState.Off;
            light_4x4_21.TabIndex = 9;
            light_4x4_21.UseVisualStyleBackColor = true;
            light_4x4_21.Click += Light_Click;
            // 
            // light_4x4_20
            // 
            light_4x4_20.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_20.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_20.FlatAppearance.BorderSize = 0;
            light_4x4_20.FlatStyle = FlatStyle.Flat;
            light_4x4_20.index = 8;
            light_4x4_20.Location = new Point(5, 160);
            light_4x4_20.Name = "light_4x4_20";
            light_4x4_20.OffButton = Properties.Resources.ButtonOff;
            light_4x4_20.OnButton = Properties.Resources.ButtonOn;
            light_4x4_20.Size = new Size(75, 75);
            light_4x4_20.State = LightState.Off;
            light_4x4_20.TabIndex = 8;
            light_4x4_20.UseVisualStyleBackColor = true;
            light_4x4_20.Click += Light_Click;
            // 
            // light_4x4_13
            // 
            light_4x4_13.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_13.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_13.FlatAppearance.BorderSize = 0;
            light_4x4_13.FlatStyle = FlatStyle.Flat;
            light_4x4_13.index = 7;
            light_4x4_13.Location = new Point(230, 85);
            light_4x4_13.Name = "light_4x4_13";
            light_4x4_13.OffButton = Properties.Resources.ButtonOff;
            light_4x4_13.OnButton = Properties.Resources.ButtonOn;
            light_4x4_13.Size = new Size(75, 75);
            light_4x4_13.State = LightState.Off;
            light_4x4_13.TabIndex = 7;
            light_4x4_13.UseVisualStyleBackColor = true;
            light_4x4_13.Click += Light_Click;
            // 
            // light_4x4_12
            // 
            light_4x4_12.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_12.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_12.FlatAppearance.BorderSize = 0;
            light_4x4_12.FlatStyle = FlatStyle.Flat;
            light_4x4_12.index = 6;
            light_4x4_12.Location = new Point(155, 85);
            light_4x4_12.Name = "light_4x4_12";
            light_4x4_12.OffButton = Properties.Resources.ButtonOff;
            light_4x4_12.OnButton = Properties.Resources.ButtonOn;
            light_4x4_12.Size = new Size(75, 75);
            light_4x4_12.State = LightState.Off;
            light_4x4_12.TabIndex = 6;
            light_4x4_12.UseVisualStyleBackColor = true;
            light_4x4_12.Click += Light_Click;
            // 
            // light_4x4_11
            // 
            light_4x4_11.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_11.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_11.FlatAppearance.BorderSize = 0;
            light_4x4_11.FlatStyle = FlatStyle.Flat;
            light_4x4_11.index = 5;
            light_4x4_11.Location = new Point(80, 85);
            light_4x4_11.Name = "light_4x4_11";
            light_4x4_11.OffButton = Properties.Resources.ButtonOff;
            light_4x4_11.OnButton = Properties.Resources.ButtonOn;
            light_4x4_11.Size = new Size(75, 75);
            light_4x4_11.State = LightState.Off;
            light_4x4_11.TabIndex = 5;
            light_4x4_11.UseVisualStyleBackColor = true;
            light_4x4_11.Click += Light_Click;
            // 
            // light_4x4_10
            // 
            light_4x4_10.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_10.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_10.FlatAppearance.BorderSize = 0;
            light_4x4_10.FlatStyle = FlatStyle.Flat;
            light_4x4_10.index = 4;
            light_4x4_10.Location = new Point(5, 85);
            light_4x4_10.Name = "light_4x4_10";
            light_4x4_10.OffButton = Properties.Resources.ButtonOff;
            light_4x4_10.OnButton = Properties.Resources.ButtonOn;
            light_4x4_10.Size = new Size(75, 75);
            light_4x4_10.State = LightState.Off;
            light_4x4_10.TabIndex = 4;
            light_4x4_10.UseVisualStyleBackColor = true;
            light_4x4_10.Click += Light_Click;
            // 
            // light_4x4_03
            // 
            light_4x4_03.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_03.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_03.FlatAppearance.BorderSize = 0;
            light_4x4_03.FlatStyle = FlatStyle.Flat;
            light_4x4_03.index = 3;
            light_4x4_03.Location = new Point(230, 10);
            light_4x4_03.Name = "light_4x4_03";
            light_4x4_03.OffButton = Properties.Resources.ButtonOff;
            light_4x4_03.OnButton = Properties.Resources.ButtonOn;
            light_4x4_03.Size = new Size(75, 75);
            light_4x4_03.State = LightState.Off;
            light_4x4_03.TabIndex = 3;
            light_4x4_03.UseVisualStyleBackColor = true;
            light_4x4_03.Click += Light_Click;
            // 
            // light_4x4_02
            // 
            light_4x4_02.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_02.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_02.FlatAppearance.BorderSize = 0;
            light_4x4_02.FlatStyle = FlatStyle.Flat;
            light_4x4_02.index = 2;
            light_4x4_02.Location = new Point(155, 10);
            light_4x4_02.Name = "light_4x4_02";
            light_4x4_02.OffButton = Properties.Resources.ButtonOff;
            light_4x4_02.OnButton = Properties.Resources.ButtonOn;
            light_4x4_02.Size = new Size(75, 75);
            light_4x4_02.State = LightState.Off;
            light_4x4_02.TabIndex = 2;
            light_4x4_02.UseVisualStyleBackColor = true;
            light_4x4_02.Click += Light_Click;
            // 
            // light_4x4_01
            // 
            light_4x4_01.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_01.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_01.FlatAppearance.BorderSize = 0;
            light_4x4_01.FlatStyle = FlatStyle.Flat;
            light_4x4_01.index = 1;
            light_4x4_01.Location = new Point(80, 10);
            light_4x4_01.Name = "light_4x4_01";
            light_4x4_01.OffButton = Properties.Resources.ButtonOff;
            light_4x4_01.OnButton = Properties.Resources.ButtonOn;
            light_4x4_01.Size = new Size(75, 75);
            light_4x4_01.State = LightState.Off;
            light_4x4_01.TabIndex = 1;
            light_4x4_01.UseVisualStyleBackColor = true;
            light_4x4_01.Click += Light_Click;
            // 
            // light_4x4_00
            // 
            light_4x4_00.BackgroundImage = Properties.Resources.ButtonOn;
            light_4x4_00.BackgroundImageLayout = ImageLayout.Stretch;
            light_4x4_00.FlatAppearance.BorderSize = 0;
            light_4x4_00.FlatStyle = FlatStyle.Flat;
            light_4x4_00.index = 0;
            light_4x4_00.Location = new Point(5, 10);
            light_4x4_00.Name = "light_4x4_00";
            light_4x4_00.OffButton = Properties.Resources.ButtonOff;
            light_4x4_00.OnButton = Properties.Resources.ButtonOn;
            light_4x4_00.Size = new Size(75, 75);
            light_4x4_00.State = LightState.Off;
            light_4x4_00.TabIndex = 0;
            light_4x4_00.UseVisualStyleBackColor = true;
            light_4x4_00.Click += Light_Click;
            // 
            // gbxGameBoard_4x4
            // 
            gbxGameBoard_4x4.BackColor = Color.Black;
            gbxGameBoard_4x4.BackgroundImageLayout = ImageLayout.Stretch;
            gbxGameBoard_4x4.Controls.Add(light_4x4_33);
            gbxGameBoard_4x4.Controls.Add(light_4x4_32);
            gbxGameBoard_4x4.Controls.Add(light_4x4_31);
            gbxGameBoard_4x4.Controls.Add(light_4x4_30);
            gbxGameBoard_4x4.Controls.Add(light_4x4_23);
            gbxGameBoard_4x4.Controls.Add(light_4x4_22);
            gbxGameBoard_4x4.Controls.Add(light_4x4_21);
            gbxGameBoard_4x4.Controls.Add(light_4x4_20);
            gbxGameBoard_4x4.Controls.Add(light_4x4_13);
            gbxGameBoard_4x4.Controls.Add(light_4x4_12);
            gbxGameBoard_4x4.Controls.Add(light_4x4_11);
            gbxGameBoard_4x4.Controls.Add(light_4x4_10);
            gbxGameBoard_4x4.Controls.Add(light_4x4_03);
            gbxGameBoard_4x4.Controls.Add(light_4x4_02);
            gbxGameBoard_4x4.Controls.Add(light_4x4_01);
            gbxGameBoard_4x4.Controls.Add(light_4x4_00);
            gbxGameBoard_4x4.FlatStyle = FlatStyle.Flat;
            gbxGameBoard_4x4.Location = new Point(8, 88);
            gbxGameBoard_4x4.Margin = new Padding(2);
            gbxGameBoard_4x4.Name = "gbxGameBoard_4x4";
            gbxGameBoard_4x4.Padding = new Padding(2);
            gbxGameBoard_4x4.Size = new Size(310, 315);
            gbxGameBoard_4x4.TabIndex = 0;
            gbxGameBoard_4x4.TabStop = false;
            // 
            // pbxWinImage
            // 
            pbxWinImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxWinImage.BackgroundImage = Properties.Resources.WinPanel;
            pbxWinImage.BackgroundImageLayout = ImageLayout.Stretch;
            pbxWinImage.Location = new Point(21, 15);
            pbxWinImage.Name = "pbxWinImage";
            pbxWinImage.Size = new Size(620, 136);
            pbxWinImage.TabIndex = 9;
            pbxWinImage.TabStop = false;
            pbxWinImage.Visible = false;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.BackColor = SystemColors.ActiveCaptionText;
            lblLog.BorderStyle = BorderStyle.FixedSingle;
            lblLog.FlatStyle = FlatStyle.Flat;
            lblLog.Location = new Point(11, 242);
            lblLog.MinimumSize = new Size(130, 25);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(130, 25);
            lblLog.TabIndex = 1;
            lblLog.Text = "0,0,0,0";
            lblLog.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSolveAll
            // 
            btnSolveAll.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolveAll.FlatStyle = FlatStyle.Flat;
            btnSolveAll.ForeColor = SystemColors.ActiveCaption;
            btnSolveAll.Location = new Point(11, 49);
            btnSolveAll.Name = "btnSolveAll";
            btnSolveAll.Size = new Size(136, 26);
            btnSolveAll.TabIndex = 2;
            btnSolveAll.Text = "Solve All";
            btnSolveAll.UseMnemonic = false;
            btnSolveAll.UseVisualStyleBackColor = false;
            btnSolveAll.Click += SolveAll_Click;
            // 
            // gbxStats
            // 
            gbxStats.BackColor = Color.Black;
            gbxStats.Controls.Add(lblMoves);
            gbxStats.Controls.Add(lblGoal);
            gbxStats.Controls.Add(lblMovesLabel);
            gbxStats.Controls.Add(lblGoalLabel);
            gbxStats.Controls.Add(lblSize);
            gbxStats.Controls.Add(lblSizeLabel);
            gbxStats.ForeColor = SystemColors.ActiveCaption;
            gbxStats.Location = new Point(324, 89);
            gbxStats.Name = "gbxStats";
            gbxStats.Size = new Size(150, 135);
            gbxStats.TabIndex = 3;
            gbxStats.TabStop = false;
            gbxStats.Text = "Level X";
            // 
            // lblMoves
            // 
            lblMoves.AutoSize = true;
            lblMoves.BackColor = Color.Black;
            lblMoves.FlatStyle = FlatStyle.Flat;
            lblMoves.ForeColor = SystemColors.ActiveCaption;
            lblMoves.ImageAlign = ContentAlignment.MiddleRight;
            lblMoves.Location = new Point(85, 86);
            lblMoves.MinimumSize = new Size(50, 0);
            lblMoves.Name = "lblMoves";
            lblMoves.RightToLeft = RightToLeft.No;
            lblMoves.Size = new Size(50, 15);
            lblMoves.TabIndex = 5;
            lblMoves.Text = "0";
            lblMoves.TextAlign = ContentAlignment.TopRight;
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.BackColor = Color.Black;
            lblGoal.FlatStyle = FlatStyle.Flat;
            lblGoal.ForeColor = SystemColors.ActiveCaption;
            lblGoal.ImageAlign = ContentAlignment.MiddleRight;
            lblGoal.Location = new Point(85, 56);
            lblGoal.MinimumSize = new Size(50, 0);
            lblGoal.Name = "lblGoal";
            lblGoal.RightToLeft = RightToLeft.No;
            lblGoal.Size = new Size(50, 15);
            lblGoal.TabIndex = 4;
            lblGoal.Text = "5";
            lblGoal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMovesLabel
            // 
            lblMovesLabel.AutoSize = true;
            lblMovesLabel.BackColor = Color.Black;
            lblMovesLabel.ForeColor = SystemColors.ActiveCaption;
            lblMovesLabel.Location = new Point(19, 86);
            lblMovesLabel.Name = "lblMovesLabel";
            lblMovesLabel.Size = new Size(45, 15);
            lblMovesLabel.TabIndex = 3;
            lblMovesLabel.Text = "Moves:";
            // 
            // lblGoalLabel
            // 
            lblGoalLabel.AutoSize = true;
            lblGoalLabel.BackColor = Color.Black;
            lblGoalLabel.ForeColor = SystemColors.ActiveCaption;
            lblGoalLabel.Location = new Point(19, 56);
            lblGoalLabel.Name = "lblGoalLabel";
            lblGoalLabel.Size = new Size(34, 15);
            lblGoalLabel.TabIndex = 2;
            lblGoalLabel.Text = "Goal:";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.BackColor = Color.Black;
            lblSize.FlatStyle = FlatStyle.Flat;
            lblSize.ForeColor = SystemColors.ActiveCaption;
            lblSize.ImageAlign = ContentAlignment.MiddleRight;
            lblSize.Location = new Point(85, 26);
            lblSize.MinimumSize = new Size(50, 0);
            lblSize.Name = "lblSize";
            lblSize.RightToLeft = RightToLeft.No;
            lblSize.Size = new Size(50, 15);
            lblSize.TabIndex = 1;
            lblSize.Text = "4 x 4";
            lblSize.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSizeLabel
            // 
            lblSizeLabel.AutoSize = true;
            lblSizeLabel.BackColor = Color.Black;
            lblSizeLabel.ForeColor = SystemColors.ActiveCaption;
            lblSizeLabel.Location = new Point(19, 26);
            lblSizeLabel.Name = "lblSizeLabel";
            lblSizeLabel.Size = new Size(30, 15);
            lblSizeLabel.TabIndex = 0;
            lblSizeLabel.Text = "Size:";
            // 
            // btnSolveOne
            // 
            btnSolveOne.BackgroundImageLayout = ImageLayout.Stretch;
            btnSolveOne.FlatStyle = FlatStyle.Flat;
            btnSolveOne.ForeColor = SystemColors.ActiveCaption;
            btnSolveOne.Location = new Point(11, 21);
            btnSolveOne.Name = "btnSolveOne";
            btnSolveOne.Size = new Size(136, 26);
            btnSolveOne.TabIndex = 4;
            btnSolveOne.Text = "Solve One";
            btnSolveOne.UseMnemonic = false;
            btnSolveOne.UseVisualStyleBackColor = false;
            btnSolveOne.Click += SolveOne_Click;
            // 
            // btnGenerateRandom
            // 
            btnGenerateRandom.BackgroundImageLayout = ImageLayout.Stretch;
            btnGenerateRandom.FlatStyle = FlatStyle.Flat;
            btnGenerateRandom.ForeColor = SystemColors.ActiveCaption;
            btnGenerateRandom.Location = new Point(11, 85);
            btnGenerateRandom.Name = "btnGenerateRandom";
            btnGenerateRandom.Size = new Size(65, 40);
            btnGenerateRandom.TabIndex = 6;
            btnGenerateRandom.Text = "Generate Random";
            btnGenerateRandom.UseMnemonic = false;
            btnGenerateRandom.UseVisualStyleBackColor = false;
            btnGenerateRandom.Click += GenerateRandom_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackgroundImageLayout = ImageLayout.Stretch;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.ForeColor = SystemColors.ActiveCaption;
            btnLoad.Location = new Point(11, 186);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(130, 26);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load";
            btnLoad.UseMnemonic = false;
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += LoadLevel_Click;
            // 
            // cbxLevelSelect
            // 
            cbxLevelSelect.BackColor = SystemColors.InactiveCaptionText;
            cbxLevelSelect.FlatStyle = FlatStyle.Flat;
            cbxLevelSelect.ForeColor = SystemColors.InactiveCaption;
            cbxLevelSelect.FormattingEnabled = true;
            cbxLevelSelect.Location = new Point(11, 216);
            cbxLevelSelect.Name = "cbxLevelSelect";
            cbxLevelSelect.Size = new Size(130, 23);
            cbxLevelSelect.TabIndex = 8;
            // 
            // bgxDebug
            // 
            bgxDebug.Controls.Add(numMinMoves);
            bgxDebug.Controls.Add(lblMinMovesInput);
            bgxDebug.Controls.Add(rb5x5);
            bgxDebug.Controls.Add(rb4x4);
            bgxDebug.Controls.Add(rb3x3);
            bgxDebug.Controls.Add(btnSaveLevel);
            bgxDebug.Controls.Add(lblLog);
            bgxDebug.Controls.Add(cbxLevelSelect);
            bgxDebug.Controls.Add(btnSolveOne);
            bgxDebug.Controls.Add(btnLoad);
            bgxDebug.Controls.Add(btnSolveAll);
            bgxDebug.Controls.Add(btnGenerateRandom);
            bgxDebug.ForeColor = SystemColors.ActiveCaption;
            bgxDebug.Location = new Point(500, 88);
            bgxDebug.Name = "bgxDebug";
            bgxDebug.Size = new Size(150, 315);
            bgxDebug.TabIndex = 10;
            bgxDebug.TabStop = false;
            bgxDebug.Text = "Debug Panel";
            // 
            // numMinMoves
            // 
            numMinMoves.BackColor = SystemColors.ControlText;
            numMinMoves.BorderStyle = BorderStyle.None;
            numMinMoves.ForeColor = SystemColors.ActiveCaption;
            numMinMoves.Location = new Point(81, 158);
            numMinMoves.Name = "numMinMoves";
            numMinMoves.Size = new Size(60, 19);
            numMinMoves.TabIndex = 12;
            numMinMoves.TextAlign = HorizontalAlignment.Center;
            numMinMoves.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblMinMovesInput
            // 
            lblMinMovesInput.AutoSize = true;
            lblMinMovesInput.Location = new Point(79, 139);
            lblMinMovesInput.Name = "lblMinMovesInput";
            lblMinMovesInput.Size = new Size(66, 15);
            lblMinMovesInput.TabIndex = 14;
            lblMinMovesInput.Text = "Min Moves";
            // 
            // rb5x5
            // 
            rb5x5.AutoSize = true;
            rb5x5.FlatStyle = FlatStyle.Flat;
            rb5x5.Location = new Point(86, 119);
            rb5x5.Name = "rb5x5";
            rb5x5.Size = new Size(48, 19);
            rb5x5.TabIndex = 12;
            rb5x5.Text = "5 x 5";
            rb5x5.UseVisualStyleBackColor = true;
            // 
            // rb4x4
            // 
            rb4x4.AutoSize = true;
            rb4x4.Checked = true;
            rb4x4.FlatStyle = FlatStyle.Flat;
            rb4x4.Location = new Point(86, 101);
            rb4x4.Name = "rb4x4";
            rb4x4.Size = new Size(48, 19);
            rb4x4.TabIndex = 11;
            rb4x4.TabStop = true;
            rb4x4.Text = "4 x 4";
            rb4x4.UseVisualStyleBackColor = true;
            // 
            // rb3x3
            // 
            rb3x3.AutoSize = true;
            rb3x3.FlatStyle = FlatStyle.Flat;
            rb3x3.Location = new Point(86, 83);
            rb3x3.Name = "rb3x3";
            rb3x3.Size = new Size(48, 19);
            rb3x3.TabIndex = 10;
            rb3x3.Text = "3 x 3";
            rb3x3.UseVisualStyleBackColor = true;
            // 
            // btnSaveLevel
            // 
            btnSaveLevel.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveLevel.FlatStyle = FlatStyle.Flat;
            btnSaveLevel.ForeColor = SystemColors.ActiveCaption;
            btnSaveLevel.Location = new Point(11, 137);
            btnSaveLevel.Name = "btnSaveLevel";
            btnSaveLevel.Size = new Size(65, 40);
            btnSaveLevel.TabIndex = 9;
            btnSaveLevel.Text = "Save to File";
            btnSaveLevel.UseMnemonic = false;
            btnSaveLevel.UseVisualStyleBackColor = false;
            btnSaveLevel.Click += SaveLevelToFile_Click;
            // 
            // gbxGameBoard_3x3
            // 
            gbxGameBoard_3x3.BackColor = Color.Black;
            gbxGameBoard_3x3.BackgroundImageLayout = ImageLayout.Stretch;
            gbxGameBoard_3x3.Controls.Add(light_3x3_22);
            gbxGameBoard_3x3.Controls.Add(light_3x3_21);
            gbxGameBoard_3x3.Controls.Add(light_3x3_20);
            gbxGameBoard_3x3.Controls.Add(light_3x3_12);
            gbxGameBoard_3x3.Controls.Add(light_3x3_11);
            gbxGameBoard_3x3.Controls.Add(light_3x3_10);
            gbxGameBoard_3x3.Controls.Add(light_3x3_02);
            gbxGameBoard_3x3.Controls.Add(light_3x3_01);
            gbxGameBoard_3x3.Controls.Add(light_3x3_00);
            gbxGameBoard_3x3.FlatStyle = FlatStyle.Flat;
            gbxGameBoard_3x3.Location = new Point(7, 86);
            gbxGameBoard_3x3.Margin = new Padding(2);
            gbxGameBoard_3x3.Name = "gbxGameBoard_3x3";
            gbxGameBoard_3x3.Padding = new Padding(2);
            gbxGameBoard_3x3.Size = new Size(311, 315);
            gbxGameBoard_3x3.TabIndex = 11;
            gbxGameBoard_3x3.TabStop = false;
            // 
            // light_3x3_22
            // 
            light_3x3_22.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_22.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_22.FlatAppearance.BorderSize = 0;
            light_3x3_22.FlatStyle = FlatStyle.Flat;
            light_3x3_22.index = 8;
            light_3x3_22.Location = new Point(207, 210);
            light_3x3_22.Name = "light_3x3_22";
            light_3x3_22.OffButton = Properties.Resources.ButtonOff;
            light_3x3_22.OnButton = Properties.Resources.ButtonOn;
            light_3x3_22.Size = new Size(100, 100);
            light_3x3_22.State = LightState.Off;
            light_3x3_22.TabIndex = 8;
            light_3x3_22.UseVisualStyleBackColor = true;
            light_3x3_22.Click += Light_Click;
            // 
            // light_3x3_21
            // 
            light_3x3_21.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_21.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_21.FlatAppearance.BorderSize = 0;
            light_3x3_21.FlatStyle = FlatStyle.Flat;
            light_3x3_21.index = 7;
            light_3x3_21.Location = new Point(106, 210);
            light_3x3_21.Name = "light_3x3_21";
            light_3x3_21.OffButton = Properties.Resources.ButtonOff;
            light_3x3_21.OnButton = Properties.Resources.ButtonOn;
            light_3x3_21.Size = new Size(100, 100);
            light_3x3_21.State = LightState.Off;
            light_3x3_21.TabIndex = 7;
            light_3x3_21.UseVisualStyleBackColor = true;
            light_3x3_21.Click += Light_Click;
            // 
            // light_3x3_20
            // 
            light_3x3_20.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_20.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_20.FlatAppearance.BorderSize = 0;
            light_3x3_20.FlatStyle = FlatStyle.Flat;
            light_3x3_20.index = 6;
            light_3x3_20.Location = new Point(5, 210);
            light_3x3_20.Name = "light_3x3_20";
            light_3x3_20.OffButton = Properties.Resources.ButtonOff;
            light_3x3_20.OnButton = Properties.Resources.ButtonOn;
            light_3x3_20.Size = new Size(100, 100);
            light_3x3_20.State = LightState.Off;
            light_3x3_20.TabIndex = 6;
            light_3x3_20.UseVisualStyleBackColor = true;
            light_3x3_20.Click += Light_Click;
            // 
            // light_3x3_12
            // 
            light_3x3_12.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_12.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_12.FlatAppearance.BorderSize = 0;
            light_3x3_12.FlatStyle = FlatStyle.Flat;
            light_3x3_12.index = 5;
            light_3x3_12.Location = new Point(207, 110);
            light_3x3_12.Name = "light_3x3_12";
            light_3x3_12.OffButton = Properties.Resources.ButtonOff;
            light_3x3_12.OnButton = Properties.Resources.ButtonOn;
            light_3x3_12.Size = new Size(100, 100);
            light_3x3_12.State = LightState.Off;
            light_3x3_12.TabIndex = 5;
            light_3x3_12.UseVisualStyleBackColor = true;
            light_3x3_12.Click += Light_Click;
            // 
            // light_3x3_11
            // 
            light_3x3_11.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_11.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_11.FlatAppearance.BorderSize = 0;
            light_3x3_11.FlatStyle = FlatStyle.Flat;
            light_3x3_11.index = 4;
            light_3x3_11.Location = new Point(106, 110);
            light_3x3_11.Name = "light_3x3_11";
            light_3x3_11.OffButton = Properties.Resources.ButtonOff;
            light_3x3_11.OnButton = Properties.Resources.ButtonOn;
            light_3x3_11.Size = new Size(100, 100);
            light_3x3_11.State = LightState.Off;
            light_3x3_11.TabIndex = 4;
            light_3x3_11.UseVisualStyleBackColor = true;
            light_3x3_11.Click += Light_Click;
            // 
            // light_3x3_10
            // 
            light_3x3_10.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_10.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_10.FlatAppearance.BorderSize = 0;
            light_3x3_10.FlatStyle = FlatStyle.Flat;
            light_3x3_10.index = 3;
            light_3x3_10.Location = new Point(5, 110);
            light_3x3_10.Name = "light_3x3_10";
            light_3x3_10.OffButton = Properties.Resources.ButtonOff;
            light_3x3_10.OnButton = Properties.Resources.ButtonOn;
            light_3x3_10.Size = new Size(100, 100);
            light_3x3_10.State = LightState.Off;
            light_3x3_10.TabIndex = 3;
            light_3x3_10.UseVisualStyleBackColor = true;
            light_3x3_10.Click += Light_Click;
            // 
            // light_3x3_02
            // 
            light_3x3_02.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_02.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_02.FlatAppearance.BorderSize = 0;
            light_3x3_02.FlatStyle = FlatStyle.Flat;
            light_3x3_02.index = 2;
            light_3x3_02.Location = new Point(207, 10);
            light_3x3_02.Name = "light_3x3_02";
            light_3x3_02.OffButton = Properties.Resources.ButtonOff;
            light_3x3_02.OnButton = Properties.Resources.ButtonOn;
            light_3x3_02.Size = new Size(100, 100);
            light_3x3_02.State = LightState.Off;
            light_3x3_02.TabIndex = 2;
            light_3x3_02.UseVisualStyleBackColor = true;
            light_3x3_02.Click += Light_Click;
            // 
            // light_3x3_01
            // 
            light_3x3_01.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_01.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_01.FlatAppearance.BorderSize = 0;
            light_3x3_01.FlatStyle = FlatStyle.Flat;
            light_3x3_01.index = 1;
            light_3x3_01.Location = new Point(106, 10);
            light_3x3_01.Name = "light_3x3_01";
            light_3x3_01.OffButton = Properties.Resources.ButtonOff;
            light_3x3_01.OnButton = Properties.Resources.ButtonOn;
            light_3x3_01.Size = new Size(100, 100);
            light_3x3_01.State = LightState.Off;
            light_3x3_01.TabIndex = 1;
            light_3x3_01.UseVisualStyleBackColor = true;
            light_3x3_01.Click += Light_Click;
            // 
            // light_3x3_00
            // 
            light_3x3_00.BackgroundImage = Properties.Resources.ButtonOn;
            light_3x3_00.BackgroundImageLayout = ImageLayout.Stretch;
            light_3x3_00.FlatAppearance.BorderSize = 0;
            light_3x3_00.FlatStyle = FlatStyle.Flat;
            light_3x3_00.index = 0;
            light_3x3_00.Location = new Point(5, 10);
            light_3x3_00.Name = "light_3x3_00";
            light_3x3_00.OffButton = Properties.Resources.ButtonOff;
            light_3x3_00.OnButton = Properties.Resources.ButtonOn;
            light_3x3_00.Size = new Size(100, 100);
            light_3x3_00.State = LightState.Off;
            light_3x3_00.TabIndex = 0;
            light_3x3_00.UseVisualStyleBackColor = true;
            light_3x3_00.Click += Light_Click;
            // 
            // Board
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.Board;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(659, 411);
            Controls.Add(gbxGameBoard_3x3);
            Controls.Add(bgxDebug);
            Controls.Add(gbxStats);
            Controls.Add(gbxGameBoard_4x4);
            Controls.Add(pbxWinImage);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "Board";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Lights Out";
            KeyPress += ShowHideDebug_Click;
            gbxGameBoard_4x4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxWinImage).EndInit();
            gbxStats.ResumeLayout(false);
            gbxStats.PerformLayout();
            bgxDebug.ResumeLayout(false);
            bgxDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMinMoves).EndInit();
            gbxGameBoard_3x3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pbxWinImage;
        
        private GroupBox gbxGameBoard_4x4;
        private Light light_4x4_00;
        private Light light_4x4_01;
        private Light light_4x4_02;
        private Light light_4x4_03;
        private Light light_4x4_10;
        private Light light_4x4_11;
        private Light light_4x4_12;
        private Light light_4x4_13;
        private Light light_4x4_20;
        private Light light_4x4_21;
        private Light light_4x4_22;
        private Light light_4x4_23;
        private Light light_4x4_30;
        private Light light_4x4_31;
        private Light light_4x4_32;
        private Light light_4x4_33;

        private GroupBox gbxStats;
        private Label lblSizeLabel;
        private Label lblSize;
        private Label lblGoalLabel;
        private Label lblGoal;
        private Label lblMovesLabel;
        private Label lblMoves;

        private GroupBox bgxDebug;
        private Button btnSolveOne;
        private Button btnSolveAll;
        private Button btnGenerateRandom;
        private Button btnLoad;
        private Button btnSaveLevel;
        private ComboBox cbxLevelSelect;
        private Label lblLog;
        
        private GroupBox gbxGameBoard_3x3;
        private Light light_3x3_22;
        private Light light_3x3_21;
        private Light light_3x3_20;
        private Light light_3x3_12;
        private Light light_3x3_11;
        private Light light_3x3_10;
        private Light light_3x3_02;
        private Light light_3x3_01;
        private Light light_3x3_00;
        private RadioButton rb4x4;
        private RadioButton rb3x3;
        private RadioButton rb5x5;
        private Label lblMinMovesInput;
        private NumericUpDown numMinMoves;
    }
}
