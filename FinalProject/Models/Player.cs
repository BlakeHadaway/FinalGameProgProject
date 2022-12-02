using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject.Models
{
    public class Player : ImageSprite
    {
        private readonly float _shotsCooldown;
        private float _reloadCooldownLeft;
        private float _invincibilityCooldownLeft;
        private readonly int _maximumAmmo;
        public int NumberOfLives { get; set; }
        public bool Invincibility { get; set; }
        public float _invincibilityTime;
        public int Ammo { get; private set; }

        private readonly float _reloadTime;
        public bool Reloading { get; private set; }

        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            _shotsCooldown = 0.25f;
            _reloadCooldownLeft = 0f;
            _invincibilityCooldownLeft = 0f;
            _maximumAmmo = 45;
            Ammo = _maximumAmmo;
            _reloadTime = 2.25f;
            Reloading = false;
            NumberOfLives = 10;
            Invincibility = false;
            _invincibilityTime = 3.5f;
        }

        public void IFrames()
        {
            if (Invincibility)
                return;

            _invincibilityCooldownLeft = _invincibilityTime;
            Invincibility = true;
        }

        private void Reload()
        {
            if (Reloading)
                return;

            _reloadCooldownLeft = _reloadTime;
            Reloading = true;
            Ammo = _maximumAmmo;
        }

        private void Fire()
        {
            if (_reloadCooldownLeft > 0 || Reloading)
                return;

            Ammo--;
            if (Ammo > 0)
            {
                _reloadCooldownLeft = _shotsCooldown;
            }
            else
            {
                Reload();
            }

            ProjectileData projectile = new ProjectileData()
            {
                Position = Position,
                Rotation = Rotation,
                Lifespan = 2,
                Speed = 600,
            };

            ProjectileManager.AddProjectile(projectile);
        }

        public void Update()
        {
            if (_reloadCooldownLeft > 0)
            {
                _reloadCooldownLeft -= Shared.TotalSeconds;
            }
            else
            {
                Reloading = false;
            }

            if (_invincibilityCooldownLeft > 0)
            {
                _invincibilityCooldownLeft -= Shared.TotalSeconds;
            }
            else
            {
                Invincibility = false;
            }

            if (InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);

                // restricting game movement to the game window, so then the character doesn't just walk off the screen
                Position = new Vector2(
                    MathHelper.Clamp(Position.X + (direction.X * Speed * Shared.TotalSeconds), 0, Shared.Boundaries.X),
                    MathHelper.Clamp(Position.Y + (direction.Y * Speed * Shared.TotalSeconds), 0, Shared.Boundaries.Y)
                );
            }

            var toMouse = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            if (InputManager.MouseLeftDown)
            {
                Fire();
            }

            if (InputManager.MouseRightClicked)
            {
                Reload();
            }
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }
    }
}
