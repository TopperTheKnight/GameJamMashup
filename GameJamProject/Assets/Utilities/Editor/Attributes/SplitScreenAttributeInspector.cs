using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(SplitScreenAttribute))]
public class SplitScreenAttributeInspector: BaseInspectorWindow
{
	private string explanation = "When this is assigned to a camera, the screen will split into 2 to 4 parts, following the respective tagged players.";

	public override void OnInspectorGUI()
	{
        var numberOfPlayers = target as SplitScreenAttribute;

        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        numberOfPlayers.numberOfPlayers = EditorGUILayout.IntField("Number of players: ", numberOfPlayers.numberOfPlayers);

        base.OnInspectorGUI();
    }
}
