using UnityEngine;

using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class PlayerData
    {
        public List<GameObject> InventoryItems;
        public GameObject ObjectInHand;
    }
}