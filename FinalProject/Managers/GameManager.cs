using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Animations;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    public class GameManager
    {
        private Player _player;
        private readonly Color red = Color.Red;
        
        public Delegate ResetGame { get; set; }
        
        public GameManager(Delegate RESETWORLD)
        {
            ResetGame = RESETWORLD;
            _player = new(Shared.Content.Load<Texture2D>("images/player"), new(Shared.Boundaries.X / 2, Shared.Boundaries.Y / 2));
            ProjectileManager.Initial();
            ZombieManager.Initial();
            ZombieManager.AddZombieToBattleField();
        }

        public Player Initialize(Player player)
        {
            player = new(Shared.Content.Load<Texture2D>("images/player"), new Vector2(Shared.Boundaries.X / 2, Shared.Boundaries.Y / 2));

            return player; 
        }

        public void ResetMatch()
        {
            ResetGame = null;
            _player = Initialize(_player);
            ZombieManager.HordeOfZombies.Clear();
            ProjectileManager.Projectiles.Clear();
            Shared.Score = 0;
            Shared.scrollIndex = 0;
            Shared.zombieSpawnRate = 0.80f;
            Player.SMGUnlocked = false;
            Player.SniperUnlocked = false;
            Player.LMGUnlocked = false;
            _player.NumberOfLives = 1;
            _player._dead = false;

        }

        public void Update()
        {

            if (!_player._dead)
            {
                InputManager.Update();
                _player.Update();
                ZombieManager.Update(_player);
                ProjectileManager.Update(ZombieManager.HordeOfZombies);
                CollisionManager.Update(_player, ZombieManager.HordeOfZombies);
            }
            else
            {
                KeyboardState ks = Keyboard.GetState();

                if (ks.IsKeyDown(Keys.R))
                {
                    ResetMatch();
                }
            }
        }

        public void Draw()
        {
            ProjectileManager.Draw();
            if (_player.Invincibility == true)
            {
                _player.Draw(red);
            }
            else
            {
                _player.Draw(Shared.White);
            }
            
            ZombieManager.draw();
            UIManager.Draw(_player);
        }
    }
}
