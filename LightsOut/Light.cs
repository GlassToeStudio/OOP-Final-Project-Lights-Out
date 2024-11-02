namespace LightsOut
{
    internal class Light : Button
    {
        internal int index;
        internal LightState State;
        internal Image? OffButton { get; private set; }
        internal Image? OnButton { get; private set; }
        internal List<Light> Neighbors { get; private set; } = [];

        internal Light() { }

        internal void SetButtons(Image? offButton, Image? onButton)
        {
            OnButton = onButton;
            OffButton = offButton;
        }

        internal void AddNeighbor(Light light)
        {
            if (!Neighbors.Contains(light))
            {
                Neighbors.Add(light);
            }
        }

        internal int ToggleState()
        {
            if (State == LightState.On)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }

            return (int)State;
        }

        internal void ClickLight()
        {
            ToggleState();
            foreach (var neighbor in Neighbors)
            {
                neighbor.ToggleState();
            }
        }

        internal void TurnOn()
        {
            State = LightState.On;
            BackgroundImage = OnButton;
        }

        internal void TurnOff()
        {
            State = LightState.Off;
            BackgroundImage = OffButton;
        }
    }
}