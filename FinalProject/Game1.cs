using FinalProject.Managers;
using FinalProject.Models;
using FinalProject.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace FinalProject
{
    public class Game1 : Game
    {
        // Defining variables to use later
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public Texture2D _actionBackground;
        public Texture2D _startBackground;
        public SpriteFont _font;

        // defining all the scenes to be used
        private GameScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private ScoreScene scoreScene;
        private CreditScene creditScene;
        private NameScene nameScene;

        // making a texture for the mouseCrosshair
        private static Texture2D mouseCrosshair = Shared.Content.Load<Texture2D>("images/Crosshair");

        /// <summary>
        /// general constructor for Game1
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// this method is used to initalize values needed later 
        /// </summary>
        protected override void Initialize()
        {
            // setting the boundaries of the game
            Shared.Boundaries = new Point(1600, 900);

            // setting the bounds to our shared vars
            _graphics.PreferredBackBufferWidth = Shared.Boundaries.X;
            _graphics.PreferredBackBufferHeight = Shared.Boundaries.Y;
            _graphics.ApplyChanges();

            // setting the shared content to the content, to have easy access to it
            Shared.Content = Content;

            base.Initialize();
        }

        /// <summary>
        /// this method is used to hide all the scenes from the menu
        /// </summary>
        private void HideAllScenes()
        {
            foreach (GameComponent gameComponent in Components)
            {
                if (gameComponent is GameScene)
                {
                    GameScene scene = (GameScene)gameComponent;
                    scene.hide();
                }
            }
        }

        /// <summary>
        /// This is to load all content need
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // setting shared spritebatch to the current spritebatch
            Shared.SpriteBatch = _spriteBatch;

            // getting the starting background
            _startBackground = Shared.Content.Load<Texture2D>("backgrounds/StartScreen");

            // getting the starting font
            _font = Shared.Content.Load<SpriteFont>("fonts/startFont");

            // setting up the start scene and showing it
            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            // setting up the name scene
            nameScene = new NameScene(this);
            this.Components.Add(nameScene);

            // setting up the help scene
            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            // setting up the action scene
            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            // setting up the score scene
            scoreScene = new ScoreScene(this);
            this.Components.Add(scoreScene);

            // setting up the credit scene
            creditScene = new CreditScene(this);
            this.Components.Add(creditScene);

            // creating the background music
            Song menuMusic = this.Content.Load<Song>("sounds/menu_music");

            // playing the background music
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(menuMusic);

            // setting the mouse cursor to be the crosshair
            Mouse.SetCursor(MouseCursor.FromTexture2D(mouseCrosshair, 24, 24));

        }

        /// <summary>
        /// update method
        /// </summary>
        /// <param name="gameTime">Passing in the game time fuction</param>
        protected override void Update(GameTime gameTime)
        {
            // calling the shared update method
            // this initalizes the game and sets the totalseconds to start running
            Shared.Update(gameTime);

            int selectedIndex;

            // getting the keyboard state for the user
            KeyboardState ks = Keyboard.GetState();

            // if the user is on the start scene
            if (startScene.Enabled)
            {
                // getting the current selected index from the menu components class
                selectedIndex = MenuComponent.selectedIndex;

                // if they select action scene
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    actionScene.show();
                }
                // if they select name scene
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    nameScene.show();
                }
                // if they select help scene
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    helpScene.show();
                }
                // if they select score scene
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    scoreScene.show();
                }
                // if they select credit scene
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {   
                    HideAllScenes();
                    creditScene.show();
                }
                // if they select exit
                else if (selectedIndex == 5 && ks.IsKeyDown(Keys.Enter))
                {
                    this.Exit();
                }
            }

            // checking if any of the scenes are enabled 
            if (helpScene.Enabled || actionScene.Enabled || scoreScene.Enabled || creditScene.Enabled || nameScene.Enabled)
            {
                // checking the users key presses for them to press esc
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.show();
                }
            }

            // if on the name scene
            if (nameScene.Enabled)
            {
                // calling the update method from the name scene
                nameScene.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="gameTime">Pass in gametime object</param>
        protected override void Draw(GameTime gameTime)
        {
            // drawing using shared spritebatch
            Shared.SpriteBatch.Begin();
            
            // draw the background for the startscene
            Shared.SpriteBatch.Draw(_startBackground, Vector2.Zero, Color.White);
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}