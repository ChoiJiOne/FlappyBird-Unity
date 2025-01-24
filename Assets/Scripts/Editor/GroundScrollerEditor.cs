using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 그라운드를 스크롤하는 스크롤러의 프로퍼티를 설정합니다.
/// </summary>
[CustomEditor(typeof(GroundScroller))]
[CanEditMultipleObjects]
public class GroundScrollerEditor : Editor
{
    /// <summary>
    /// 그라운드의 스크롤 속도입니다.
    /// </summary>
    private SerializedProperty _scrollSpeed;

    /// <summary>
    /// 에디터에서 제어할 스크롤 속도를 설정합니다.
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
