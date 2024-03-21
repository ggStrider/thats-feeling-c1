using UnityEngine;

using System;
using System.Collections.Generic;

namespace DataModel
{
    [Serializable]
    public class PlayerData
    {
        public List<GameObject> InventoryItems;
        public GameObject ObjectInHand;
    }
}