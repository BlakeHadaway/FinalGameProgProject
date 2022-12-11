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
    /// <summary>
    /// this is the manager for all the zombies
    /// </summary>
    public class ZombieManager
    {
        // declaring the variables to be used
        public static List<Zombie> HordeOfZombies { get; } = new List<Zombie>();
        private static Texture2D _texture;
        private static float _spawnCooldown;
        public static float _spawnTiming;
        private static Random _randomNumber;
        private static int _padding;

        /// <summary>
        /// This is a intial fuction to be called in Gamemanager
        /// </summary>
        public static void Initial()
        {
            // setting these variables at the start of the game
            _texture = Shared.Content.Load<Texture2D>("images/zombie");
            _spawnTiming = _spawnCooldown;
            _randomNumber = new Random();
            _padding = _texture.Width / 2;
        }

        /// <summary>
        /// this fuction is to determine a random spawn position for the zombies just outside of the border
        /// of the game
        /// </summary>
        /// <returns>Returns a spawn position for the zombie</returns>
        private static Vector2 RandomSpawnPosition()
        {
            // getting float values of the boundaries of the game window
            float width = Shared.Boundaries.X;
            float height = Shared.Boundaries.Y;

            // creating a position varable of type vector2
            Vector2 position = new Vector2();

            // .NextDouble returns a float value between 0.0 and 1.0

            // if the next random double is less then the width, divded by the width * height
            if (_randomNumber.NextDouble() < width / (width * height))
            {
                // setting the new X spawning position by multiplying the next double by the width
                position.X = (int)(_randomNumber.NextDouble() * width);

                // setting the new Y to - padding or height + padding
                // this is based on weither the next double is greater or less than 0.5,
                // based on that it will either subtract the padding or add the padding to the height
                position.Y = (int)(_randomNumber.NextDouble() <  0.5 ? -_padding : height + _padding);
            }
            else
            {
                // setting the new Y spawning position by multiplying the next double by the width
                position.Y = (int)(_randomNumber.NextDouble() * height);

                // setting the new X to - padding or height + padding
                // this is based on weither the next double is greater or less than 0.5,
                // based on that it will either subtract the padding or add the padding to the width
                position.X = (int)(_randomNumber.NextDouble() < 0.5 ? -_padding : width + _padding);
            }

            // then return the position the zombie should be spawned at
            return position;
        }

        /// <summary>
        /// This method is adding the zombie to the battlefield based on the random spawn location
        /// </summary>
        public static void AddZombieToBattleField()
        {
            // adds a new zombie to the list
            HordeOfZombies.Add(new Zombie(_texture, RandomSpawnPosition()));
        }

        /// <summary>
        /// update method to be called in the GameManager class
        /// </summary>
        /// <param name="player"></param>
        public static void Update(Player player)
        {
            // setting the spawn cooldown
            _spawnCooldown = Shared.zombieSpawnRate;

            // subrating the ingame time from the spawn cooldown
            _spawnTiming -= Shared.TotalSeconds;

            // if cooldown is up for the zombie to spawn
            if (_spawnTiming <= 0)
            {
                // setting the spawntiming
                _spawnTiming += _spawnCooldown;

                // adding the zombie to the battefield
                AddZombieToBattleField();
            }

            // foreach of the zombies in the list
            foreach (var zombie in HordeOfZombies)
            {
                // update the zombies, and pass in the player object
                zombie.Update(player);
            }

            // remove all zombies that are dead
            HordeOfZombies.RemoveAll((zombie) => zombie.HP <= 0);
        }

        /// <summary>
        /// draw fuction to be called in the GameManager
        /// </summary>
        public static void draw()
        {
            // foreach of the zombies in the list
            foreach (var zombie in HordeOfZombies)
            {
                // draw the zombie
                zombie.Draw(Shared.White);
            }
        }

    }
}
