using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FNA_Snowrain_Shelkynov
{
    internal class Snowflake
    {
        public Vector2 position;
        public readonly float speed;
        public readonly float size;
        public readonly Texture2D texture;
        /// <summary>
        /// Конструктор снежинки. Инициализирует скорость, размер, позицию и текстуру
        /// </summary>
        public Snowflake(Vector2 position, float speed, float size, Texture2D texture)
        {
            this.position = position;
            this.speed = speed;
            this.size = size;
            this.texture = texture;
        }
        /// <summary>
        /// Пдание снежинки
        /// </summary>
        public void Fall(GameTime gameTime)
        {
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        /// <summary>
        /// Отрисовка снежинки
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, size, SpriteEffects.None, 0f);
        }
    }
}
