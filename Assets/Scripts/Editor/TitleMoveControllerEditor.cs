using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Ÿ��Ʋ �������� �����ϴ� ��Ʈ�ѷ��� ������Ƽ�� �����մϴ�.
/// </summary>
[CustomEditor(typeof(TitleMoveController))]
[CanEditMultipleObjects]
public class TitleMoveControllerEditor : Editor
{
    /// <summary>
    /// �����Ϳ��� ������ Ÿ��Ʋ �̵� �Ÿ��Դϴ�.
    /// </summary>
    /// <remarks>
    /// https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SerializedProperty.html
    /// </remarks>
    private SerializedProperty _moveLength;


    /// <summary>
    /// �����Ϳ��� ������ Ÿ��Ʋ �̵� �ð��Դϴ�.
    /// </summary>
    private SerializedProperty _moveTime;

    /// <summary>
    /// �����Ϳ��� ������ Ÿ��Ʋ �̵� �Ÿ��� �����մϴ�.
    /// </summary>
    private void OnEnable()
    {
        _moveLength = serializedObject.FindProperty("_moveLength");
        _moveTime = serializedObject.FindProperty("_moveTime");
    }

    /// <summary>
    /// https://docs.unity3d.com/kr/2018.4/Manual/editor-CustomEditors.html
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_moveLength);
        EditorGUILayout.PropertyField(_moveTime);
        serializedObject.ApplyModifiedProperties();
    }
}
