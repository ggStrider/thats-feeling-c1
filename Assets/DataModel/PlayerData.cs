using UnityEngine;
using Items;

using System;
using System.Collections.Generic;

namespace DataModel
{
    [Serializable]
    public class PlayerData
    {
        public List<ItemInfo> Items;

        public GameObject ObjectInHand;

        public List<int> Decisions;

    }
}