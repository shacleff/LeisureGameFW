using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuideSystem : MonoSingleton<GuideSystem>
{

    public MaskFocus maskFocus;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        GuideDataManager.GetInstance().Init();
    }


    /// <summary>
    /// 触发事件，由游戏的各个系统调用
    /// </summary>
    public void CheckTrigger(TriggerType _triggerType,params object[] args)
    {
        EventManager.Instance.DispatchEvent(GuideEvent.OPEN_UI_PANEL, args);
    }

    /// <summary>
    /// 响应事件的回调
    /// </summary>
    public void OnTrigger(params object[] args)
    {

    }

    public void PerformStep()
    {

    }

    public void IsInGuide()
    {

    }

    public void Pause()
    {

    }

    public void Resume()
    {

    }

    public void FocusUI(IEnumerable<UIBehaviour> uis, float radiusMultiplier = 1f, bool instant = false)
    {
        maskFocus.Activate();
        maskFocus.FocusUI(uis, radiusMultiplier, instant);
    }

    public void CloseFocusUI()
    {
        maskFocus.Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
