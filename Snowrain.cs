using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FNA_Snowrain_Shelkynov
{
    public class Snowrain : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D spriteTexture;
        private List<Snowflake> sprite;
        private readonly Random random = new Random();
        private const int WindowHeight = 1920;
        private const int WindowWidth = 1080;
        /// <summary>
        /// Это конструктор снегопада. Инициализирует все параметры графики
        /// </summary>
        public Snowrain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

        }
        /// <summary>
        /// Инициализация игры. Здесь добавляется логика
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// Загрузка контента.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteTexture = Content.Load<Texture2D>("Snowflake");
            sprite = new List<Snowflake>();

            for (var i = 0; i < 200; i++)
            {
                var size = (float)random.Next(3, 7) / 100;
                var speed = (float)random.NextDouble() * 50f + 20f;
                var startPosition = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight));

                sprite.Add(new Snowflake(spriteTexture, startPosition, speed, size));
            }
        }
        /// <summary>
        /// Обработка падения снежинок
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var sprite in sprite)
            {
                sprite.Fall(gameTime);
                if (sprite.position.Y > WindowHeight)
                {
                    sprite.position = new Vector2(random.Next(0, WindowWidth), -50);
                }
            }
            base.Update(gameTime);
        }
        /// <summary>
        /// Отрисовка снежинок
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            foreach (var sprite in sprite)
            {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
