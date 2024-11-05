namespace LightsOut
{
    /// <summary>
    /// 
    /// </summary>
    partial class Board
    {
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
    }
}
