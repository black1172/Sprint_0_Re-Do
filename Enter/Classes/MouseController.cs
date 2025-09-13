using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MouseController
{
    public class MouseController : IController
    {
        public void Update(Game1 game, IPlayer player)
        {
            // Get the current state of mouse input.
            MouseState mouseState = Mouse.GetState();

            // Check if the left mouse button is pressed down.
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // The left button is down, so do something.
            }
        }
    }
}
