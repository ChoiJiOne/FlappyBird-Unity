using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ��׶��� ��ȯ�� �����մϴ�.
/// </summary>
public class BgSwitchController : MonoBehaviour
{
    /// <summary>
    /// ��׶����� ��������Ʈ�� �����մϴ�.
    /// </summary>
    private BgSpriteController _bgSpriteController;

    /// <summary>
    /// ��׶����� ��������Ʈ ���� ������Ʈ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        GameObject background = GameObject.Find("Background");
        _bgSpriteController = background.GetComponent<BgSpriteController>();
    }

    /// <summary>
    /// DAY ��ư�� Ŭ������ ���� �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// ����, ��׶��尡 DAY�� �����Ǿ� �ִٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
    /// </remarks>
    public void OnClickSwitchDayButton()
    {
        if (BgSpriteController.Day)
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
        if (!BgSpriteController.Day)
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
        BgSpriteController.Day = !BgSpriteController.Day;
        _bgSpriteController.ApplySprite();
    }
}
