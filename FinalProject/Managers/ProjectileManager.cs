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
        private static Texture2D _texture;
        public static List<Projectile> Projectiles { get; } = new();

        public static List<ProjectileSR> Projectiles2 { get; } = new();

        public static SoundEffect zombieDeathSound = Shared.Content.Load<SoundEffect>("sounds/zombie_death");

        public static void Initial()
        {
            _texture = Shared.Content.Load<Texture2D>("images/bullet");
        }

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
                        zombieDeathSound.Play(volume: 0.2f, pitch: 0.0f, pan: 0.0f);

                        if (Shared.Score == 15)
                        {
                            Shared.zombieSpawnRate = 0.60f;
                            Player.SMGUnlocked = true;
                        }

                        if (Shared.Score == 50)
                        {
                            Shared.zombieSpawnRate = 0.45f;
                            Player.SniperUnlocked = true;
                        }
                        if (Shared.Score == 125)
                        {
                            Shared.zombieSpawnRate = 0.30f;
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

                        if (Shared.Score == 15)
                        {
                            Shared.zombieSpawnRate = 0.60f;
                            Player.SMGUnlocked = true;
                        }

                        if (Shared.Score == 50)
                        {
                            Shared.zombieSpawnRate = 0.45f;
                            Player.SniperUnlocked = true;
                        }
                        if (Shared.Score == 125)
                        {
                            Shared.zombieSpawnRate = 0.30f;
                            Player.LMGUnlocked = true;
                        }

                        break;
                    }
                }
            }

            Projectiles.RemoveAll((bullet) => bullet.Lifespan <= 0);
        }

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
