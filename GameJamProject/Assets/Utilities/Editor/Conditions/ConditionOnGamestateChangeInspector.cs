using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionOnGamestateChange))]
public class ConditionOnGamestateChangeInspector : ConditionInspectorBase
{
    private string explanation = "Use this script to perform actions when the gamestate changes to the chosen state.";

    public override void OnInspectorGUI()
    {

        serializedObject.Update();


        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        GUILayout.Space(10);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("stateTocheck"));
        GUILayout.Space(10);
        DrawActionLists();

        serializedObject.ApplyModifiedProperties();
    }
}