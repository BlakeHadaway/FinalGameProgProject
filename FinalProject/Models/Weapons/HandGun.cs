using FinalProject.Managers;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    public class HandGun : Weapon
    {
        // Sound effects used by the Pistol
        private SoundEffect pistolShot = Shared.Content.Load<SoundEffect>("sounds/pistol_shot");
        private SoundEffect pistolReload = Shared.Content.Load<SoundEffect>("sounds/pistol_reload");

        /// <summary>
        /// Setting all the fields of the hand gun using the inherited Weapon class.
        /// </summary>
        public HandGun()
        {
            cooldown = 0.7f;
            maxAmmo = 12;
            Ammo = maxAmmo;
            reloadTime = 1.2f;
            GunShot = pistolShot;
            ReloadSound = pistolReload;
        }

        /// <summary>
        /// Creating projectiles using a new projectiledata putting the position to the player so the 
        /// bullet comes from them and then also making the life span and speed of the bullet.
        /// Add the projectile to a list in ProjectileManager 
        /// </summary>
        /// <param name="player"></param>
        protected override void CreateProjectiles(Player player)
        {
            ProjectileData projectileData = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 400
            };

            ProjectileManager.AddProjectile(projectileData);
        }
    }
}
