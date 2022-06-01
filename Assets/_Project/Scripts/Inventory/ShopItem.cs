using System;
using UnityEngine;

namespace M
{
    public class ShopItem : InventoryItem
    {
        public static event Action<InventoryItem> Selected;

        public void OnClickHandler()
        {
            Selected?.Invoke(this);
        }
    }
}