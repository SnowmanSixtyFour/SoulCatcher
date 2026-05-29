// The main state of the game.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoulCatcher.Source.Graphics;
using SoulCatcher.Source.Objects;

namespace SoulCatcher.Source.States
{
    internal class Main : State
    {
        private State currentState;

        private LevelState levelState;

        public Main()
        {
            // Set States
            levelState = new LevelState();

            // Set Current State
            currentState = levelState;
        }

        public override void OnUpdate(GameTime gameTime)
        {
            // Pausing
            if (canPause) // If Pausing is Possible
            {
                // Toggle Pause
                if (KeyPress(Keys.Escape))
                {
                    Global.paused = !Global.paused;
                }
            }

            // Pause Game when Inactive
            if (Global.pauseWhenInactive && !Global.active) Global.paused = true;

            // Update Current State
            currentState.Update(gameTime);
        }

        public override void OnDraw(SpriteBatch spriteBatch)
        {
            // Draw Current State
            currentState.OnDraw(spriteBatch);
        }
    }
}
