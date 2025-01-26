using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 게임 컨트롤러가 제어 가능한 오브젝트입니다.
/// </summary>
/// <remarks>
/// 플레이 씬 내에서 게임 컨트롤러가 제어해야 할 오브젝트는 이 클래스를 상속받아야 합니다.
/// </remarks>
public class ControllableObject : MonoBehaviour
{
    /// <summary>
    /// 게임 컨트롤러 오브젝트입니다.
    /// </summary>
    protected GameController _gameController;

    /// <summary>
    /// 게임 오브젝트 컨트롤러를 초기화합니다.
    /// </summary>
    protected void Awake()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
}
