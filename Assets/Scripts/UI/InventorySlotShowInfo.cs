using UnityEngine;
using UnityEngine.EventSystems;

using Items;
using UnityEngine.UI;

namespace UI
{
    public class InventorySlotShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public ItemInfo CurrentItem;

        [SerializeField] private Image _imageComponent;

        private InventoryComponents _inventoryComponents;

        private void Start()
        {
            _inventoryComponents = FindObjectOfType<InventoryComponents>();

            #if UNITY_EDITOR
            if (_inventoryComponents != null) return;
            Debug.LogError($"InventoryComponents is null! Add InventoryComponents to scene. {gameObject}");
            #endif
        }

        public void ReDrawItemInInventory()
        {
            if (CurrentItem == null) return;
            _imageComponent.sprite = CurrentItem.ItemImage;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(CurrentItem == null) return;
            
            _inventoryComponents.ItemName.text = CurrentItem.Name;
            _inventoryComponents.ItemDescription.text = CurrentItem.Description;

            _inventoryComponents.ItemImage.sprite = CurrentItem.ItemImage;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log($"Pointer EXIT game object");
        }
    }
}
