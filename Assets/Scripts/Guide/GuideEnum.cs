

public enum GuideType
{
    SelectRole=0,
    ClickMission=1,
    SelectEnemy=2,
    Attack=3,

}

/// <summary>
/// 某个按钮
/// 某个界面
/// 满足某些条件（等级，任务等）
/// 收集或者使用了某些道具，装备
/// </summary>
public enum TriggerType
{
    OpenUI,
    ClickButton,
    Collect,
    LevelSatisfy,
    UseItem,
}


