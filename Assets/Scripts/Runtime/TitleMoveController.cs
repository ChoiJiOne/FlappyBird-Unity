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
    /// Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �Ÿ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _moveLength;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �� ���� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �����̴� �ð��� �� �������� ����ؼ� ���� ��ġ�� ���ƿ��� �ð��Դϴ�.
    /// </remarks>
    [SerializeField]
    private float _moveTime;

    /// <summary>
    /// Ÿ��Ʋ UI�� �� Ʈ������ ���� ���� �����ϰ� ������ �� ���� ��ġ�� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
