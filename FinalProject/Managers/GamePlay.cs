using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Animations;
using FinalProject.Managers;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    /// <summary>
    /// This class is used to reset the game, creates an instance of GameManager, and a virtual 
    /// resetworld method to pass a null object to the delegate, to reset the game
    /// </summary>
    public class GamePlay
    {
        // creating GameManager variable
        GameManager gameManager;

        /// <summary>
        /// General Consructor
        /// </summary>
        public GamePlay()
        {
            // calling the method, and passing in null
            ResetWorld(null);
        }

        /// <summary>
        /// update method to be called in the actionscene
        /// </summary>
        public virtual void Update()
        {
            // calling the GameManagers update method
            gameManager.Update();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">passing object</param>
        public virtual void ResetWorld(object data)
        {
            // setting new instance of GameManager and passing in delegate
            gameManager = new GameManager(ResetWorld);
        }

        /// <summary>
        /// Draw method to be called in the actionscene
        /// </summary>
        public virtual void Draw()
        {
            // calling GameManagers draw method
            gameManager.Draw();
        }
    }
}
