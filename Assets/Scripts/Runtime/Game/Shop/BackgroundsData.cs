using System;
using System.Collections.Generic;

namespace Runtime.Game.Shop
{
    [Serializable]
    public class BackgroundsData
    {
        public int SelectedId;
        public List<int> PurchasedIds = new() { 0 };
    }
}