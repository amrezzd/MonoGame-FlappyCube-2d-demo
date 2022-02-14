using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FlappyCube
{
    public class Cube2D
    {
        private readonly Texture2D _texture2d;
        protected Vector2 _velocity = Vector2.Zero;
        private int _width;
        private int _height;

        // 60 frame per seconds update
        private TimeSpan _gravityUpdatePeriod = TimeSpan.FromMilliseconds(16.666);
        private TimeSpan _lastGravityUpdatedTime = TimeSpan.FromSeconds(0);

        public Cube2D(GraphicsDevice graphicsDevice, int x, int y, int width, int height, Color color)
        {
            this.Width = width;
            this.Height = height;

            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; i++) data[i] = color;

            _texture2d = new Texture2D(graphicsDevice, width, height);
            _texture2d.SetData(data);

            Position = new Vector2(x, y);
        }

        public Vector2 Position { get; set; } = Vector2.Zero;
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                Origin = new Vector2(Width / 2, Height / 2);
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                Origin = new Vector2(Width / 2, Height / 2);
            }
        }

        public float Rotation { get; set; }
        public float Mass { get; set; } = 1;
        public float Gravity { get; set; } = 9.807f;
        public Vector2 Origin { get; private set; }
        public Vector2 Center { get => new Vector2(Position.X + Width / 2, Position.Y + Height / 2); }

        public virtual void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - _lastGravityUpdatedTime > _gravityUpdatePeriod)
            {
                _velocity.Y += Gravity * Mass;
                _lastGravityUpdatedTime = gameTime.TotalGameTime;
            }

            Position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture2d, Position, null, Color.White, Rotation, Origin, 1, SpriteEffects.None, 1);
        }
    }
}
