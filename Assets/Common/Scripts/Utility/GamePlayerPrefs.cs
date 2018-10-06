public class GamePlayerPrefs
{
    private const string BUY_ITEM = "buy_item";
    private const string CURR_ITEM = "curr_item";
    private const string IS_RANDOM_ITEM = "is_random_item";
    private const string ITEM_COUNT = "item_count";

    private const string BUY_THEME = "buy_theme";
    private const string CURR_THEME = "curr_theme";
    private const string IS_RANDOM_THEME = "is_random_theme";
    private const string THEME_COUNT = "theme_count";


    public static void SetCoin(int _coin)
    {
       
        CPlayerPrefs.SetInt("COINS", _coin);
    }

    public static int GetCoin()
    {
        return CPlayerPrefs.GetInt("COINS", 1000);
    }

    public static int GetBestScore()
    {
        return CPlayerPrefs.GetInt("best_score", 0);
    }

    public static void SetBestScore(int newscore)
    {
        int best = GetBestScore();
        if (newscore > best)
            CPlayerPrefs.SetInt("best_score", newscore);
    }
    /// <summary>
    /// 判断是否已经购买
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static bool IsBuyedItem(int index)
    {
        return CPlayerPrefs.GetBool(BUY_ITEM + index, index == 0 ? true : false);
    }

    /// <summary>
    /// 设置该Item购买情况
    /// </summary>
    /// <param name="index"></param>
    public static void SetBuyedItem(int index)
    {
        CPlayerPrefs.SetBool(BUY_ITEM + index, true);
    }

    public static bool IsBuyTheme(int index)
    {
        return CPlayerPrefs.GetBool(BUY_THEME + index, index == 0 ? true : false);
    }

    public static void SetBuyedTheme(int index)
    {
        CPlayerPrefs.SetBool(BUY_THEME + index, true);
    }

    /// <summary>
    /// 获得当前选择的Item
    /// </summary>
    /// <param name="index"></param>
    public static void SetCurrItem(int index)
    {
        CPlayerPrefs.SetInt(CURR_ITEM, index);
    }

    /// <summary>
    /// 设置当前选择的Item
    /// </summary>
    /// <returns></returns>
    public static int GetCurrItem()
    {
        return CPlayerPrefs.GetInt(CURR_ITEM, 0);
    }

    public static void SetCurrTheme(int index)
    {
        CPlayerPrefs.SetInt(CURR_THEME, index);
    }

    public static int GetCurrTheme()
    {
        return CPlayerPrefs.GetInt(CURR_THEME, 0);
    }

    /// <summary>
    /// 是否随机选择Item
    /// </summary>
    /// <param name="isRandom"></param>
    public static void SetIsRandomItem(bool isRandom)
    {
        CPlayerPrefs.SetBool(IS_RANDOM_ITEM, isRandom);
    }

    /// <summary>
    /// 是否随机选择Item
    /// </summary>
    /// <returns></returns>
    public static bool IsRandomItem()
    {
        return CPlayerPrefs.GetBool(IS_RANDOM_ITEM, false);
    }

    public static void SetIsRandomTheme(bool isRandom)
    {
        CPlayerPrefs.SetBool(IS_RANDOM_THEME, isRandom);
    }

    public static bool IsRandomTheme()
    {
        return CPlayerPrefs.GetBool(IS_RANDOM_THEME, false);
    }

    public static void SetItemCount(int _count)
    {
        CPlayerPrefs.SetInt(ITEM_COUNT, _count);
    }

    public static int GetItemCount()
    {
        return CPlayerPrefs.GetInt(ITEM_COUNT, 1);
    }

    public static void SetThemeCount(int _count)
    {
        CPlayerPrefs.SetInt(THEME_COUNT, _count);
    }

    public static int GetThemeCount()
    {
        return CPlayerPrefs.GetInt(THEME_COUNT, 1);
    }
}