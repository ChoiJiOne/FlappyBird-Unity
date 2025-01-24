using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// �׶��带 ��ũ���ϴ� ��ũ�ѷ��� ������Ƽ�� �����մϴ�.
/// </summary>
[CustomEditor(typeof(GroundScroller))]
[CanEditMultipleObjects]
public class GroundScrollerEditor : Editor
{
    /// <summary>
    /// �׶����� ��ũ�� �ӵ��Դϴ�.
    /// </summary>
    private SerializedProperty _scrollSpeed;

    /// <summary>
    /// �����Ϳ��� ������ ��ũ�� �ӵ��� �����մϴ�.
    /// </summary>
    private void OnEnable()
    {
        _scrollSpeed = serializedObject.FindProperty("_scrollSpeed");
    }

    /// <summary>
    /// https://docs.unity3d.com/kr/2018.4/Manual/editor-CustomEditors.html
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_scrollSpeed);
        serializedObject.ApplyModifiedProperties();
    }
}
