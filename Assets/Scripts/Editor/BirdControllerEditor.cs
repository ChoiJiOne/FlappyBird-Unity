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
}
