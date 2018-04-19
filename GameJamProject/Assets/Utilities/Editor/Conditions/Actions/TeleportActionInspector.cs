using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(TeleportAction))]
public class TeleportActionInspector : BaseInspectorWindow
{
	private string explanation = "Use this script to teleport this or another object to a new location.";
	private string objectWarning = "No assigned object; this object will be teleported instead.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("objectToMove"));

		if(!CheckIfAssigned("objectToMove", false))
		{
			EditorGUILayout.HelpBox(objectWarning, MessageType.Info);
		}

		EditorGUILayout.PropertyField(serializedObject.FindProperty("newPosition"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("stopMovements"));

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
