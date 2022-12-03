using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Animations;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    public class ZombieManager
    {
        public static List<Zombie> HordeOfZombies { get; } = new List<Zombie>();
        private static Texture2D _texture;
        private static float _spawnCooldown;
        public static float _spawnTiming;
        private static Random _randomNumber;
        private static int _padding;
        public BloodSplat _bloodSplat;

        public static void Initial()
        {
            _texture = Shared.Content.Load<Texture2D>("images/zombie");
            _spawnCooldown = 0.70f;
            _spawnTiming = _spawnCooldown;
            _randomNumber = new Random();
            _padding = _texture.Width / 2;
        }

        private static Vector2 RandomSpawnPosition()
        {
            float width = Shared.Boundaries.X;
            float height = Shared.Boundaries.Y;

            Vector2 position = new Vector2();

            if (_randomNumber.NextDouble() < width / (width * height))
            {
                // more understandable
                position.X = (int)(_randomNumber.NextDouble() * width);

                // what does this line even mean
                position.Y = (int)(_randomNumber.NextDouble() <  0.5 ? -_padding : height + _padding);
            }
            else
            {
                // more understandable
                position.Y = (int)(_randomNumber.NextDouble() * height);

                // what does this line even mean
                position.X = (int)(_randomNumber.NextDouble() < 0.5 ? -_padding : width + _padding);
            }

            return position;
        }

        public static void AddZombieToBattleField()
        {
            HordeOfZombies.Add(new Zombie(_texture, RandomSpawnPosition()));
        }

        public static void Update(Player player)
        {
            _spawnTiming -= Shared.TotalSeconds;
            if (_spawnTiming <= 0)
            {
                _spawnTiming += _spawnCooldown;
                AddZombieToBattleField();
            }

            foreach (var zombie in HordeOfZombies)
            {
                zombie.Update(player);
            }

            HordeOfZombies.RemoveAll((zombie) => zombie.HP <= 0);
        }

        public static void draw()
        {
            foreach (var zombie in HordeOfZombies)
            {
                zombie.Draw();
            }
        }

    }
}
