using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Events
{
    /// <summary>
    /// UGUI事件侦听，如有其他侦听事件可以添加进去
    /// 用法： EventTriggerListener.Get(button.gameObject).onClick =OnButtonClick（函数）;
    /// </summary>
    public class EventTriggerListener : EventTrigger
    {
        public delegate void EventDelegate(GameObject go);
        public event EventDelegate onClick;
        public event EventDelegate onDown;
        public event EventDelegate onEnter;
        public event EventDelegate onMove;
        public event EventDelegate onExit;
        public event EventDelegate onPointerUp;
        public event EventDelegate onSelect;
        public event EventDelegate onUpdateSelect;

        public static EventTriggerListener Get(GameObject go)
        {
            EventTriggerListener listener = go.AddComponent<EventTriggerListener>();
            if (listener == null) listener = go.AddComponent<EventTriggerListener>();
            return listener;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            
            base.OnPointerClick(eventData);
            if (onClick != null) onClick(gameObject);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            if (onEnter != null) onEnter(gameObject);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (onDown != null) onDown(gameObject);
        }


        public override void OnMove(AxisEventData eventData)
        {
            base.OnMove(eventData);
            if (onMove != null) onMove(gameObject);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            if (onExit != null) onExit(gameObject);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (onPointerUp != null) onPointerUp(gameObject);
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            if (onSelect != null) onSelect(gameObject);
        }

        public override void OnUpdateSelected(BaseEventData eventData)
        {
            base.OnUpdateSelected(eventData);
            if (onUpdateSelect != null) onUpdateSelect(gameObject);
        }
    }
}

