using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptEditor
{
    static void CleanupMissingScripts()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            var gameObject = Selection.gameObjects[i];
            // We must use the GetComponents array to actually detect missing components
            var components = gameObject.GetComponents<Component>();
            // Create a serialized object so that we can edit the component list
            var serializedObject = new SerializedObject(gameObject);
            // Find the component list property
            var prop = serializedObject.FindProperty("m_Component");
            // Track how many components we've removed
            int r = 0;
            // Iterate over all components
            for (int j = 0; j < components.Length; j++)
            {
                // Check if the ref is null
                if (components[j] == null)
                {
                    Debug.Log(components[j].name);
                    // If so, remove from the serialized component array
                    prop.DeleteArrayElementAtIndex(j - r);
                    // Increment removed count
                    r++;
                }
            }
            // Apply our changes to the game object
            serializedObject.ApplyModifiedProperties();
        }
    }

    [MenuItem("Edit/CleanMissing Scripts")]
    public static void CleanMissScript()
    {
        GameObject obj = Selection.activeObject as GameObject;
        foreach (Transform child in obj.transform)
        {
            Debug.Log("child name: "+child.name);
            var components = child.GetComponents<Component>();
            int r = 0;
            for (int i = 0; i <components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.Log(components[i].name);
                    GameObject.Destroy(components[i]);
                    r--;
                }
                    
            }
        }
    }
}
