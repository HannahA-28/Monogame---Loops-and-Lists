using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame___Loops_and_Lists
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        Random generator;
        Rectangle window;
        Texture2D spaceBackgroundTexture;
        List<Texture2D> textures;
        List<Rectangle> planetRects;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferWidth);
            generator = new Random();
            textures = new List<Texture2D>();
            planetRects = new List<Rectangle>();

            for (int i = 0; i < 30;  i++)
            {
                planetRects.Add
                    (
                        new Rectangle(generator.Next(window.Width - 25), 
                        generator.Next(window.Height - 25), 25, 25)
                    );
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spaceBackgroundTexture = Content.Load<Texture2D>("Images/space_background[1]");
            for (int i = 1; i <= 13; i++)
                textures.Add(Content.Load<Texture2D>("Images/16-bit-planet[1]" + i));

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

            _spriteBatch.Begin();

            _spriteBatch.Draw(spaceBackgroundTexture, window, Color.White);
            for (int i = 0; i < planetRects.Count; i++)
                _spriteBatch.Draw(textures[0], planetRects[i], Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
