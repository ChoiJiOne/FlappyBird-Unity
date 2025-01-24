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
    /// Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �Ÿ��Դϴ�.
    /// </summary>
    private float _moveLength;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �� ���� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �����̴� �ð��� �� �������� ����ؼ� ���� ��ġ�� ���ƿ��� �ð��Դϴ�.
    /// </remarks>
    private float _moveTime;
    
    /// <summary>
    /// �� Ʈ�������� Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ ���� �����մϴ�.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
