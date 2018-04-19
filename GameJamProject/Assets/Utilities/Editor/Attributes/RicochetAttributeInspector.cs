using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(RicochetAttribute))]
public class RicochetAttributeInspector: BaseInspectorWindow
{
	private string explanation = "This object will bounce off coliders with the chosen tag a number of times without losing momentum, after which it will be destroyed. -1 will bounce forever. NOTE: This ignores physics!";
	public override void OnInspectorGUI()
	{
        var ricoAttr = target as RicochetAttribute;

        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        ricoAttr.TagToRicochetOff = EditorGUILayout.TagField("Tag: ", ricoAttr.TagToRicochetOff);
        base.OnInspectorGUI();
    }
}
