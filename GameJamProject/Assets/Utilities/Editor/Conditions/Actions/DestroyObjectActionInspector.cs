using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(DestroyObjectAction))]
public class DestroyObjectActionInspector : BaseInspectorWindow
{
	private string explanation = "Destroy a specific game object when this action is called. TIP: Can be itself.";
	private string tip = "TIP: You can assign a death effect, such as an explosion or another particle system.";

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		base.OnInspectorGUI();

		if(!CheckIfAssigned("deathEffect", true))
		{
			EditorGUILayout.HelpBox(tip, MessageType.Info);
		}
	}
}
