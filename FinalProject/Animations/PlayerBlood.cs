/*
 * InputManager.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.12.4: Created
 *      Blake Power, 2022.12.4: Added code
 *      Blake Power, 2022.12.11: Comments added
 */
 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Animations
{
    public class PlayerBlood : DrawableGameComponent
    {
        // defining a bunch of variables to be used in the animation
        private Texture2D tex;
        private Vector2 dimention;
        private Vector2 position;
        private List<Rectangle> frames;
        private int frameIndex = -1;
        private int delay;
        private int delayCounter;

        // defining const vars for the number of rows and cols for spritesheet
        private const int ROWS = 4;
        private const int COLUMNS = 4;

        /// <summary>
        /// constuctor for the PlayerBlood animation
        /// </summary>
        /// <param name="game">passing in a game inst</param>
        /// <param name="spriteBatch">a sprite batch</param>
        /// <param name="tex">a texture</param>
        /// <param name="position">a position</param>
        /// <param name="delay">a delay for the animation</param>
        public PlayerBlood(Game game, SpriteBatch spriteBatch, Texture2D tex,
            Vector2 position, int delay) : base(game)
        {
            // setting properties
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
            // creating a list of frames, type rectangle
            frames = new List<Rectangle>();
            // having a for loop to loop for all the rows
            for (int i = 0; i < ROWS; i++)
            {
                // having a for loop to loop for all the cols
                for (int j = 0; j < COLUMNS; j++)
                {
                    // setting the dimetion to get the right area for each frame
                    int x = j * (int)dimention.X;

                    // setting the dimetion to get the right area for each frame
                    int y = i * (int)dimention.Y;

                    // creating a new rectangle variable to set for each animation frame
                    Rectangle r = new Rectangle(x, y, (int)dimention.X, (int)dimention.Y);

                    // adding it to the list of rectangle frames
                    frames.Add(r);
                }
            }
        }

        /// <summary>
        /// method to show the animation
        /// </summary>
        private void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }


        /// <summary>
        /// method to hide animation frames
        /// </summary>
        public void Hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        /// <summary>
        /// this is to restart the animation
        /// </summary>
        public void restart()
        {
            // setting frame index back to -1
            frameIndex = -1;

            // reseting delay counter
            delayCounter = 0;
            Show();
        }

        /// <summary>
        /// override update fuction
        /// </summary>
        /// <param name="gameTime">taking a gametime object</param>
        public override void Update(GameTime gameTime)
        {
            // adding to the delay counter
            delayCounter++;

            // checking to see if the delay counter is more then the delay,
            // this is to know how long to display each frame for
            if (delayCounter > delay)
            {
                // adding to frame index
                frameIndex++;

                // checking to see if the frameindex is still withing the bounds of the rows * cols - 1
                if (frameIndex > ROWS * COLUMNS - 1)
                {
                    // hide the animation
                    Hide();

                    // reset the frameindex back to -1
                    frameIndex = -1;
                }
                delayCounter = 0;
            }

            base.Update(gameTime);

        }

        /// <summary>
        /// override for draw
        /// </summary>
        /// <param name="gameTime">passing in a gametime object </param>
        public override void Draw(GameTime gameTime)
        {
            // drawing using shared spritebatch
            Shared.SpriteBatch.Begin();

            // if the frame index is greater than or = to 0
            if (frameIndex >= 0)
            {
                // draw the frames of the animation
                Shared.SpriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
            }
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
