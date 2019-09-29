using UnityEditor;

using System.IO;

using System.Collections;

using UnityEngine;

using System.Collections.Generic;

class PerformBuild

{

    static string[] GetBuildScenes()

    {

        List<string> names = new List<string>();

        foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)

        {

            if (e == null)

                continue;

            if (e.enabled)

                names.Add(e.path);

        }

        return names.ToArray();

    }

    static string GetBuildPath()

    {

        string dirPath = Application.dataPath + "/../build/iPhone";

        if (!System.IO.Directory.Exists(dirPath))

        {

            System.IO.Directory.CreateDirectory(dirPath);

        }

        return dirPath;

    }

    [UnityEditor.MenuItem("Tools/PerformBuild/Test Command Line Build iPhone Step")]

    static void CommandLineBuild()

    {

        Debug.Log("Command line build\n------------------\n------------------");

        string[] scenes = GetBuildScenes();

        string path = GetBuildPath();

        if (scenes == null || scenes.Length == 0 || path == null)

            return;

        Debug.Log(string.Format("Path: \"{0}\"", path));

        for (int i = 0; i < scenes.Length; ++i)

        {

            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));

        }

        Debug.Log("Starting Build!");

        BuildPipeline.BuildPlayer(scenes, path, BuildTarget.iOS, BuildOptions.None);

    }


    [UnityEditor.MenuItem("Tools/PerformBuild/Test Command Line Build Step Android")]

    static void CommandLineBuildAndroid()
    {

        Debug.Log("Command line build android version\n------------------\n------------------");
        string[] scenes = GetBuildScenes();
        if (scenes == null || scenes.Length == 0)
        {
            Debug.LogError("Please add scene to buildsetting...");
            return;

        }
        // keystore 路径, G:\keystore\one.keystore
        PlayerSettings.Android.keystoreName = "D:\\CompanyProject\\_Temp\\RollingGalaxy\\Sg3.keystore";
        // one.keystore 密码
        PlayerSettings.Android.keystorePass = "morefuntek";
        // one.keystore 别名
        PlayerSettings.Android.keyaliasName = "Sg3.keystore";
        // 别名密码
        PlayerSettings.Android.keyaliasPass = "morefuntek";
        for (int i = 0; i < scenes.Length; ++i)
        {
            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
        }
        Debug.Log("Starting Android Build!");
        BuildPipeline.BuildPlayer(scenes, PlayerSettings.productName+".apk", BuildTarget.Android, BuildOptions.None);
        AssetDatabase.Refresh();

    }

}