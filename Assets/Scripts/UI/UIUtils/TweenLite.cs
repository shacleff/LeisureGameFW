using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Tween
{
    public static class TweenLite
    {

        public static Tweener Move(this GameObject _obj,int _offset,float _timer)
        {
            return _obj.GetComponent<RectTransform>().DOAnchorPosY(_offset, _timer);
        }

    }

}


