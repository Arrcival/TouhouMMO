using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items.Equipments
{
    public abstract class AnyItem
    {

        public int Id;
        public Sprite Sprite;

        public abstract Color GetOutlineColor();
        public abstract Color GetWritingColor();

        public void SetSprite(Image image, Outline outline = null)
        {
            image.sprite = Sprite;
            image.color = new Color(1f, 1f, 1f, 1f);
            if (outline != null)
                outline.effectColor = GetOutlineColor();
        }
        // abstract
        public abstract string DisplayName();
        public abstract string DisplayTop();
        public abstract string DisplayBottom();
    }

}
