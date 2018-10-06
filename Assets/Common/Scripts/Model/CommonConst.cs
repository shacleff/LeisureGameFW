//#define DEVELOPMENT
public class CommonConst
{
    public const iTween.DimensionMode ITWEEN_MODE = iTween.DimensionMode.mode2D;

#if DEVELOPMENT
    public const bool ENCRYPTION_PREFS = false;
    public const int MIN_LEVEL_TO_RATE = 1;
#else
#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR
    public const bool ENCRYPTION_PREFS = true;
#else
    public const bool ENCRYPTION_PREFS = false;
#endif
    public const int MIN_LEVEL_TO_RATE = 3;
#endif
}
