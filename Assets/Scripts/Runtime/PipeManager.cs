using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 내의 파이프 오브젝트를 관리합니다.
/// </summary>
public class PipeManager : MonoBehaviour
{
    /// <summary>
    /// 파이프의 이동 속력을 설정하는 프로퍼티입니다.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// 파이프의 프리팹 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _pipePrefab;

    /// <summary>
    /// 파이프 끝 위치의 X좌표 값입니다.
    /// </summary>
    [SerializeField]
    private float _endXPosition;

    /// <summary>
    /// 파이프의 이동 속도입니다.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// 파이프 매니저가 관리하는 파이프의 개수입니다.
    /// </summary>
    [SerializeField]
    private int _pipeCount;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
