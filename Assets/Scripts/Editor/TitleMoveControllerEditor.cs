using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// �����Ϳ��� Ÿ��Ʋ�� �����̴� ��Ʈ�ѷ��� �ν����� â�� Ŀ�����մϴ�.
/// </summary>
[CustomEditor(typeof(TitleMoveController))]
[CanEditMultipleObjects]
public class TitleMoveControllerEditor : Editor
{
    /// <summary>
    /// �����Ϳ��� Ÿ��Ʋ�� �����̴� ��Ʈ�ѷ��� �̵� ���� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// ����: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SerializedProperty.html
    /// </remarks>

    private SerializedProperty _moveHeight;

    void OnEnable()
    {
        _moveHeight = serializedObject.FindProperty("_moveHeight");
    }

    /// <summary>
    /// https://docs.unity3d.com/kr/2018.4/Manual/editor-CustomEditors.html
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_moveHeight);
        serializedObject.ApplyModifiedProperties();
    }
}