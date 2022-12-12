/*
 * LightMachineGun.cs
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
    public class LightMachineGun : Weapon
    {
        // Sounds used by the LightMachineGun
        private SoundEffect lmgShot = Shared.Content.Load<SoundEffect>("sounds/pistol_shot");
        private SoundEffect lmgReload = Shared.Content.Load<SoundEffect>("sounds/pistol_reload");
        /// <summary>
        /// Setting the gun sounds and ammo etc. to be unique for our lmg using the inherited Weapon
        /// class 
        /// </summary>
        public LightMachineGun()
        {
            cooldown = 0.08f;
            maxAmmo = 75;
            Ammo = maxAmmo;
            reloadTime = 3.2f;
            GunShot = lmgShot;
            ReloadSound = lmgReload;
        }

        /// <summary>
        /// CreateProjectiles with new projectiledata changing speed to be different and 
        /// position to be on the player so it comes from the player then adding the projectile to
        /// a list in ProjectileManager
        /// </summary>
        /// <param name="player"></param>
        protected override void CreateProjectiles(Player player)
        {
            ProjectileData projectileData = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 650
            };

            ProjectileManager.AddProjectile(projectileData);
        }
    }


}
