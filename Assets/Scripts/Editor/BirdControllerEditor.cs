using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 플레이어가 제어하는 새의 프로퍼티를 설정합니다.
/// </summary>
[CustomEditor(typeof(BirdController))]
[CanEditMultipleObjects]
public class BirdControllerEditor : Editor
{
    /// <summary>
    /// 새의 점프 속력입니다.
    /// </summary>
    private SerializedProperty _jumpSpeed;

    /// <summary>
    /// 새의 회전 속력입니다.
    /// </summary>
    private SerializedProperty _rotateSpeed;

    /// <summary>
    /// 에디터에서 제어할 점프 속도를 설정합니다.
    /// </summary>
    private void OnEnable()
    {
        _jumpSpeed = serializedObject.FindProperty("_jumpSpeed");
        _rotateSpeed = serializedObject.FindProperty("_rotateSpeed");
    }

    /// <summary>
    /// https://docs.unity3d.com/kr/2018.4/Manual/editor-CustomEditors.html
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_jumpSpeed);
        EditorGUILayout.PropertyField(_rotateSpeed);
        serializedObject.ApplyModifiedProperties();
    }
}