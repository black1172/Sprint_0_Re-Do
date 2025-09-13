using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KeyboardController
{
    public class KeyboardController
    {
        public void Update(Game1 game)  
        {
            // Get the current state of keyboard input.
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.NumPad0) || keyboardState.IsKeyDown(Keys.D0))
            {
                // add code here to quit the game
                game.Exit();
            }

            if (keyboardState.IsKeyDown(Keys.NumPad1) || keyboardState.IsKeyDown(Keys.D1))
            {
                // add code to draw standing mario
                game._currentMarioState = Game1.MarioState.Standing;
            }

            if (keyboardState.IsKeyDown(Keys.NumPad2) || keyboardState.IsKeyDown(Keys.Down))
            {
                // add code to draw running mario
                game._currentMarioState = Game1.MarioState.Running;
            }

            if (keyboardState.IsKeyDown(Keys.NumPad3) || keyboardState.IsKeyDown(Keys.D3))
            {
                // add code to draw standing mario moving up and down
                game._currentMarioState = Game1.MarioState.StandingUpDown;
            }

            if (keyboardState.IsKeyDown(Keys.NumPad4) || keyboardState.IsKeyDown(Keys.Left))
            {
                // add code to move mario left and right while running
                game._currentMarioState = Game1.MarioState.RunningLeftRight;
            }
        
        }
    }
}