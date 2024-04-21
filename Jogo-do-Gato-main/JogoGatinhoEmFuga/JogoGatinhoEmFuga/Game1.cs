using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace JogoGatinhoEmFuga
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _font;

        Cat cat;
        Rat rat;
        BirdLightBlue bird;

        Texture2D back;
        Texture2D catYellowIndle1;
        Texture2D ratBrownIndle1;
        Texture2D birdLightBlueIndle1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
            Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here

            back = Content.Load<Texture2D>("assets/City1");
            catYellowIndle1 = Content.Load<Texture2D>("assets/catIndle1");
            ratBrownIndle1 = Content.Load<Texture2D>("assets/ratIndle1");
            birdLightBlueIndle1 = Content.Load<Texture2D>("assets/birdIndle1");

            cat = new Cat(this, new Vector2(10, 100), catYellowIndle1, Keys.Up, Keys.Down, Keys.Right, Keys.Left);
            rat = new Rat(this, ratBrownIndle1);
            rat.SetInStartPosition();
            bird = new BirdLightBlue(this, birdLightBlueIndle1);
            bird.SetInStartPosition();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            cat.Update();
            rat.Update();
            bird.Update();
            base.Update(gameTime);

            cat.HasCollided(rat, bird);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Calcular a escala necessária para ajustar a imagem ao tamanho da tela
            float scaleX = (float)GraphicsDevice.Viewport.Width / back.Width;
            float scaleY = (float)GraphicsDevice.Viewport.Height / back.Height;
            float scale = Math.Max(scaleX, scaleY);

            // Calcular a posição para centralizar a imagem na tela
            Vector2 positionTela = Vector2.Zero;


            _spriteBatch.Begin();
            _spriteBatch.Draw(back, positionTela, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            string scoreText = "Score: " + cat.score;
            _spriteBatch.DrawString(_font, scoreText , Vector2.Zero, Color.Black);


            cat.Draw(_spriteBatch);
            rat.Draw(_spriteBatch);
            bird.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
