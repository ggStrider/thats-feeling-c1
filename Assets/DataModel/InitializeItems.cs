using UnityEngine;
using UnityEngine.UI;

using TMPro;

using System;
using System.Collections.Generic;

namespace DataModel
{
    public class InitializeItems : MonoBehaviour
    {
        [SerializeField] private List<ItemSlot> _itemSlot;
        
        private GameSession _session;
        private void Start()
        {
            _session = GetComponent<GameSession>();
            _Initialize();
        }

        [ContextMenu("Initialize")]
        public void _Initialize()
        {
            var items = _session.Data.Items;

            if (items.Count == 0) return;
            
            for (var i = 0; i < items.Count; i++)
            {
                _itemSlot[i].Text.text = items[i].Name;
                _itemSlot[i].ImageComponent.sprite = items[i].ItemImage;
            }
        }

        [Serializable]
        public class ItemSlot
        {
            public TextMeshProUGUI Text;
            public Image ImageComponent;

            public ItemSlot(TextMeshProUGUI text, Image image)
            {
                Text = text;
                ImageComponent = image;
            }
        }
    }
}
