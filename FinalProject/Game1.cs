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
using System.Windows.Forms.VisualStyles;

namespace FinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public Texture2D _actionBackground;
        public Texture2D _startBackground;
        public SpriteFont _font;

        private GameScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private ScoreScene scoreScene;
        private CreditScene creditScene;
        private NameScene nameScene;

        private static Texture2D mouseCrosshair = Shared.Content.Load<Texture2D>("images/Crosshair");

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.Boundaries = new Point(1600, 900);
            _graphics.PreferredBackBufferWidth = Shared.Boundaries.X;
            _graphics.PreferredBackBufferHeight = Shared.Boundaries.Y;
            _graphics.ApplyChanges();
            Shared.Content = Content;

            base.Initialize();
        }

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


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            Shared.SpriteBatch = _spriteBatch;
            _startBackground = this.Content.Load<Texture2D>("backgrounds/StartScreen");
            _font = Shared.Content.Load<SpriteFont>("fonts/startFont");

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            nameScene = new NameScene(this);
            this.Components.Add(nameScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            scoreScene = new ScoreScene(this);
            this.Components.Add(scoreScene);

            creditScene = new CreditScene(this);
            this.Components.Add(creditScene);

            Song menuMusic = this.Content.Load<Song>("sounds/menu_music");

            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(menuMusic);

            Mouse.SetCursor(MouseCursor.FromTexture2D(mouseCrosshair, 24, 24));

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            Shared.Update(gameTime);

            int selectedIndex;

            KeyboardState ks = Keyboard.GetState();
            if (startScene.Enabled)
            {
                selectedIndex = MenuComponent.selectedIndex;

                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    actionScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    nameScene.show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    helpScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    scoreScene.show();
                }
                else if(selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {   
                    HideAllScenes();
                    creditScene.show();
                }
                else if (selectedIndex == 5 && ks.IsKeyDown(Keys.Enter))
                {
                    this.Exit();
                }
            }
            if (helpScene.Enabled || actionScene.Enabled || scoreScene.Enabled || creditScene.Enabled || nameScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.show();
                }
            }

            if (nameScene.Enabled)
            {
                nameScene.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            Shared.SpriteBatch.Begin();
            Shared.SpriteBatch.Draw(_startBackground, Vector2.Zero, Color.White);
            Shared.SpriteBatch.DrawString(_font, "", new Vector2(1300, 650), Color.Red);
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}