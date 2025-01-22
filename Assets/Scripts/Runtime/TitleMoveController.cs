using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� Ÿ��Ʋ�� �����Դϴ�.
/// </summary>
[ExecuteInEditMode]
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// Ÿ��Ʋ�� �� Ʈ�������Դϴ�.
    /// </summary>
    /// <remarks>
    /// Ÿ��Ʋ �� Ʈ�������� ��Ŀ(Anchors)�� Canvas �������� center/middle �Դϴ�.
    /// </remarks>
    private RectTransform _rectTransform;

    /// <summary>
    /// Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// Ÿ��Ʋ�� ������ ���� �����Դϴ�.
    /// </summary>
    public float _moveHeight;

    /// <summary>
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// �� ������ �� �� ȣ���մϴ�.
    /// </summary>
    void Update()
    {
        
    }
}
