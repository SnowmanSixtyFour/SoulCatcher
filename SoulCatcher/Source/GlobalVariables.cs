using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SoulCatcher.Source.Objects.GUI.Dialog;

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
            // Utilities
            noImg,

            // GUI
            dialogBox,
            
            // Overworld
            player;
        public static SpriteFont arial;
        public static Effect crt;

        // Load game assets
        public static void LoadContent(ContentManager content)
        {
            // Images

            // Utilities
            Global.noImg = content.Load<Texture2D>("Assets/Images/pixel");

            // GUI
            Global.dialogBox = content.Load<Texture2D>("Assets/Images/pixel");

            // Overworld
            Global.player = content.Load<Texture2D>("Assets/Images/Overworld/Player");

            // Fonts

            Global.arial = content.Load<SpriteFont>("Assets/Fonts/Arial");

            // Shaders

            Global.crt = content.Load<Effect>("Assets/Shaders/CRTFilter");
        }
    }

    internal class DialogVar
    {
        // Text IDs
        internal static readonly int
            noName = -1;
        internal static readonly byte
            innerThought = 1,
            tutorial = 2,
            important = 3;

        // Character IDs
        internal static readonly int
            protagonist = 0,
            rival = 1,
            professor = 2;

        // Dialog
        public static DialogString[]
            intro;

        public static void LoadDialog()
        {
            // Intro
            DialogVar.intro = new DialogString[]
            {
                new DialogString(professor, "Welcome to Soul Catcher!", hideName: true)
            };
        }

        // Create Dialog String
        public static DialogString Line(int name, string text, int textColor = 0, int state = 0, bool hideName = false)
        {
            return new DialogString(name, text, textColor, state, hideName);
        }
    }
}
