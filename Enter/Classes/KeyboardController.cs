using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KeyboardController
{
    public class KeyboardController : IController
    {
        public void Update(Game1 game, IPlayer player)
        {
            // Get the current state of keyboard input.
            KeyboardState keyboardState = Keyboard.GetState();

            // Check if the space key is down.
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                // The space key is down, so do something.
            }
        }
    }
}