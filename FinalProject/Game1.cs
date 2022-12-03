using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Windows.Forms.VisualStyles;

namespace FinalProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public Texture2D _background;

        private GameScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;

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
            SpriteFont font = this.Content.Load<SpriteFont>("fonts/MyFont");
            _background = this.Content.Load<Texture2D>("backgrounds/GreenBackground");

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();
            // other scenes will be instantiated here
            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Shared.Update(gameTime);

            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();
            if (startScene.Enabled)
            {
                System.Diagnostics.Debug.WriteLine(selectedIndex);

                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    actionScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    helpScene.show();
                }
            }
            if (helpScene.Enabled || actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.show();
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}