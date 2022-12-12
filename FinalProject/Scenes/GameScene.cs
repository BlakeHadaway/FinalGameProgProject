/*
 * GameScene.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.11.30: Created
 *      Blake Power, 2022.11.30: Added code
 *      Blake Power, 2022.12.11: Comments added
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public abstract class GameScene : DrawableGameComponent
    {
        // list of game components
        public List<GameComponent> Components { get; set; }

        //show method
        public virtual void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        //hide method 
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        /// <summary>
        /// Start by hiding all things in the gamecomponent list and initialize the components
        /// </summary>
        /// <param name="game">passing in game</param>
        protected GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            hide();
        }

        /// <summary>
        /// draw all the gamecompenents 
        /// </summary>
        /// <param name="gameTime">passing in gametime</param>
        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent item in Components)
            {
                if (item is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// When an item is enabled in the menu, update to show it 
        /// </summary>
        /// <param name="gameTime">passing in gametime</param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in Components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }



            base.Update(gameTime);
        }
    }
}
