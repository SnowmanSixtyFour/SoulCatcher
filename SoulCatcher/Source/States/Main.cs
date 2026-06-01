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
        public State currentState;

        public OverworldState overworld;
        public BattleState battle;

        public Main()
        {
            // Set States
            overworld = new OverworldState();
            battle = new BattleState();

            // Set Current State
            currentState = overworld;
        }

        public override void OnUpdate(GameTime gameTime, Main main)
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
            currentState.Update(gameTime, this);
        }

        public override void OnDraw(SpriteBatch spriteBatch)
        {
            // Draw Current State
            currentState.OnDraw(spriteBatch);
        }
    }
}
