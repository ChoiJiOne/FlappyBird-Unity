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
}
