// The overworld state of the game, featuring the traversable map and player.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoulCatcher.Source.Graphics;
using SoulCatcher.Source.Objects.State.Overworld;

namespace SoulCatcher.Source.States
{
    internal class OverworldState : State
    {
        private Player player;
        private Text debug;

        public OverworldState()
        {
            player = new Player();
            player.SetPosition(400, 200);

            debug = new Text(Global.arial, "", new Vector2(10, 10), Color.White, 1.0f);
        }

        public override void OnUpdate(GameTime gameTime, Main main)
        {
            // While Unpaused
            if (!Global.paused)
            {
                // Text
                debug.setText("X: " + player.character.X
                    + "\nY: " + player.character.Y
                    + "\nWidth: " + player.character.Width
                    + "\nHeight: " + player.character.Height);

                player.Update(gameTime, this);

                // Toggle Filter
                if (KeyPress(Keys.Enter))
                {
                    Global.crtFilterEnabled = !Global.crtFilterEnabled;
                }
            }

            SwitchState(main.battle, KeyPress(Keys.Space));
        }

        public override void OnDraw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);

            debug.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
