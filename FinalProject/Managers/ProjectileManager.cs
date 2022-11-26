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

namespace FinalProject.Managers
{
    public static class ProjectileManager
    {
        private static Texture2D _texture;
        public static List<Projectile> Projectiles { get; } = new();

        public static void Initial()
        {
            _texture = Shared.Content.Load<Texture2D>("images/bullet");
        }

        public static void AddProjectile(ProjectileData projData)
        {
            Projectiles.Add(new(_texture, projData));
        }

        public static void Update()
        {
            foreach (var bullet in Projectiles)
            {
                bullet.Update();
            }

            Projectiles.RemoveAll((bullet) => bullet.Lifespan <= 0);
        }

        public static void Draw()
        {
            foreach (var bullet in Projectiles)
            {
                bullet.Draw();
            }
        }
    }
}
