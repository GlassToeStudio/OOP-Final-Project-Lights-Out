namespace LightsOut
{
    /// <summary>
    /// A subcalss of Button. Used as the main game piece in Lights Out game. 
    /// </summary>
    internal class Light : Button
    {
        /// <summary>Used to indicate this <seealso cref="Light"/>'s index when stored in the <seealso cref="LevelData.Board"/>'s array.</summary>
        internal int index;
        /// <summary>Indicate whether this <seealso cref="Light"/> is On or Off.</summary>
        internal LightState State;
        /// <summary>Image displayed for this <seealso cref="Light"/> when it is in<seealso cref="LightState.Off"/></summary>
        internal Image? OffButton { get; private set; }
        /// <summary>Image displayed for this <seealso cref="Light"/> when it is in<seealso cref="LightState.On"/></summary>
        internal Image? OnButton { get; private set; }
        /// <summary>List to hold each <seealso cref="Light"/> that is directly touching from one of each cardinal directions. 
        /// See also: <seealso cref="AddNeighbor(Light)"/></summary>
        internal List<Light> Neighbors { get; private set; } = [];

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal Light() { }

        /// <summary>
        /// Sets the two BackgroundImages used for displaying if the <seealso cref="Light"/> is On or Off.
        /// </summary>
        /// <param name="onButton">Image displayed when Light is On</param>
        /// <param name="offButton">Image displayed when Light is Off</param>
        internal void SetButtons(Image? onButton, Image? offButton)
        {
            OnButton = onButton;
            OffButton = offButton;
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
        internal void AddNeighbor(Light light)
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

        /// <summary>
        /// Click the <seealso cref="Light"/> to change its <seealso cref="State"/> and its <seealso cref="Neighbors"/> <seealso cref="State"/>.
        /// </summary>
        internal void ClickLight()
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
        internal void TurnOn()
        {
            State = LightState.On;
            BackgroundImage = OnButton;
        }

        /// <summary>
        /// Change the <seealso cref="State"/> to <seealso cref="LightState.Off"/> and set the <seealso cref="Light"/>'s BackgroundImage to <seealso cref="OffButton"/> .
        /// </summary>
        internal void TurnOff()
        {
            State = LightState.Off;
            BackgroundImage = OffButton;
        }
    }
}