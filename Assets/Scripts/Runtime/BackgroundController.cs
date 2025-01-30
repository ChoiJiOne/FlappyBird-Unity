using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��׶��带 �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class BackgroundController : MonoBehaviour
{
    /// <summary>
    /// ���� �� ���� ��׶��� ������Ʈ�Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ���� �����Ϳ��� �����մϴ�.
    /// </remarks>
    [SerializeField]
    private GameObject _background;

    /// <summary>
    /// ��׶����� ��������Ʈ�� �����մϴ�.
    /// </summary>
    private BackgroundSpriteController _backgroundSpriteController;

    /// <summary>
    /// ��׶����� ��������Ʈ ���� ������Ʈ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _backgroundSpriteController = _background.GetComponent<BackgroundSpriteController>();
    }

    /// <summary>
    /// DAY ��ư�� Ŭ������ ���� �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// ����, ��׶��尡 DAY�� �����Ǿ� �ִٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
    /// </remarks>
    public void OnClickSwitchDayButton()
    {
        if (BackgroundSpriteController.Day)
        {
            return;
        }

        SwitchBackgroundSprite();
    }

    /// <summary>
    /// NIGHT ��ư�� Ŭ������ ���� �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// ����, ��׶��尡 NIGHT�� �����Ǿ� �ִٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
    /// </remarks>
    public void OnClickSwitchNightButton()
    {
        if (!BackgroundSpriteController.Day)
        {
            return;
        }

        SwitchBackgroundSprite();
    }

    /// <summary>
    /// ��׶����� ��������Ʈ�� �ݴ�� ��ȯ�մϴ�.
    /// </summary>
    /// <remarks>
    /// ��(DAY)�̶�� ��(NIGHT)���� �����ϰ�, ���̸� ������ �����մϴ�.
    /// </remarks>
    private void SwitchBackgroundSprite()
    {
        BackgroundSpriteController.Day = !BackgroundSpriteController.Day;
        _backgroundSpriteController.ApplySprite();
    }
}
