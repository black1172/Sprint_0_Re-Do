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

            // Only respond to left mouse button pressed
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int width = 1280; // or get from game if dynamic
                int height = 720;
                int halfWidth = width / 2;
                int halfHeight = height / 2;

                if (mousePosition.X < halfWidth && mousePosition.Y < halfHeight)
                {
                    // Top left quarter: standing, fixed position
                    game._currentMarioState = Game1.MarioState.Standing;
                }
                else if (mousePosition.X >= halfWidth && mousePosition.Y < halfHeight)
                {
                    // Top right quarter: running, fixed position
                    game._currentMarioState = Game1.MarioState.Running;
                }
                else if (mousePosition.X < halfWidth && mousePosition.Y >= halfHeight)
                {
                    // Bottom left quarter: standing, moves up/down
                    game._currentMarioState = Game1.MarioState.StandingUpDown;
                }
                else if (mousePosition.X >= halfWidth && mousePosition.Y >= halfHeight)
                {
                    // Bottom right quarter: running, moves left/right
                    game._currentMarioState = Game1.MarioState.RunningLeftRight;
                }
            }
        }
    }
}
