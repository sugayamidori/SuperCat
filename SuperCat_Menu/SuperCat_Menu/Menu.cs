using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperCat_Menu
{
    public class Menu : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D back;
        Texture2D menu;
        Texture2D logo;
        
        public Menu()
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
            back = Content.Load<Texture2D>("City1 esmaecido");
            menu = Content.Load<Texture2D>("Menu");
            logo = Content.Load<Texture2D>("Logo");
            
            // TODO: use this.Content to load your game content here
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

            // Calcular a posição para centralizar a imagem na tela
            Vector2 positionTela = Vector2.Zero;

            _spriteBatch.Begin();
            _spriteBatch.Draw(back, positionTela, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(logo, new Vector2 (30,40), Color.White);
            _spriteBatch.Draw(menu, new Vector2 (450, 200), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
