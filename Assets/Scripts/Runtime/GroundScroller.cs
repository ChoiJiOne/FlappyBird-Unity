using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 그라운드(바닥)의 스크롤링을 수행합니다.
/// </summary>
/// <remarks>
/// 참조: https://stackoverflow.com/questions/36947732/scroll-2d-3d-background-via-texture-offset
/// </remarks>
public class GroundScroller : MonoBehaviour
{
    /// <summary>
    /// 그라운드의 움직임을 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// 그라운드의 스크롤 속도입니다.
    /// </summary>
    public float _scrollSpeed = 1.0f;

    /// <summary>
    /// 셰이더에 전달될 그라운드 텍스처의 오프셋 값입니다.
    /// </summary>
    private Vector2 _textureOffset = Vector2.zero;

    /// <summary>
    /// 스크롤을 수행할 그라운드의 재질입니다.
    /// </summary>
    private Material _groundMaterial;

    /// <summary>
    /// 재질의 텍스처 오프셋을 변경할 때 사용할 렌더러입니다.
    /// </summary>
    private Renderer _renderer;

    /// <summary>
    /// 그라운드의 움직임 여부를 확인합니다.
    /// </summary>
    private bool _canMove = true;

    /// <summary>
    /// 스크롤링에 필요한 렌더러와 매터리얼을 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _groundMaterial = _renderer.material;
    }

    /// <summary>
    /// 그라운드의 횡 스크롤링을 수행합니다.
    /// </summary>
    private void Update()
    {
        if (!_canMove)
        {
            return;
        }

        _textureOffset.x = _groundMaterial.mainTextureOffset.x + _scrollSpeed * Time.deltaTime;
        if (_textureOffset.x >= 1.0f)
        {
            _textureOffset.x -= 1.0f;
        }

        _groundMaterial.mainTextureOffset = _textureOffset;
    }
}
