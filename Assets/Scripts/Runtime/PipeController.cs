using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 파이프의 움직임을 제어합니다.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// 파이프의 움직임을 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    /// <summary>
    /// 파이프의 움직임 여부입니다.
    /// </summary>
    private bool _canMove = false;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
