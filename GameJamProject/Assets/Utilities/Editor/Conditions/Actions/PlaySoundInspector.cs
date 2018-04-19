using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(PlaySoundAction))]
public class PlaySoundActionInspector : BaseInspectorWindow
{
    private string explanation = "Use this script to play a sound from an audio clip.";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);
        base.OnInspectorGUI();

    }
}
