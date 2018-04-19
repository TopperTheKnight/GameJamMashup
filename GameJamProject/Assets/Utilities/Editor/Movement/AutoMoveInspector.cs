using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoMove))]
public class AutoMoveInspector : BaseInspectorWindow
{
    private string explanation = "The gameObject moves automatically in a specific direction. If you want it to bounce off walls, make sure to toggle 'Reverse direction on collision'.";

    public override void OnInspectorGUI()
    {
        var autoMove = target as AutoMove;
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();

        autoMove.reverseDirectionOnCollision = EditorGUILayout.Toggle("Reverse Direction On Collision", autoMove.reverseDirectionOnCollision);

        if (autoMove.reverseDirectionOnCollision)
        {
            autoMove.filterByTag = EditorGUILayout.Toggle("Filter by Specific Tag", autoMove.filterByTag);

            if (autoMove.filterByTag)
            {
                autoMove.filterTag = EditorGUILayout.TagField("Tag to check for", autoMove.filterTag);
            }
        }
    }
}