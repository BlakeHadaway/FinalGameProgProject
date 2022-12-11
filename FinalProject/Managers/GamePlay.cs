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
    public class GamePlay
    {

        GameManager gameManager;

        public GamePlay()
        {
            ResetWorld(null);
        }

        public virtual void Update()
        {
            if (true)
            {
                gameManager.Update();
            }
        }

        public virtual void ResetWorld(object data)
        {
            gameManager = new GameManager(ResetWorld);
        }

        public virtual void Draw()
        {
            if (true)
            {
                gameManager.Draw();
            }
        }
    }
}
