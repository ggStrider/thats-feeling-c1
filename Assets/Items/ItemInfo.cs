using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Thenexy/Item")]
    public class ItemInfo : ScriptableObject
    {
        public string Name;
        [TextArea(4,6)] public string Description;
        public Sprite ItemImage;

        [Space]
        public GameObject ItemWhenTakeInHand;
        
        [Space(1)]
        public Vector3 SizeInHand;
        public Vector3 RotationOffsetInHand;
    }
}
