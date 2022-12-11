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
        private SoundEffect sniperRifleShot = Shared.Content.Load<SoundEffect>("sounds/sr_shot");
        private SoundEffect sniperRifleReload = Shared.Content.Load<SoundEffect>("sounds/sr_reload");
        private SoundEffect sniperRifleReload2 = Shared.Content.Load<SoundEffect>("sounds/sr_reload2");
        public SniperRifle()
        {
            cooldown = 2.1f;
            maxAmmo = 5;
            Ammo = maxAmmo;
            reloadTime = 3.5f;
            GunShot = sniperRifleShot;
            ReloadSound = sniperRifleReload;
            ReloadSound2 = sniperRifleReload2;
        }

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
