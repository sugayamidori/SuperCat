using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net;

namespace SuperCatCreditos
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;
        Texture2D back;
        Texture2D backText;

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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            back = Content.Load<Texture2D>("backCreditos");
            backText = Content.Load<Texture2D>("backTextCredits");
            font = Content.Load<SpriteFont>("Font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Calcular a escala necessária para ajustar a imagem ao tamanho da tela
            float scaleX = (float)GraphicsDevice.Viewport.Width / back.Width;
            float scaleY = (float)GraphicsDevice.Viewport.Height / back.Height;
            float scale = Math.Max(scaleX, scaleY);

            Vector2 fontDrawPos = new Vector2(170, 150);

            // Calcular a posição para centralizar a imagem na tela
            Vector2 positionTela = Vector2.Zero;
            _spriteBatch.Begin();

            _spriteBatch.Draw(back, positionTela, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(backText, new Vector2 (150, 70), Color.White);
            _spriteBatch.DrawString(font, "Projeto da disciplina Game Engine para o desenvolvimento", new Vector2(160, 90), Color.White);
            _spriteBatch.DrawString(font, "Projeto da disciplina Game Engine para o desenvolvimento", new Vector2(161, 91), Color.White);
            _spriteBatch.DrawString(font, "de game utilizando o Monogame", new Vector2(250, 110), Color.White);
            _spriteBatch.DrawString(font, "de game utilizando o Monogame", new Vector2(251, 111), Color.White);

            string[] creditos =
            {
                "Tela de Menu:",
                "  - Jonas Freitas Grandinetti",
                "",
                "Tela de Creditos:",
                "  - Joao Vitor Campos",
                "",
                "Tela de Jogo:",
                "  - Midori Cabral Sugaya",
                "",
                "Tela de Fim de Jogo:",
                "  - Sayonara Kerollyn dos Santos Franca",
                "  - Silvia Raquel Barros Freitas"
            };
            foreach (string credito in creditos) 
            {
                _spriteBatch.DrawString(font, credito, fontDrawPos, Color.Black);
                fontDrawPos.Y += font.LineSpacing;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
