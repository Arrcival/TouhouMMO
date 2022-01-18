using Assets.Scripts.Items.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TooltipAnyItem : MonoBehaviour
    {
        [SerializeField] Text nameItem;
        [SerializeField] Image image;
        [SerializeField] Text topPart;
        [SerializeField] Text bottomPart;


        public bool IsVisible = false;

        RectTransform canvasRect;
        public RectTransform backgroundRect;
        private void Start()
        {
            canvasRect = transform.parent.GetComponent<RectTransform>();
        }
        public void Display(AnyItem anyItem)
        {
            if (anyItem != null)
            {
                IsVisible = true;
                nameItem.text = anyItem.DisplayName();
                nameItem.color = anyItem.GetWritingColor();
                image.sprite = anyItem.Sprite;
                topPart.text = anyItem.DisplayTop();
                bottomPart.text = anyItem.DisplayBottom();
                gameObject.SetActive(true);
            }
        }

        public void ClearDisplay()
        {
            gameObject.SetActive(false);
            IsVisible = false;
            nameItem.text = string.Empty;
            image.sprite = null;
            topPart.text = string.Empty;
            bottomPart.text = string.Empty;
            nameItem.color = Color.white;
            transform.position = new Vector2(-3000, -3000);
        }

        public void Update()
        {
            if (IsVisible)
            {
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, transform.parent.GetComponent<Canvas>().worldCamera, out localPoint);

                if (localPoint.x + backgroundRect.rect.width > canvasRect.rect.width / 2)
                    localPoint.x = canvasRect.rect.width / 2 - backgroundRect.rect.width;
                if (localPoint.y + backgroundRect.rect.height > canvasRect.rect.height / 2)
                    localPoint.y = canvasRect.rect.height / 2 - backgroundRect.rect.height;

                transform.localPosition = localPoint;
            }
        }
    }

}

