using System;
using System.Collections.Generic;
using Runtime.Core.Infrastructure;
using UnityEngine;

namespace Runtime.Game
{
    [CreateAssetMenu(fileName = "BackgroundsConfig", menuName = "Configs/BackgroundsConfig")]
    public class BackgroundsConfig : BaseSettings
    {
        public List<ShopItem> ShopItems = new List<ShopItem>();
    }

    [Serializable]
    public class ShopItem
    {
        public Sprite BackgroundSprite;
        public int Price;
    }
}