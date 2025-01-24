using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �� Ÿ��Ʋ�� �������� �����մϴ�.
/// </summary>
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// Ÿ��Ʋ UI�� �� Ʈ�������Դϴ�.
    /// </summary>
    /// <remakrs>
    /// Ÿ��Ʋ �� Ʈ�������� ��Ŀ(Anchors)�� Canvas �������� center/middle �Դϴ�.
    /// </remakrs>
    private RectTransform _rectTransform;

    /// <summary>
    /// �� Ʈ�������� �����մϴ�.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
