using System;
using UnityEditor;
using UnityEngine;

public class BaseInspector : Editor
{
    /// <summary>
    /// 把数组或者list的每一项已属性的方式显示在Inspector上
    /// 数组里的索引对应着枚举中的每个索引
    /// </summary>
    /// <param name="array">数组或者List的序列化属性</param>
    /// <param name="type">枚举类型</param>
    /// <param name="label">显示标签</param>
    public void ShowArrayProperty(SerializedProperty array, Type type, string label)
    {
        string[] names = (string[])Enum.GetNames(type);
        int beginSize = array.arraySize;
        array.arraySize = names.Length;

        if (beginSize < names.Length)
        {
            for (int i = beginSize; i < names.Length; i++)
            {
                array.GetArrayElementAtIndex(i).objectReferenceValue = null;
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
        for (int i = 0; i < names.Length; i++)
        {
            SerializedProperty item = array.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(item, new GUIContent(names[i]));
            
        }
    }

    [MenuItem("Tools/ResetPlayerfsx")]
    public static void ResetPlayerfsX()
    {
        PlayerPrefs.DeleteAll();
    }
}