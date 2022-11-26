using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    public class GameManager
    {
        private readonly Player _player;
        public GameManager()
        {
            ProjectileManager.Initial();
            _player = new (Shared.Content.Load<Texture2D>("images/player"), new (200, 200));
        }

        public void Update()
        {
            InputManager.Update();
            _player.Update();
            ProjectileManager.Update();
        }

        public void Draw()
        {
            ProjectileManager.Draw();
            _player.Draw();
        }
    }
}
