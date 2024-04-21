using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace JogoGatinhoEmFuga
{
    public class Rat
    {
        public const float RAT_VELOCITY = 0.5F;

        Vector2 velocity;
        Vector2 position;
        Texture2D texture;
        Game game;
        bool outOfBounds = false;
        bool disappeared = false;
        public Vector2 Velocity { get => velocity; }

        public Rat(Game game, Texture2D texture) 
        {
            this.texture = texture;
            this.game = game;
        }
            
        public void SetInStartPosition()
        {
            var viewport = game.GraphicsDevice.Viewport;
            position.Y = 350;
            position.X = 400;

            velocity = new Vector2(RAT_VELOCITY, 0);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public bool HasDisappeared()
        {
            return disappeared;
        }
        public void Disappear ()
        {
            disappeared = true;
        }

        public void SetPosition(float X)
        {
            position.X = X;
        }
        public void Update()
        {
            var viewport = game.GraphicsDevice.Viewport;

            if (position.Y < 0)
            {
                position.Y = 0;
                velocity *= -1;
            }
            if (position.Y + texture.Height > viewport.Height)
            {
                position.Y = viewport.Height - texture.Height;
                velocity *= -1;
            }

            position += velocity;

            if (position.X + texture.Width < 0 || position.X > viewport.Width)
            {
                outOfBounds = true;
                velocity *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!disappeared)
            {
                float escala = 1.5f;
                Vector2 posicaoAjustada = new Vector2(position.X - (texture.Width * (escala - 1) / 2), position.Y - (texture.Height * (escala - 1) / 2));
                spriteBatch.Draw(texture, posicaoAjustada, null, Color.White, 0f, Vector2.Zero, escala, SpriteEffects.None, 0f);
            }
            
        }

    }
}

