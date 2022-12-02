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
            _player = new (Shared.Content.Load<Texture2D>("images/player"), new (Shared.Boundaries.X / 2, Shared.Boundaries.Y / 2));
            ZombieManager.Initial();
            ZombieManager.AddZombieToBattleField();
        }

        public void Update()
        {
            InputManager.Update();
            _player.Update();
            ZombieManager.Update(_player);
            ProjectileManager.Update(ZombieManager.HordeOfZombies);
            CollisionManager.Update(_player, ZombieManager.HordeOfZombies);
        }

        public void Draw()
        {
            ProjectileManager.Draw();
            _player.Draw();
            ZombieManager.draw();
            UIManager.Draw(_player);
        }
    }
}
