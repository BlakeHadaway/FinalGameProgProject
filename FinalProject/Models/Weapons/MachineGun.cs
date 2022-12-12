/*
 * MachineGun.cs
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
    public class MachineGun : Weapon
    {
        // Sound effects used by our MachineGun
        private SoundEffect mgShot = Shared.Content.Load<SoundEffect>("sounds/pistol_shot");
        private SoundEffect mgReload = Shared.Content.Load<SoundEffect>("sounds/pistol_reload");

        /// <summary>
        /// Making the MachineGun have its different ammo amounts and gunshot sounds using the inherited 
        /// Weapon class 
        /// </summary>
        public MachineGun()
        {
            cooldown = 0.17f;
            maxAmmo = 30;
            Ammo = maxAmmo;
            reloadTime = 2f;
            GunShot = mgShot;
            ReloadSound = mgReload;
        }

        /// <summary>
        /// Creating projectiles from the player using a new projectile data model
        /// to make it shoot from the player and have its own speed and lifespan, and then 
        /// adding it to a list in ProjectileManager
        /// </summary>
        /// <param name="player"></param>
        protected override void CreateProjectiles(Player player)
        {
            ProjectileData projectileData = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 600
            };

            ProjectileManager.AddProjectile(projectileData);
        }
    }

   
}
