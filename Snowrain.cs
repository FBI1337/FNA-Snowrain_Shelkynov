using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
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

            base.LoadContent();
        }
    }
}
