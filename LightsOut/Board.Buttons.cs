namespace LightsOut
{
    partial class frmLightsOut
    {
        private void btnLight_Click(object sender, EventArgs e)
        {
            Light? light = sender as Light;
            light?.ClickLight();

            levelData.UpdateBoard(lights);
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
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            GenerateLevelFromFile();
        }

    }
}
