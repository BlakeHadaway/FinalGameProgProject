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
        private SoundEffect lmgShot = Shared.Content.Load<SoundEffect>("sounds/pistol_shot");
        private SoundEffect lmgReload = Shared.Content.Load<SoundEffect>("sounds/pistol_reload");
        public LightMachineGun()
        {
            cooldown = 0.08f;
            maxAmmo = 75;
            Ammo = maxAmmo;
            reloadTime = 3.2f;
            GunShot = lmgShot;
            ReloadSound = lmgReload;
        }

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
