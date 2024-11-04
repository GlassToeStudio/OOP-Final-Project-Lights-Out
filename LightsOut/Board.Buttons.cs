using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
#if DEBUG
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
#endif
    }
}
