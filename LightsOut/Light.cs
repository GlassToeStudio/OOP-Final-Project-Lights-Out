namespace LightsOut
{
    /// <summary>
    /// A subcalss of Button. Used as the main game piece in Lights Out game. 
    /// </summary>
    public class Light : Button
    {
        /// <summary>Used to indicate this <seealso cref="Light"/>'s index when stored in the <seealso cref="LevelData.Board"/>'s array.</summary>
        public int index { get; set; }
        /// <summary>Indicate whether this <seealso cref="Light"/> is On or Off.</summary>
        public LightState State { get; set; }
        /// <summary>Image displayed for this <seealso cref="Light"/> when it is in<seealso cref="LightState.Off"/></summary>
        public Image? OffButton { get; set; }
        /// <summary>Image displayed for this <seealso cref="Light"/> when it is in<seealso cref="LightState.On"/></summary>
        public Image? OnButton { get; set; }
        /// <summary>List to hold each <seealso cref="Light"/> that is directly touching from one of each cardinal directions. 
        /// See also: <seealso cref="AddNeighbor(Light)"/></summary>
        public List<Light> Neighbors { get; private set; } = [];

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Light() { if (DesignMode) { return; } Init(TabIndex); } // Light controls were always deleted when editing main form.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public void Init(int i)
        {
           Neighbors.Clear();
           index = i;
           TurnOff();
            this.Enabled = true;
        }

        /// <summary>
        /// Add the neighboring <seealso cref="Light"/>s to a List.
        /// <para/>When this <seealso cref="Light"/> is clicked its <seealso cref="State"/> is changed and so are its <seealso cref="Neighbors"/>.
        /// <para/><seealso cref="Neighbors"/> are those <seealso cref="Light"/>s touching in each cardinal direction.
        /// <code>
        /// Ex:        
        ///     • n L n
        ///     • • n •
        ///     • • • •
        ///     • • • •
        /// </code>
        /// Diagonal <seealso cref="Light"/>s are not neighbors.
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
        /// Toggle <seealso cref="LightState"/> from <seealso cref="LightState.On"/> to <seealso cref="LightState.Off"/> or vice versa depending on current <seealso cref="State"/>.
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
        /// Click the <seealso cref="Light"/> to change its <seealso cref="State"/> and its <seealso cref="Neighbors"/> <seealso cref="State"/>.
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
        /// Change the <seealso cref="State"/> to <seealso cref="LightState.On"/> and set the <seealso cref="Light"/>'sBackgroundImage to <seealso cref="OnButton"/> .
        /// </summary>
        public void TurnOn()
        {
            State = LightState.On;
            BackgroundImage = OnButton;
        }

        /// <summary>
        /// Change the <seealso cref="State"/> to <seealso cref="LightState.Off"/> and set the <seealso cref="Light"/>'s BackgroundImage to <seealso cref="OffButton"/> .
        /// </summary>
        public void TurnOff()
        {
            State = LightState.Off;
            BackgroundImage = OffButton;
        }
    }
}