using UnityEngine;
using UnityEditor;

namespace ExcelData
{


}

public class ExcelWindow : EditorWindow
{
    private string ExcelDirectory;
    private string OutputJsonDirectory;
    private string OutputClassDirectory;


    [MenuItem("Tools/ExcelTools/ExcelWindow")]
    private static void Open()
    {
        ExcelWindow window = GetWindow<ExcelWindow>(true, "AssetBundle Builder", true);
        window.minSize = window.maxSize = new Vector2(700f, 570f);
    }

    private void OnGUI()
    {
        GUILayout.Space(10f);
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("Excel文件夹", GUILayout.Width(160f));
                ExcelDirectory = EditorGUILayout.TextField(ExcelDirectory);
                if (GUILayout.Button("Browse...", GUILayout.Width(80f)))
                {
                    string directory = EditorUtility.OpenFolderPanel("Select Output Directory", ExcelDirectory, string.Empty);
                    if (!string.IsNullOrEmpty(directory))
                    {
                        ExcelDirectory = directory;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(5f);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("json输出文件夹", GUILayout.Width(160f));
                OutputJsonDirectory = EditorGUILayout.TextField(OutputJsonDirectory);
                if (GUILayout.Button("Browse...", GUILayout.Width(80f)))
                {
                    string directory = EditorUtility.OpenFolderPanel("Select Output Directory", OutputJsonDirectory, string.Empty);
                    if (!string.IsNullOrEmpty(directory))
                    {
                        OutputJsonDirectory = directory;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(5f);
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField("json输出文件夹", GUILayout.Width(160f));
                OutputClassDirectory = EditorGUILayout.TextField(OutputClassDirectory);
                if (GUILayout.Button("Browse...", GUILayout.Width(80f)))
                {
                    string directory = EditorUtility.OpenFolderPanel("Select Output Directory", OutputClassDirectory, string.Empty);
                    if (!string.IsNullOrEmpty(directory))
                    {
                        OutputClassDirectory = directory;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    //private void BrowseOutputDirectory()
    //{
    //    string directory = EditorUtility.OpenFolderPanel("Select Output Directory", ExcelDirectory, string.Empty);
    //    if (!string.IsNullOrEmpty(directory))
    //    {
    //        ExcelDirectory = directory;
    //    }
    //}


}