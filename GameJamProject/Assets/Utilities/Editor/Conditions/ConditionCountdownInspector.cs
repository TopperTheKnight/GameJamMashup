using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionCountdown))]
public class ConditionCountdownInspector : ConditionInspectorBase
{
    private string explanation = "Use this script to perform an action when an amount of time has passed.";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);
        //EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("countdownTime"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("loop"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("randomInterval"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("min"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("max"));

        GUILayout.Space(10);
        DrawActionLists();

        serializedObject.ApplyModifiedProperties();
    }
}