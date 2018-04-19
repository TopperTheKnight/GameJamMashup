using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(IgnoreCollisionAttribute))]
public class IgnoreCollisionAttributeInspector: BaseInspectorWindow
{
	private string explanation = "This object will bounce off coliders with the chosen tag a number of times without losing momentum, after which it will be destroyed. -1 will bounce forever.";

    private ReorderableList rList;

    private void OnEnable()
    {
        var ignColAtr = target as IgnoreCollisionAttribute;

        rList = new ReorderableList(serializedObject,
                serializedObject.FindProperty("layersToIgnore"),
                true, true, true, true);

        rList.drawHeaderCallback = rect => {
            EditorGUI.LabelField(rect, "Colliders to ignore");
        };

        rList.drawElementCallback =
        (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            rect.y += 2;

            var element = rList.serializedProperty.GetArrayElementAtIndex(index);
            var value = EditorGUI.LayerField(
                new Rect(rect.x, rect.y, rect.width, 
                EditorGUIUtility.singleLineHeight), 
                element.intValue);

            ignColAtr.layersToIgnore[index] = value;

        };
    }

    public override void OnInspectorGUI()
	{

        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        GUILayout.Space(10);

        var ignColAtr = target as IgnoreCollisionAttribute;

        var layerNum = EditorGUILayout.LayerField("Target layer: ", serializedObject.FindProperty("layerNum").intValue);
        ignColAtr.layerNum = layerNum;

        serializedObject.Update();
        rList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();

    }
}
