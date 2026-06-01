// The template class for a state in the game.
// A state is a different scene.

/*
 * Templates:
 * 
 * To Update:
 * public override void Update(GameTime gameTime)
 * 
 * To Draw:
 * public override void OnDraw(SpriteBatch spriteBatch)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoulCatcher.Source.Graphics;
using SoulCatcher.Source.Objects;

namespace SoulCatcher.Source.States
{
    internal class State
    {
        public GraphicsDeviceManager graphics = MainGame.publicGraphics;
        public GraphicsDevice graphicsDevice = MainGame.publicGraphicsDevice;

        // State variables
        public Main main;

        public KeyboardState keyboard, previousKeyboard;

        public int screenWidth, screenHeight;
        public Camera cam;

        // Pausing
        public bool canPause = true;
        private StaticSprite pauseBG;

        public State()
        {
            // Set Camera
            cam = new Camera(this.graphicsDevice, Global.windowWidth, Global.windowHeight);

            // Set Pause Overlay
            pauseBG = new StaticSprite(Global.noImg, new Rectangle(0, 0, Global.windowWidth, Global.windowHeight), (Color.Black * 0.5f));
        }

        public void Update(GameTime gameTime, Main main)
        {
            // Update state variables
            this.main = main;
            screenWidth = graphicsDevice.PresentationParameters.Bounds.Width;
            screenHeight = graphicsDevice.PresentationParameters.Bounds.Height;

            // Set Controls
            keyboard = Keyboard.GetState();

            // Override Update
            OnUpdate(gameTime, main);

            // Update Controls
            previousKeyboard = keyboard;
        }

        /// <summary>
        /// Add your update code for your state in this method!
        /// </summary>
        /// <param name="gameTime">The GameTime used for each frame updated.</param>
        public virtual void OnUpdate(GameTime gameTime, Main main)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Run Override Draw Method
            OnDraw(spriteBatch);

            // Pause Overlay
            if (Global.paused)
            {
                pauseBG.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// The method to override when drawing in the state.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used in Draw.</param>
        public virtual void OnDraw(SpriteBatch spriteBatch)
        {
        }

        // State Management

        /// <summary>
        /// Switches the current state to another.
        /// </summary>
        /// <param name="newState">The new state to switch to.</param>
        public void SwitchState(State newState)
        {
            main.currentState = newState;
        }

        /// <summary>
        /// Switches the current state to another.
        /// </summary>
        /// <param name="newState">The new state to switch to.</param>
        /// <param name="entry">The entry condition for the new state.</param>
        public void SwitchState(State newState, bool entry)
        {
            if (entry) main.currentState = newState;
        }

        // Controls

        public bool KeyPress(Keys key)
        {
            if (keyboard.IsKeyUp(key) && previousKeyboard.IsKeyDown(key))
            {
                return true;
            }
            else return false;
        }

        public bool KeyDown(Keys key)
        {
            if (keyboard.IsKeyDown(key))
            {
                return true;
            }
            else return false;
        }

        public bool KeyUp(Keys key)
        {
            if (keyboard.IsKeyUp(key))
            {
                return true;
            }
            else return false;
        }
    }
}
