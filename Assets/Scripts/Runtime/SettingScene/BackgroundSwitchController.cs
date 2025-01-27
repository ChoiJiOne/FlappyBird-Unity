using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ��׶��� ��ȯ�� �����մϴ�.
/// </summary>
/// <remarks>
/// �� ��׶��� ����ġ ��Ʈ�ѷ��� ���� �� ���ο����� ���˴ϴ�.
/// </remarks>
public class BgSwitchController : MonoBehaviour
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
    private BackgroundSwitchController _bgSpriteController;

    /// <summary>
    /// ��׶����� ��������Ʈ ���� ������Ʈ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        GameObject background = GameObject.Find("Background");
        _bgSpriteController = background.GetComponent<BackgroundSwitchController>();
    }

    /// <summary>
    /// DAY ��ư�� Ŭ������ ���� �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// ����, ��׶��尡 DAY�� �����Ǿ� �ִٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
    /// </remarks>
    public void OnClickSwitchDayButton()
    {
        if (BackgroundSwitchController.Day)
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
        if (!BackgroundSwitchController.Day)
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
        BackgroundSwitchController.Day = !BackgroundSwitchController.Day;
        _bgSpriteController.ApplySprite();
    }
}
