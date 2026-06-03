using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoulCatcher.Source.States;

namespace SoulCatcher.Source.Objects.State.Overworld
{
    internal class Player
    {
        // Customizable Variables

        public static string playerName = "Player";

        public int movementSpeed = 4;

        // Default Variables

        public Character character;

        public Player()
        {
            // Set Character
            character = new Character(Global.player, new Point(400, 200), new Point(544, 32), new Point(32, 32), Color.White);
            character.SetSize(2);

            // Set Animations
            character.CreateAnimation("walkDown", 0, 3);
            character.CreateAnimation("walkUp", 4, 7);
            character.CreateAnimation("walkLeft", 8, 11);
            character.CreateAnimation("walkRight", 12, 15);
        }

        public void Update(GameTime gameTime, OverworldState state)
        {
            // --- MOVEMENT ---

            int newX = 0;
            int newY = 0;

            // Update New Positions
            if (state.KeyDown(Keys.Left))
            {
                newX--;
            }

            if (state.KeyDown(Keys.Right))
            {
                newX++;
            }

            if (state.KeyDown(Keys.Up))
            {
                newY--;
            }

            if (state.KeyDown(Keys.Down))
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
            if (state.KeyDown(Keys.Left) && state.KeyDown(Keys.Right)) newX = 0;
            if (state.KeyDown(Keys.Up) && state.KeyDown(Keys.Down)) newY = 0;

            // Update Player Position
            character.X += newX * movementSpeed;
            character.Y += newY * movementSpeed;

            // --- ANIMATIONS ---

            if (!state.KeyDown(Keys.Left) // Idle
                && !state.KeyDown(Keys.Right)
                && !state.KeyDown(Keys.Up)
                && !state.KeyDown(Keys.Down)
                || newX == 0 && newY == 0)
            {
                character.ResetAnimation();
            }
            else // Walking
            {
                if (state.KeyDown(Keys.Left))
                {
                    character.PlayAnimation("walkLeft");
                }
                else if (state.KeyDown(Keys.Right))
                {
                    character.PlayAnimation("walkRight");
                }
                else if (state.KeyDown(Keys.Up))
                {
                    character.PlayAnimation("walkUp");
                }
                else if (state.KeyDown(Keys.Down))
                {
                    character.PlayAnimation("walkDown");
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            character.Draw(spriteBatch);
        }

        /// <summary>
        /// Set the position of the player on the map.
        /// </summary>
        /// <param name="x">The X coordinate of the player's position.</param>
        /// <param name="y">The Y coordinate of the player's position.</param>
        public void SetPosition(int x, int y)
        {
            character.X = x;
            character.Y = y;
        }
    }
}
