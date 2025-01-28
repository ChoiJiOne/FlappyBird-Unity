using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷��� �� ���� �׶��带 �����մϴ�.
/// </summary>
/// <remarks>
/// �ַ� Ⱦ ��ũ�� �ӵ� �� �浹 ó���� �����մϴ�.
/// </remarks>
public class GroundController : MonoBehaviour
{
    /// <summary>
    /// �������� �̵� �ӷ��� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// �׶����� ������ ���θ� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// �׶��� ������Ʈ�� �̵�(��ũ�Ѹ�) �ӷ��Դϴ�.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// �׶��� ������Ʈ�� ��ũ�� �̵� �Ÿ��Դϴ�.
    /// </summary>
    private float _scrollLength;

    /// <summary>
    /// ���̴��� ������ �׶��� �ؽ�ó�� ������ ���Դϴ�.
    /// </summary>
    private Vector2 _textureOffset = Vector2.zero;

    /// <summary>
    /// �׶��� ������Ʈ�� �����Դϴ�.
    /// </summary>
    private Material _material;

    /// <summary>
    /// ������ �ؽ�ó ������ ���� ������ �� ����� �������Դϴ�.
    /// </summary>
    private Renderer _renderer;
    
    /// <summary>
    /// �׶��� ������Ʈ�� ������ �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <remarks>
    /// �׶��� ������Ʈ�� ������ �� �ִٸ� true, �׷��� ������ false�Դϴ�.
    /// </remarks>
    private bool _canMove = true;

    /// <summary>
    /// ��ũ�Ѹ��� �ʿ��� �������� ���� �� ��ũ�� �̵� �Ÿ� ���� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _scrollLength = _renderer.bounds.size.x;
    }

    /// <summary>
    /// �׶����� Ⱦ ��ũ���� �����մϴ�.
    /// </summary>
    /// <remarks>
    /// ������ ���ΰ� ��Ȱ��ȭ �Ǿ� �ִٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
    /// </remarks>
    private void Update()
    {
        // �������� ��Ȱ��ȭ �Ǹ� �ƹ� ���۵� �������� ����.
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
