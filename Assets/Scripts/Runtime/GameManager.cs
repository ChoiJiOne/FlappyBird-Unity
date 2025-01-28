using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 설정 값 및 이벤트를 관리합니다.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 게임 내의 이동 속력 값에 대한 프로퍼티입니다.
    /// </summary>
    /// <remarks>
    /// 외부에서는 설정할 수 없도록 Getter만 존재합니다.
    /// </remarks>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    /// <summary>
    /// 게임 내의 이동 속력 값입니다
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    private void Awake()
    {
        
    }
}
