using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Animations
{
    public class BloodSplat : DrawableGameComponent
    {
        private Texture2D tex;
        private Vector2 dimention;
        private Vector2 position;
        private List<Rectangle> frames;
        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        private const int ROWS = 4;
        private const int COLUMNS = 4;
        public BloodSplat(Game game, SpriteBatch spriteBatch, Texture2D tex,
            Vector2 position, int delay) : base(game)
        {
            this.position = position;
            this.delay = delay;
            this.tex = tex;
            dimention = new Vector2(tex.Width / COLUMNS, tex.Height / ROWS);

            Hide();

            // Create all frames
            createFrames();

        }

        private void createFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    int x = j * (int)dimention.X;
                    int y = i * (int)dimention.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimention.X, (int)dimention.Y);
                    frames.Add(r);
                }
            }
        }

        private void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public void restart()
        {
            frameIndex = -1;
            delayCounter = 0;
            Show();
        }

        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            { 
                frameIndex++;
                if (frameIndex > ROWS * COLUMNS - 1)
                {
                    Hide();
                    frameIndex = -1;
                }
                delayCounter = 0;
            }

            base.Update(gameTime);
            
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.SpriteBatch.Begin();
            if (frameIndex >= 0)
            {
                //v4
                Shared.SpriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
            }
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
