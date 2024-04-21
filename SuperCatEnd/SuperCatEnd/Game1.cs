using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperCatEnd
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D back;
        Texture2D gameOver;

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
            back = Content.Load<Texture2D>("backEnd");
            gameOver = Content.Load<Texture2D>("gameOver");
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
            
            float scaleX = (float)GraphicsDevice.Viewport.Width / back.Width;
            float scaleY = (float)GraphicsDevice.Viewport.Height / back.Height;
            float scale = Math.Max(scaleX, scaleY);

            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;

            float offSetX = (screenWidth - (back.Width * scale))/2;
            float offSetY = (screenHeight - (back.Height * scale))/2;

            

            int imageWidth = gameOver.Width;
            int imageHeight = gameOver.Height;

            Vector2 position = new Vector2((screenWidth - imageWidth)/2, (screenHeight - imageHeight)/2 );

            _spriteBatch.Begin();
            _spriteBatch.Draw(back, new Vector2(offSetX, offSetY), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(gameOver, position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
