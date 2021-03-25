using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace CubeClash
{
    [Serializable]
    public class WrappedSpriteAtlas
    {
        public SpriteAtlas spriteAtlas;
        private Dictionary<string, Sprite> spriteCache;

        public new Sprite GetSprite(string spriteName)
        {
            spriteCache = spriteCache ?? new Dictionary<string, Sprite>(spriteAtlas.spriteCount);
            if (!spriteCache.TryGetValue(spriteName, out Sprite sprite))
            {
                sprite = spriteAtlas.GetSprite(spriteName);
                spriteCache.Add(spriteName, sprite);
            }

            return sprite;
        }
    }
}