using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Dash))]
public class DashInspector : BaseInspectorWindow
{
    private string explanation = "Makes the gameObject dash forward at the press of a button.";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("key"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dashStrength"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cooldown"));

        serializedObject.ApplyModifiedProperties();
    }
}
