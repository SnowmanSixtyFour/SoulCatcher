// An example of using the State class, to create a level

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoulCatcher.Source.Graphics;
using SoulCatcher.Source.Objects;

namespace SoulCatcher.Source.States
{
    internal class LevelState : State
    {
        Character player;
        Text debug;

        public LevelState()
        {
            // Test Character
            player = new Character(Global.player, new Point(10, 200), new Point(544, 32), new Point(32, 32), Color.White);
            player.SetSize(2);

            // Test Create Animations
            player.CreateAnimation("idle", 0, 0);
            player.CreateAnimation("walkUp", 1, 4);
            player.CreateAnimation("walkDown", 5, 8);
            player.CreateAnimation("walkLeft", 9, 12);
            player.CreateAnimation("walkRight", 13, 16);

            debug = new Text(Global.arial, "", new Vector2(10, 10), Color.White, 1.0f);
        }

        public override void OnUpdate(GameTime gameTime)
        {
            // While Unpaused
            if (!Global.paused)
            {
                // Text
                debug.setText("X: " + player.X
                    + "\nY: " + player.Y
                    + "\nWidth: " + player.Width
                    + "\nHeight: " + player.Height);

                // Char Movement
                if (KeyDown(Keys.Left))
                {
                    player.X -= 2;
                }
                if (KeyDown(Keys.Right))
                {
                    player.X += 2;
                }
                if (KeyDown(Keys.Up))
                {
                    player.Y -= 2;
                }
                if (KeyDown(Keys.Down))
                {
                    player.Y += 2;
                }

                // Char Animations
                if (!KeyDown(Keys.Left) // Idle
                    && !KeyDown(Keys.Right)
                    && !KeyDown(Keys.Up)
                    && !KeyDown(Keys.Down))
                {
                    player.PlayAnimation("idle");
                }
                else // Walking
                {
                    if (KeyDown(Keys.Up))
                    {
                        player.PlayAnimation("walkUp");
                    }
                    else if (KeyDown(Keys.Down))
                    {
                        player.PlayAnimation("walkDown");
                    }
                    else if (KeyDown(Keys.Left))
                    {
                        player.PlayAnimation("walkLeft");
                    }
                    else if (KeyDown(Keys.Right))
                    {
                        player.PlayAnimation("walkRight");
                    }
                }

                // Toggle Filter
                if (KeyPress(Keys.Enter))
                {
                    Global.crtFilterEnabled = !Global.crtFilterEnabled;
                }
            }
        }

        public override void OnDraw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);

            debug.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
