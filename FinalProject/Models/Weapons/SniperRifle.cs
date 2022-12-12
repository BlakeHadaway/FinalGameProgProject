/*
 * SniperRifle.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.12.3: Created
 *      Blake Power, 2022.12.3: Added code
 *      Blake Power, 2022.12.11: Comments added
 */
using FinalProject.Managers;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    public class SniperRifle : Weapon
    {
        // Sound effects for the sniper 
        private SoundEffect sniperRifleShot = Shared.Content.Load<SoundEffect>("sounds/sr_shot");
        private SoundEffect sniperRifleReload = Shared.Content.Load<SoundEffect>("sounds/sr_reload");
        private SoundEffect sniperRifleReload2 = Shared.Content.Load<SoundEffect>("sounds/sr_reload2");

       
        /// <summary>
        /// making our SniperRifle with all the things from the weapon class so that it can have 
        /// unique characteristics and differ from other weapons 
        /// </summary>
        public SniperRifle()
        {
            cooldown = 0.5f;
            maxAmmo = 5;
            Ammo = maxAmmo;
            reloadTime = 2.7f;
            GunShot = sniperRifleShot;
            ReloadSound = sniperRifleReload;
            ReloadSound2 = sniperRifleReload2;
        }

        /// <summary>
        /// CreateProjectiles protected override void because it is not returning anything rather it is just adding
        /// a projectile to projectilemanager so that it can be put into a list. projectiledata is a class that we are using to
        /// create a new projectiledata for our guns bullets so that they start at the player and go a certain speed with a lifespan
        /// so that they do not ifinitely fly away. 
        /// </summary>
        /// <param name="player"></param>
        protected override void CreateProjectiles(Player player)
        {
            ProjectileData projectileData = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 800

            };

            ProjectileManager.AddProjectile(projectileData);
        }
    }
}
