using FinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    public class MachineGun : Weapon
    {
        public MachineGun()
        {
            cooldown = 0.1f;
            maxAmmo = 30;
            Ammo = maxAmmo;
            reloadTime = 2f;
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
