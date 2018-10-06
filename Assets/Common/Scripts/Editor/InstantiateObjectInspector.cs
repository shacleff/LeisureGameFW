using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InstantiateObject))]
[CanEditMultipleObjects]
public class InstantiateObjectInspector : Editor
{
    public SerializedProperty repeat;
    public SerializedProperty infinity;
    public SerializedProperty numofRepeat;
    public SerializedProperty durationOfEachRepeat;

    private void OnEnable()
    {
        repeat = serializedObject.FindProperty("repeat");
        infinity = serializedObject.FindProperty("infinity");
        numofRepeat = serializedObject.FindProperty("numRepeat");
        durationOfEachRepeat = serializedObject.FindProperty("gapTime");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("实例化对象组件，应用于实例化多次");
        base.OnInspectorGUI();
        serializedObject.Update();
       
        InstantiateObject targ = target as InstantiateObject;
        EditorGUILayout.Space();
        repeat.boolValue = EditorGUILayout.BeginToggleGroup("Repeat", targ.repeat);
        infinity.boolValue = EditorGUILayout.Toggle("Infinity", targ.infinity);
        EditorGUI.BeginDisabledGroup(targ.infinity);
        numofRepeat.intValue = EditorGUILayout.IntField("Num Repeat", targ.numRepeat);
        EditorGUI.EndDisabledGroup();
        durationOfEachRepeat.floatValue = EditorGUILayout.FloatField("Gap Time", targ.gapTime);
        EditorGUILayout.EndToggleGroup();

        serializedObject.ApplyModifiedProperties();
    }
}