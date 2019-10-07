using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RankPanel : BasePanel
{


    public override void Awake()
    {
        base.Awake();
        mCurrUItype.PanelShowMode = UIPanelShowMode.HideOther;
    }

    public override void Start()
    {
        base.Start();
    }

    protected override void ClosePanelHandle(GameObject go)
    {
        base.ClosePanelHandle(go);
    }


}
