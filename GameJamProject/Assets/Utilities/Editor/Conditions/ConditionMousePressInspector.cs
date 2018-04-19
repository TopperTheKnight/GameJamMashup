using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionMousePress))]
public class ConditionMousePressInspector : ConditionInspectorBase
{
    private string explanation = "Use this script to perform an action when a button on the mouse is pressed, released, or as long as it's kept pressed (in this case you get to choose the frequency).";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("happenOnlyOnce"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("mouseToPress"));

        //discern the event type, and show the frequency if needed
        EditorGUILayout.PropertyField(serializedObject.FindProperty("eventType"));
        int eventType = serializedObject.FindProperty("eventType").intValue;
        if (eventType == 2)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));
        }


        GUILayout.Space(10);
        DrawActionLists();

        serializedObject.ApplyModifiedProperties();
    }
}