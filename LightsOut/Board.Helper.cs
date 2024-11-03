namespace LightsOut
{
    partial class frmLightsOut
	{
        private void GenerateGameBoard()
        {
            lights = [light_00, light_01, light_02, light_03,
                      light_10, light_11, light_12, light_13,
                      light_20, light_21, light_22, light_23,
                      light_30, light_31, light_32, light_33];

            ConnectNeighbors();
			InitializeBoardLights();
        }
        private void ConnectNeighbors()
        {
			// Connect neighbors
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
     
		private void InitializeBoardLights()
        {
            // Set On off button and index value
            for (var i = 0; i < lights.Length; i++)
            {
                lights[i].SetButtons(OnButton, OffButton);
                lights[i].index = i;
            }
        }
    }
}
