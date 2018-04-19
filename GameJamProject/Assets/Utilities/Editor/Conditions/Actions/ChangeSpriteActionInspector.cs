using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ChangeSpriteAction))]
public class ChangeSpriteActionInspector : BaseInspectorWindow
{
    private string explanation = "Use this script to change a gameObject's sprite to a new specific sprite.";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);
        base.OnInspectorGUI();
    }
}

