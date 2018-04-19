using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoObjectSpawner))]
public class AutoObjectSpawnerInspector : BaseInspectorWindow
{

	private string explanation = "Spawns an object repeatedly in a square area. The size of the area is defined by Minimum and Maximum, while Spawn Interval defines the delay of spawning.";
	
	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		ShowPrefabWarning("prefabToSpawn");

        //base.OnInspectorGUI();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("prefabToSpawn"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("spawnInterval"));

        GUILayout.Space(5);

        bool eksponentielSpawnTemp = EditorGUILayout.Toggle("Exponential Spawn", serializedObject.FindProperty("exponentialSpawn").boolValue);

        if (eksponentielSpawnTemp)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("timeMod"));
        }
        serializedObject.FindProperty("exponentialSpawn").boolValue = eksponentielSpawnTemp;

        serializedObject.ApplyModifiedProperties();

    }

}
