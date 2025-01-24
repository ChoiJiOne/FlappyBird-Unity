using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 타이틀 움직임을 제어하는 컨트롤러의 프로퍼티를 설정합니다.
/// </summary>
[CustomEditor(typeof(TitleMoveController))]
[CanEditMultipleObjects]
public class TitleMoveControllerEditor : Editor
{
    /// <summary>
    /// 에디터에서 제어할 타이틀 이동 거리입니다.
    /// </summary>
    /// <remarks>
    /// https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SerializedProperty.html
    /// </remarks>
    private SerializedProperty _moveLength;


    /// <summary>
    /// 에디터에서 제어할 타이틀 이동 시간입니다.
    /// </summary>
    private SerializedProperty _moveTime;

    /// <summary>
    /// 에디터에서 제어할 타이틀 이동 거리를 설정합니다.
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
