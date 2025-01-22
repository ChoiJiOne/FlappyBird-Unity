using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Background : MonoBehaviour
{
    /// <summary>
    /// �������� Ʈ�������Դϴ�. ��׶����� ������ ���� �����ϱ� ���� ��� �����Դϴ�.
    /// </summary>
    private Transform _transform;

    /// <summary>
    /// ��׶��尡 �������� ��������Ʈ�� ������ ��������Ʈ �������Դϴ�.
    /// </summary>
    private SpriteRenderer _spriteRenderer;
    
    /// <summary>
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
    /// </summary>
    void Start()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// �� ������ �� �� ȣ���մϴ�.
    /// </summary>
    void Update()
    {
        
    }
}
