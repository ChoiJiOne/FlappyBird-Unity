using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �� ���� Ÿ��Ʋ UI �̵��� �����մϴ�.
/// </summary>
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// Ÿ��Ʋ UI�� �� Ʈ�������Դϴ�.
    /// </summary>
    /// <remarks>
    /// Ÿ��Ʋ �� Ʈ�������� ��Ŀ(Anchors)�� Canvas �������� center/middle �Դϴ�.
    /// </remarks>
    private RectTransform _rectTransform;

    /// <summary>
    /// Ÿ��Ʋ UI�� �� Ʈ������ ���� ���� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
