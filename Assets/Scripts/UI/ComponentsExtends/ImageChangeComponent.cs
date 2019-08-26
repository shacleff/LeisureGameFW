using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UIExtension
{
    public enum ImageType
    {
        Type_1,
        Type_2,
        Type_3
    }

    [Serializable]
    public class ImageItem
    {
        [Header("对应每一种状态")]
        public ImageType imageType;
        public Sprite sprite;
    }


    public class ImageChangeComponent : MonoBehaviour
    {
        [Header("设置图片状态，正常、高亮、其他")]
        public List<ImageItem> imageItems = new List<ImageItem>();


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 改变按钮图片
        /// </summary>
        /// <param name="_imageType"></param>
        public void ChangeSprite(ImageType _imageType)
        {
            Sprite _sprite = imageItems.Find(o => o.imageType == _imageType).sprite;
            SetSprite(_sprite);
        }

        /// <summary>
        /// 设置按钮状态图片
        /// </summary>
        /// <param name="_imageType"></param>
        public void ChangeButtonState(ImageType _imageType)
        {
            Sprite _sprite = imageItems.Find(o => o.imageType == _imageType).sprite;
            SetSprite(_sprite);
            SetButtonState(_imageType);
        }

        /// <summary>
        /// 设置按钮状态图片与文本
        /// </summary>
        /// <param name="_imageType"></param>
        /// <param name="_msg"></param>
        public void ChangeButtonStateAndChildTxt(ImageType _imageType, string _msg)
        {
            Sprite _sprite = imageItems.Find(o => o.imageType == _imageType).sprite;
            SetSprite(_sprite);
            SetButtonState(_imageType);
            SetTxt(_msg);
        }

        /// <summary>
        /// 设置按钮图片
        /// </summary>
        /// <param name="_sprite"></param>
        private void SetSprite(Sprite _sprite)
        {
            if (_sprite != null)
            {
                GetComponent<Image>().sprite = _sprite;
            }
            else
            {
                Debug.LogError(string.Format("The _imageType {0} sprite is null,please add the sprite to the imageItems list！！！", _sprite.name));
            }
        }

        /// <summary>
        /// 更改按钮交互状态（可点与不可点)
        /// </summary>
        /// <param name="_imageType"></param>
        private void SetButtonState(ImageType _imageType)
        {
            if (GetComponent<Button>() != null)
            {
                if (_imageType == ImageType.Type_1)
                {
                    GetComponent<Button>().interactable = true;
                }
                else
                {
                    GetComponent<Button>().interactable = false;
                }
            }
        }

        /// <summary>
        /// 设置按钮子对象文本
        /// </summary>
        /// <param name="_msg"></param>
        private void SetTxt(string _msg)
        {
            if (GetComponentInChildren<Text>() != null) GetComponentInChildren<Text>().text = _msg;
        }

    }

}


