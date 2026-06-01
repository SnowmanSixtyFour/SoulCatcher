// The battle state of the game, featuring a turn-based battle with the player and the opponent.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoulCatcher.Source.States
{
    internal class BattleState : State
    {
        public BattleState()
        {
            // Set Pausing
            canPause = false;
        }

        public override void OnUpdate(GameTime gameTime, Main main)
        {
            // WIP
        }

        public override void OnDraw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
