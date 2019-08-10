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
        public List<ImageItem> imageItems=new List<ImageItem>();


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeSprite(ImageType _imageType)
        {
            Sprite _sprite = imageItems.Find(o => o.imageType == _imageType).sprite;
            if(_sprite != null)
            {
                GetComponent<Image>().sprite = _sprite;
            }
            else
            {
                Debug.LogError(string.Format("The _imageType {0} sprite is null,please add the sprite to the imageItems list！！！",_imageType));
            }
        }
    }

}


