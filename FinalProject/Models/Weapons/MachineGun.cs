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
        private SoundEffect mgShot = Shared.Content.Load<SoundEffect>("sounds/pistol_shot");
        private SoundEffect mgReload = Shared.Content.Load<SoundEffect>("sounds/pistol_reload");
        public MachineGun()
        {
            cooldown = 0.17f;
            maxAmmo = 30;
            Ammo = maxAmmo;
            reloadTime = 2f;
            GunShot = mgShot;
            ReloadSound = mgReload;
        }

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
