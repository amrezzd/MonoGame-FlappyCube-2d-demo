using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FlappyCube
{
    public class FlappyCube2D : Cube2D
    {
        private bool _isMouseCaptered = false;
        // this is either 0: no rotation, 1: clockwise rotation or -1: counterclockwise
        private int _rotationDirection = 0;
        
        public FlappyCube2D(GraphicsDevice graphicsDevice, int x, int y, int width, int height, Color color)
            : base(graphicsDevice, x, y, width, height, color)
        {
        }

        public float MouseGravity { get; set; } = -300f;
        public float RotationSpeed { get; set; } = 2;

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (_isMouseCaptered == false && mouseState.LeftButton == ButtonState.Pressed)
            {
                _isMouseCaptered = true;
                Vector2 distanceVector = Position - mouseState.Position.ToVector2();
                distanceVector.Normalize();

                _velocity.X = distanceVector.X * -MouseGravity;
                _velocity.Y = distanceVector.Y * -MouseGravity;

                _rotationDirection = Math.Sign(distanceVector.X);
            }

            if (mouseState.LeftButton == ButtonState.Released)
            {
                _isMouseCaptered = false;
            }

            Rotation += _rotationDirection * RotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}
