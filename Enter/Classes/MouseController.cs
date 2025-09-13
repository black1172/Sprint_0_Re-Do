using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MouseController
{
    public class MouseController
    {
        public void Update(Game1 game)
        {
            // Get the current state of mouse input.
            MouseState mouseState = Mouse.GetState();

            // Get location of click
            Point mousePosition = new Point(mouseState.X, mouseState.Y);

            // Check if the left mouse button is pressed down.
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // same as num pad 1
            }

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                // same as num pad 2
            }

            // Code if clicked in bottom left corner of window (1280x720)
            if ((mouseState.LeftButton == ButtonState.Pressed) && (mousePosition.X < 640 && mousePosition.Y > 360))
            {
                // same as num pad 3
            }

            // Code if clicked in bottom right corner of window (1280x720)
            if ((mouseState.RightButton == ButtonState.Pressed) && (mousePosition.X > 640 && mousePosition.Y > 360))
            {
                // same as num pad 4
            }
        }
    }
}
