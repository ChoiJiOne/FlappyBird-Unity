using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 파이프 오브젝트를 제어합니다.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// 파이프의 이동 속도입니다.
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    /// <summary>
    /// 파이프가 움직일 수 있는지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 파이프 오브젝트가 움직일 수 있다면 true, 그렇지 않으면 false입니다.
    /// </remarks>
    private bool _canMove = true;

    private void Start()
    {
        
    }

    private void Update()
    {
    }
}
