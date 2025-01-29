using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI의 움직임을 제어합니다.
/// </summary>
public class UIMoveController : MonoBehaviour
{
    /// <summary>
    /// UI의 이동 시간입니다.
    /// </summary>
    /// <remarks>
    /// 시간의 단위는 초 단위입니다.
    /// </remarks>
    [SerializeField]
    private float _moveTime;

    /// <summary>
    /// UI의 시작 위치입니다.
    /// </summary>
    private Vector2 _startPosition;

    /// <summary>
    /// UI의 도착 위치입니다.
    /// </summary>
    [SerializeField]
    private Vector2 _endPosition;

    /// <summary>
    /// UI가 이동하는 동안 누적된 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 이 값은 _moveTime 값을 넘어설 수 없습니다.
    /// </remarks>
    private float _moveStepTime = 0.0f;

    /// <summary>
    /// UI의 위치를 
    /// </summary>
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
