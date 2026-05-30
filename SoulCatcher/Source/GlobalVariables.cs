using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SoulCatcher.Source
{
    internal class Global
    {
        // Window

        public static string windowName = "Soul Catcher";

        public static int
            windowWidth = 844,
            windowHeight = 480;

        public static bool active = true;

        // Settings

        // When Inactive
        public static bool
            renderInactive = true,
            pauseWhenInactive = true;

        // Mouse
        public static float
            mouseDeltaMax = 6,
            mouseSensitivity = 0.1f;

        // Game

        public static string gameVersion = "Major Jam 8 Edition";

        public static bool
            paused = false,
            mouseVisible = false;

        // Game Options

        public enum MovementType
        {
            Default,        // 4 Directions
            Free            // Free Movement
        }

        // Player Movement Type
        public static MovementType movementType = MovementType.Default;

        // Graphics

        public static bool crtFilterEnabled = false;

        // Sprites

        public static Texture2D
            noImg,
            player;
        public static SpriteFont arial;
        public static Effect crt;

        // Load game assets
        public static void LoadContent(ContentManager content)
        {
            // Images

            Global.noImg = content.Load<Texture2D>("Assets/Images/pixel");

            Global.player = content.Load<Texture2D>("Assets/Images/Overworld/Player");

            // Fonts

            Global.arial = content.Load<SpriteFont>("Assets/Fonts/Arial");

            // Shaders

            Global.crt = content.Load<Effect>("Assets/Shaders/CRTFilter");
        }
    }
}
