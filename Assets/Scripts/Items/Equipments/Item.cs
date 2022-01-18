
using UnityEngine;

namespace Assets.Scripts.Items.Equipments
{

    public class Item : AnyItem
    {
        // probs constructor with ID already referencing to an item for better instanciation on enemy death

        public string Name;
        public string Description;
        public string SecondaryDescription;
        protected bool consumable;

        Sprite sprite;
        public Item() { }

        public Item(int id)
        {
            Sprite = EquipableStatics.GetItemSprite(id);
        }


        public override string DisplayName()
        {
            return Name;
        }

        public override string DisplayTop()
        {
            return Description;
        }
        public override string DisplayBottom()
        {
            return SecondaryDescription;
        }

        public override Color GetOutlineColor()
        {
            return new Color(0f, 0f, 0f, 0f);

        }

        public override Color GetWritingColor()
        {
            return Color.white;
        }
    }
}
