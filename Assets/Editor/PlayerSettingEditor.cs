using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSettingEditor : Editor
{

    [MenuItem("Tools/Reset PlayerPrefs", false)]
    public static void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("*** PlayerPrefs was reset! ***");
    }


}
