using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// �÷��̾ �����ϴ� ���� ������Ƽ�� �����մϴ�.
/// </summary>
[CustomEditor(typeof(BirdController))]
[CanEditMultipleObjects]
public class BirdControllerEditor : Editor
{
    /// <summary>
    /// ���� ���� �ӷ��Դϴ�.
    /// </summary>
    private SerializedProperty _jumpSpeed;

    /// <summary>
    /// �����Ϳ��� ������ ���� �ӵ��� �����մϴ�.
    /// </summary>
    private void OnEnable()
    {
        _jumpSpeed = serializedObject.FindProperty("_jumpSpeed");
    }

    /// <summary>
    /// https://docs.unity3d.com/kr/2018.4/Manual/editor-CustomEditors.html
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_jumpSpeed);
        serializedObject.ApplyModifiedProperties();
    }
}