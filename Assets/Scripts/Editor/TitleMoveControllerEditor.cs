using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 에디터에서 타이틀을 움직이는 컨트롤러의 인스펙터 창을 커스텀합니다.
/// </summary>
[CustomEditor(typeof(TitleMoveController))]
[CanEditMultipleObjects]
public class TitleMoveControllerEditor : Editor
{
    /// <summary>
    /// 에디터에서 타이틀을 움직이는 컨트롤러의 이동 높이 값입니다.
    /// </summary>
    /// <remarks>
    /// 참조: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SerializedProperty.html
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