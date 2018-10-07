

/// <summary>
/// 物品类型
/// </summary>
public enum ItemType
{
    /// <summary>
    /// 装备
    /// </summary>
    Equip=1,
    /// <summary>
    /// 消耗品
    /// </summary>
    Expend=2,
    /// <summary>
    /// 宝石
    /// </summary>
    Gem=3,
    /// <summary>
    /// 礼包
    /// </summary>
    Packs=4,
    /// <summary>
    /// 材料
    /// </summary>
    Material=5,
    /// <summary>
    /// 制作的东西
    /// </summary>
    Produce=6,
    /// <summary>
    /// 宠物
    /// </summary>
    Pet=7,
    /// <summary>
    /// 任务物品
    /// </summary>
    Task=8,
    /// <summary>
    /// 宠物装备
    /// </summary>
    PetEquip=9
}

/// <summary>
/// 物品品质
/// </summary>
public enum ItemQuality
{
    White=1,
    Green=2,
    Blue=3,
    Purple=4,
    Orange=5,
}

/// <summary>
/// 反馈
/// </summary>
public enum FeedBack
{
    /// <summary>
    /// 没有
    /// </summary>
    None=0,
    /// <summary>
    /// 文本提示
    /// </summary>
    Text=1,
    /// <summary>
    /// 快捷购买+获取提示
    /// </summary>
    DoubleDialog=2,
    /// <summary>
    ///快捷购买
    /// </summary>
    QuickBuy=3,
    /// <summary>
    /// 获取途径
    /// </summary>
    FindInfo=4
}

/// <summary>
/// 任务职业
/// </summary>
public enum Character_Career
{
    ROLE_BEGIN=0,
    /// <summary>
    /// 剑士
    /// </summary>
    ROLE_SWORD=1,
    /// <summary>
    /// 弓箭手
    /// </summary>
    ROLE_ARCHER=2,
    /// <summary>
    /// 法师
    /// </summary>
    ROLE_MAGICIAN=3,
    ROLE_END
}

/// <summary>
/// 物品数据模版
/// </summary>
public struct ItemTemplate
{
    public uint ID;                                 //物品ID
    public string Name;                             //物品名称
    public ItemType itemType;                       //物品类型
    public EPackageNavType packageNavType;          //物品格子类型
    public string Icon;                             //图标
    public string Model;                            //模型
    public ItemQuality Quality;                     //品质
    public uint UsedLevel;                          //使用等级
    public uint OverlapNum;                         //堆叠上线
    public uint SilivePrice;                        //出售价格
    public uint SaleProtect;                        //出售保护
    public uint UsedCD;                             //使用CD
    public uint UsedEffect;                         //使用特效
    public uint ItemLoot;                           //掉了索引
    public string Discription;                      //详细说明
    public string ItemSource;                       //物品来源
    public uint TypeRank;                           //物品排序ID
    public Character_Career Career;                 //物品对应的职业
    public FeedBack feedBack;                       //物品不足的提示类型
    public uint FeedBackShopID;                     //反馈商品ID
    //public BetterList<int> FeedBackFunctionID; 便捷提示ID
    public bool CanTips;                            //是否有提示
}


public class XmlDataItem : XmlDataBase
{

    
    public override void AppendAttribute(int _id, string _key, string _value)
    {

        ItemTemplate template;
        if(!data.ContainsKey(_id))
        {
            template = new ItemTemplate();
            data.Add(_id, template);
        }
        else
        {
            template = (ItemTemplate)data[_id];
        }
        switch (_key)
        {
            case "ID":
                template.ID = uint.Parse(_value);
                break;
            case "Name":
                template.Name = _value;
                break;
            case "ItemType":
                template.itemType = (ItemType)int.Parse(_value);
                break;
            case "Icon":
                template.Icon = _value;
                break;
            case "ItemPre":
                template.Model = _value;
                break;
            case "Quality":
                template.Quality = (ItemQuality)int.Parse(_value);
                break;
            case "UsedLevel":
                template.UsedLevel = uint.Parse(_value);
                break;
            case "OverlapNum":
                template.OverlapNum = uint.Parse(_value);
                break;
            case "SiliverPrice":
                template.SilivePrice = uint.Parse(_value);
                break;
            case "UsedCD":
                template.UsedCD = uint.Parse(_value);
                break;
            case "UsedEffect":
                template.UsedEffect = uint.Parse(_value);
                break;
            case "ItemLoot":
                template.ItemLoot = uint.Parse(_value);
                break;
            case "Discription":
                template.Discription = _value;
                break;
            case "source":
                template.ItemSource = _value;
                break;
            case "ItemBagType":
                template.packageNavType = (EPackageNavType)int.Parse(_value);
                break;
            case "TypeRank":
                template.TypeRank = uint.Parse(_value);
                break;
            case "UsedZhiYe":
                template.Career = (Character_Career)int.Parse(_value);
                break;
            case "SaleProtect":
                template.SaleProtect = uint.Parse(_value);
                break;
            case "FeedBackType":
                template.feedBack = (FeedBack)int.Parse(_value);
                break;
            case "FeedBackValue_shop":
                template.FeedBackShopID = uint.Parse(_value);
                break;
            case "FeedBackValue_function":
                break;
            case "tishi":
                template.CanTips = _value == "1" ? true : false;
                break;
            default:
                break;
        }
        data[_id] = template;
    }

    public override string GetRootNodeName()
    {
        return base.GetRootNodeName();
    }

    public override bool HasValue(int key)
    {
        return base.HasValue(key);

        
    }
}

public enum EPackageNavType
{
    Weapon=1,
    Equip=2,
    Other=3,
    PetEquip=4
}

public class ItemManager
{
    
}
