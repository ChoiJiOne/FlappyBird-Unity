using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �׶���(�ٴ�)�� ��ũ�Ѹ��� �����մϴ�.
/// </summary>
/// <remarks>
/// ����: https://stackoverflow.com/questions/36947732/scroll-2d-3d-background-via-texture-offset
/// </remarks>
public class GroundScroller : MonoBehaviour
{
    /// <summary>
    /// �׶����� �������� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// �׶����� ��ũ�� �ӵ��Դϴ�.
    /// </summary>
    public float _scrollSpeed = 1.0f;

    /// <summary>
    /// ���̴��� ���޵� �׶��� �ؽ�ó�� ������ ���Դϴ�.
    /// </summary>
    private Vector2 _textureOffset = Vector2.zero;

    /// <summary>
    /// ��ũ���� ������ �׶����� �����Դϴ�.
    /// </summary>
    private Material _groundMaterial;

    /// <summary>
    /// ������ �ؽ�ó �������� ������ �� ����� �������Դϴ�.
    /// </summary>
    private Renderer _renderer;

    /// <summary>
    /// �׶����� ������ ���θ� Ȯ���մϴ�.
    /// </summary>
    private bool _canMove = true;

    /// <summary>
    /// ��ũ�Ѹ��� �ʿ��� �������� ���͸����� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _groundMaterial = _renderer.material;
    }

    /// <summary>
    /// �׶����� Ⱦ ��ũ�Ѹ��� �����մϴ�.
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
