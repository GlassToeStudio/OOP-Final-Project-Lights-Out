namespace LightsOut
{
    /// <summary>
    /// A subclass of Button. Used as the main game piece in Lights Out game. 
    /// </summary>
    public class Light : Button
    {
        /// <summary>Used to indicate this <see cref="Light"/>'s Index when stored in the <see cref="LevelData.Board"/>'s array.</summary>
        public int Index { get; set; }
        /// <summary>Indicate whether this <see cref="Light"/> is On or Off.</summary>
        public LightState State { get; set; }
        /// <summary>Image displayed for this <see cref="Light"/> when it is in <see cref="LightState.Off"/></summary>
        public Image? OffButton { get; set; }
        /// <summary>Image displayed for this <see cref="Light"/> when it is in <see cref="LightState.On"/></summary>
        public Image? OnButton { get; set; }
        /// <summary>List to hold each <see cref="Light"/> that is directly touching from one of each cardinal directions. 
        /// See also: <see cref="AddNeighbor(Light)"/></summary>
        public List<Light> Neighbors { get; private set; } = [];

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Light() { if (DesignMode) { return; } Init(TabIndex); } // Light controls were always deleted when editing main form.

        /// <summary>
        /// Should be called when a <see cref="Light"/> is created and when a new game board is generated.
        /// </summary>
        /// <param name="i">integer to indicate at what Index this light is in an array of lights.</param>
        public void Init(int i)
        {
           Neighbors.Clear();
           Index = i;
           TurnOff();
           this.Enabled = true;
        }

        /// <summary>
        /// Add the neighboring <see cref="Light"/>s to a List.
        /// <para/>When this <see cref="Light"/> is clicked its <see cref="State"/> is changed and so are its <see cref="Neighbors"/>.
        /// <para/><see cref="Neighbors"/> are those <see cref="Light"/>s touching in each cardinal direction.
        /// <code>
        /// Ex:
        ///     • n L n
        ///     • • n •
        ///     • • • •
        ///     • • • •
        /// </code>
        /// Diagonal <see cref="Light"/>s are not neighbors.
        /// </summary>
        /// <param name="light"></param>
        public void AddNeighbor(Light light)
        {
            if (!Neighbors.Contains(light))
            {
                Neighbors.Add(light);
            }
        }

        /// <summary>
        /// Toggle <see cref="LightState"/> from <see cref="LightState.On"/> to <see cref="LightState.Off"/> or vice versa depending on current <see cref="State"/>.
        /// </summary>
        /// <returns>0 for Off<br/> 1 for On</returns>
        public int ToggleState()
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

        /// <summary>
        /// Click the <see cref="Light"/> to change its <see cref="State"/> and its <see cref="Neighbors"/> <see cref="State"/>.
        /// </summary>
        public void ClickLight()
        {
            ToggleState();
            foreach (var neighbor in Neighbors)
            {
                neighbor.ToggleState();
            }
        }

        /// <summary>
        /// Change the <see cref="State"/> to <see cref="LightState.On"/> and set the <see cref="Light"/>'sBackgroundImage to <see cref="OnButton"/> .
        /// </summary>
        public void TurnOn()
        {
            State = LightState.On;
            BackgroundImage = OnButton;
        }

        /// <summary>
        /// Change the <see cref="State"/> to <see cref="LightState.Off"/> and set the <see cref="Light"/>'s BackgroundImage to <see cref="OffButton"/> .
        /// </summary>
        public void TurnOff()
        {
            State = LightState.Off;
            BackgroundImage = OffButton;
        }
    }
}