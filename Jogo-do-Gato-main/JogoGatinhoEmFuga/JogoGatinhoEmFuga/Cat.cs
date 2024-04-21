using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;


namespace JogoGatinhoEmFuga
{
    public class Cat
    {
        public const float CAT_VELOCITY = 5F;

        public int score;
        Vector2 position;
        Texture2D texture;
        Game game;


        public Cat(Game game, Vector2 position, Texture2D texture, Keys keyUp, Keys keyDown, Keys keyRight, Keys keyLeft)
        {
            this.position = position;
            this.texture = texture;
            this.game = game;
        }

        public void Update()
        {
            //para obter o estado atual do teclado
            var keyboard = Keyboard.GetState();

            switch (keyboard.GetPressedKeys().FirstOrDefault())
            {
                case Keys.Up:
                    position.Y -= CAT_VELOCITY;
                    break;
                case Keys.Down:
                    position.Y += CAT_VELOCITY;
                    break;
                case Keys.Right:
                    position.X += CAT_VELOCITY;
                    break;
                case Keys.Left:
                    position.X -= CAT_VELOCITY;
                    break;
                default: break;
            }

            var viewport = game.GraphicsDevice.Viewport;

            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.X > Globals.SCREEN_WIDTH - texture.Width)
            {
                position.X = Globals.SCREEN_WIDTH - texture.Width;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.Y + texture.Height > viewport.Height)
            {
                position.Y = viewport.Height - texture.Height;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float escala = 2.5f;
            Vector2 posicaoAjustada = new Vector2(position.X - (texture.Width * (escala - 1) / 2), position.Y - (texture.Height * (escala - 1) / 2));
            spriteBatch.Draw(texture, posicaoAjustada, null, Color.White, 0f, Vector2.Zero, escala, SpriteEffects.None, 0f);

        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void HasCollided(Rat rat, BirdLightBlue bird)
        {
            Rectangle ratBounds = rat.GetBounds();
            Rectangle birdBounds = bird.GetBounds();
            Rectangle catBounds = GetBounds();

            if (catBounds.Intersects(ratBounds))
            {
                if (!rat.HasDisappeared())
                {

                    rat.Disappear();

                    score += 10;

                    if (rat.Velocity.X < 0)
                    {
                        rat.SetPosition(position.X + texture.Width);
                    }
                    else
                    {
                        rat.SetPosition(position.X - texture.Width);
                    }
                }
            }

            if (catBounds.Intersects(birdBounds))
            {
                if (!bird.HasDisappeared())
                {
                    bird.Disappear();

                    score += 20;

                    if (bird.Velocity.X < 0)
                    {
                        bird.SetPosition(position.X + texture.Width);
                    }
                    else
                    {
                        bird.SetPosition(position.X - texture.Width);
                    }
                }
            }
        }
    }
}
