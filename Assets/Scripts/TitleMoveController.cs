using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� Ÿ��Ʋ�� �����Դϴ�.
/// </summary>
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
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// �� ������ �� �� ȣ���մϴ�.
    /// </summary>
    void Update()
    {
        
    }
}
