using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace UIExtension
{

    public class ButtonComponent : MonoBehaviour
    {

        public Image bgImage;
        public Image coinImage;

        public List<ButtonImage> extensionButtons = new List<ButtonImage>();
        private Dictionary<ButtonStatus, ButtonImage> keyValuePairs = new Dictionary<ButtonStatus, ButtonImage>();

        private void Awake()
        {
            for (int i = 0; i < extensionButtons.Count; i++)
            {
                keyValuePairs.Add(extensionButtons[i].buttonStatus, extensionButtons[i]);
            }
        }

        public void SetButtonStatus(ButtonStatus buttonStatus)
        {
            bgImage.sprite = keyValuePairs[buttonStatus].BgImage;
            coinImage.sprite = keyValuePairs[buttonStatus].CoinImage;

            GetComponent<Button>().interactable = buttonStatus == ButtonStatus.Normal ? true : false;
        }

        private void Update()
        {

        }
    }

    [Serializable]
    public class ButtonImage
    {
        public ButtonStatus buttonStatus;
        public Sprite BgImage;
        public Sprite CoinImage;

    }
    public enum ButtonStatus
    {
        Normal = 0,
        Gray = 1,
    }
}





