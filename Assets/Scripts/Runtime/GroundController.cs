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
    /// �׶��� ������Ʈ�� Ⱦ ��ũ�� �ӷ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _scrollSpeed;

    /// <summary>
    /// ���̴��� ������ �׶��� �ؽ�ó�� ������ ���Դϴ�.
    /// </summary>
    private Vector2 _textureOffset = Vector2.zero;

    /// <summary>
    /// �׶��� ������Ʈ�� �����Դϴ�.
    /// </summary>
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
