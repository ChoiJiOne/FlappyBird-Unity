using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��׶��带 �����ϴ� ������Ʈ�Դϴ�.
/// </summary>
/// <remarks>
/// �� ������Ʈ�� ���� ���� 'DAY'�� 'NIGHT' ��ư�� �Բ� �����մϴ�.
/// </remarks>
public class BackgroundContoller : MonoBehaviour
{
    /// <summary>
    /// ��׶��� ������Ʈ�Դϴ�.
    /// </summary>
    private Background _background;

    /// <summary>
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
    /// </summary>
    void Start()
    {
        GameObject background = GameObject.Find("Background");
        _background = background.GetComponent<Background>();
    }

    /// <summary>
    /// ���� ���� 'DAY' ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickDay()
    {
        if (Background.Day)
        {
            return;
        }

        Background.Day = true;
        _background.ApplySprite();
    }

    /// <summary>
    /// ���� ���� 'NIGHT' ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickNight()
    {
        if (!Background.Day)
        {
            return;
        }

        Background.Day = false;
        _background.ApplySprite();
    }
}
