/*
 * InputManager.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.11.30: Created
 *      Blake Power, 2022.11.30: Added code
 *      Blake Power, 2022.12.11: Comments added
 */
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation.DirectX;
using System.Security.Cryptography.X509Certificates;
using System.Runtime;
using Microsoft.Xna.Framework.Audio;
using FinalProject.Models.Weapons;

namespace FinalProject.Managers
{
    public static class ProjectileManager
    {
        //texture of the bullet 
        private static Texture2D _texture;

        // list of projectiles not shot out of a sniper 
        public static List<Projectile> Projectiles { get; } = new();

        //list of projectiles shot out of a sniper 
        public static List<ProjectileSR> Projectiles2 { get; } = new();

        // Sound effect for zombies death
        public static SoundEffect zombieDeathSound = Shared.Content.Load<SoundEffect>("sounds/zombie_death");

        /// <summary>
        /// Initializing the bullet image 
        /// </summary>
        public static void Initial()
        {
            _texture = Shared.Content.Load<Texture2D>("images/bullet");
        }

        /// <summary>
        /// public static void for adding bullets, if the gun equipped is a sniper the bool will be true
        /// and the projectiles2 will be added else the normal projectiles will be added.
        /// </summary>
        /// <param name="projData">Projectile data</param>
        public static void AddProjectile(ProjectileData projData)
        {
            if (Shared.isSniperEquipped)
            {
                Projectiles2.Add(new(_texture, projData));
            }
            else
            {
                Projectiles.Add(new(_texture, projData));
            }
        }

        /// <summary>
        /// For updating the list of zombies. foreach bullet in projectiles update them and foreach zombie in the list
        /// of zombies, if their health is less than or equal to zero then continue and thne the if statement for if a bullet hits them
        /// to remove the bullet and inflict the damage to the zombie adn then takes the zombie out of the list and adds to our score.
        /// next if our score is hitting the checkpoints give the player the new weapons and start spawning more zombies to make the game 
        /// harder. Do the exact same thing foreach bullet in projectiles2 then remove bullets when they are at the end of their 
        /// lifespan.
        /// </summary>
        /// <param name="hordeOfZombies">list of zombies</param>
        public static void Update(List<Zombie> hordeOfZombies)
        {

            foreach (var bullet in Projectiles)
            {
                bullet.Update();

                foreach (var zombie in hordeOfZombies)
                {
                    if (zombie.HP <= 0)
                        continue;

                    if ((bullet.Position - zombie.Position).Length() < 32)
                    {

                        zombie.InflictDamage(1);
                        bullet.Remove();
                        Shared.KillZombiePos = zombie.Position - new Vector2(25, 25);
                        Shared.zombHit = true;
                        Shared.Score++;

                        // play zombie death sound 
                        zombieDeathSound.Play(volume: 0.2f, pitch: 0.0f, pan: 0.0f);

                        // Score checkpoints for unlocking weapons

                        if (Shared.Score == 30)
                        {
                            Player.SMGUnlocked = true;
                        }

                        if (Shared.Score == 100)
                        {
                            Player.SniperUnlocked = true;
                        }

                        if (Shared.Score == 250)
                        {
                            Player.LMGUnlocked = true;
                        }

                        break;

                    }
                }
            }

            foreach (var bullet in Projectiles2)
            {
                bullet.Update();

                foreach (var zombie in hordeOfZombies)
                {
                    if (zombie.HP <= 0)
                        continue;

                    if ((bullet.Position - zombie.Position).Length() < 32)
                    {
                        zombie.InflictDamage(1);
                        Shared.Score++;
                        Shared.KillZombiePos = zombie.Position - new Vector2(25, 25);
                        Shared.zombHit = true;
                        zombieDeathSound.Play(volume: 0.2f, pitch: 0.0f, pan: 0.0f);

                        if (Shared.Score == 30)
                        {
                            Player.SMGUnlocked = true;
                        }

                        if (Shared.Score == 100)
                        {
                            Player.SniperUnlocked = true;
                        }

                        if (Shared.Score == 250)
                        {
                            Player.LMGUnlocked = true;
                        }

                        break;
                    }
                }
            }

            Projectiles.RemoveAll((bullet) => bullet.Lifespan <= 0);
        }

        /// <summary>
        /// Draws the bullets into the game for both normal projectiles and sniper 
        /// projectiles 
        /// </summary>
        public static void Draw()
        {
            foreach (var bullet in Projectiles)
            {
                bullet.Draw(Shared.White);
            }

            foreach (var bullet in Projectiles2)
            {
                bullet.Draw(Shared.White);
            }
        }
    }
}
