using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 그라운드를 제어합니다.
/// </summary>
/// <remarks>
/// 주로 횡 스크롤 속도 및 충돌 처리를 수행합니다.
/// </remarks>
public class GroundController : MonoBehaviour
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
    /// 그라운드의 움직임 여부를 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// 그라운드 오브젝트의 이동(스크롤링) 속력입니다.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// 그라운드 오브젝트의 스크롤 이동 거리입니다.
    /// </summary>
    private float _scrollLength;

    /// <summary>
    /// 셰이더에 전달할 그라운드 텍스처의 오프셋 값입니다.
    /// </summary>
    private Vector2 _textureOffset = Vector2.zero;

    /// <summary>
    /// 그라운드 오브젝트의 재질입니다.
    /// </summary>
    private Material _material;

    /// <summary>
    /// 재질의 텍스처 오프셋 값을 제어할 때 사용할 렌더러입니다.
    /// </summary>
    private Renderer _renderer;
    
    /// <summary>
    /// 그라운드 오브젝트가 움직일 수 있는지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 그라운드 오브젝트가 움직일 수 있다면 true, 그렇지 않으면 false입니다.
    /// </remarks>
    private bool _canMove = true;

    /// <summary>
    /// 스크롤링에 필요한 렌더러와 재질 및 스크롤 이동 거리 값을 초기화합니다.
    /// </summary>
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _scrollLength = _renderer.bounds.size.x;
    }

    /// <summary>
    /// 그라운드의 횡 스크롤을 수행합니다.
    /// </summary>
    /// <remarks>
    /// 움직임 여부가 비활성화 되어 있다면 아무 동작도 수행하지 않습니다.
    /// </remarks>
    private void Update()
    {
        // 움직임이 비활성화 되면 아무 동작도 수행하지 않음.
        if (!_canMove)
        {
            return;
        }

        float scrollSpeed = _moveSpeed / _scrollLength;

        _textureOffset.x = _material.mainTextureOffset.x + scrollSpeed * Time.deltaTime;
        if(_textureOffset.x >= 1.0f)
        {
            _textureOffset.x -= 1.0f;
        }

        _material.mainTextureOffset = _textureOffset;
    }
}
