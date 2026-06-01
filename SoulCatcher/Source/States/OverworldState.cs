// The overworld state of the game, featuring the traversable map and player.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoulCatcher.Source.Graphics;
using SoulCatcher.Source.Objects.State;
using System;

namespace SoulCatcher.Source.States
{
    internal class OverworldState : State
    {
        Character player;
        Text debug;

        // Movement Variables
        private int movementSpeed = 4;

        public OverworldState()
        {
            // Character
            player = new Character(Global.player, new Point(10, 200), new Point(544, 32), new Point(32, 32), Color.White);
            player.SetSize(2);

            player.CreateAnimation("walkDown", 0, 3);
            player.CreateAnimation("walkUp", 4, 7);
            player.CreateAnimation("walkLeft", 8, 11);
            player.CreateAnimation("walkRight", 12, 15);

            debug = new Text(Global.arial, "", new Vector2(10, 10), Color.White, 1.0f);
        }

        public override void OnUpdate(GameTime gameTime, Main main)
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
                int newX = 0;
                int newY = 0;

                // Update New Positions
                if (KeyDown(Keys.Left))
                {
                    newX--;
                }

                if (KeyDown(Keys.Right))
                {
                    newX++;
                }

                if (KeyDown(Keys.Up))
                {
                    newY--;
                }

                if (KeyDown(Keys.Down))
                {
                    newY++;
                }

                // Prevent Diagonal Movement
                if (Global.movementType == Global.MovementType.Default)
                {
                    if (newX != 0) newY = 0;
                    if (newY != 0) newX = 0;
                }

                // Prevent moving both ways at once
                if (KeyDown(Keys.Left) && KeyDown(Keys.Right)) newX = 0;
                if (KeyDown(Keys.Up) && KeyDown(Keys.Down)) newY = 0;

                // Update Player Position
                player.X += newX * movementSpeed;
                player.Y += newY * movementSpeed;

                // Char Animations
                if (!KeyDown(Keys.Left) // Idle
                    && !KeyDown(Keys.Right)
                    && !KeyDown(Keys.Up)
                    && !KeyDown(Keys.Down)
                    || newX == 0 && newY == 0)
                {
                    player.ResetAnimation();
                }
                else // Walking
                {
                    if (KeyDown(Keys.Left))
                    {
                        player.PlayAnimation("walkLeft");
                    }
                    else if (KeyDown(Keys.Right))
                    {
                        player.PlayAnimation("walkRight");
                    }
                    else if (KeyDown(Keys.Up))
                    {
                        player.PlayAnimation("walkUp");
                    }
                    else if (KeyDown(Keys.Down))
                    {
                        player.PlayAnimation("walkDown");
                    }
                }

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
