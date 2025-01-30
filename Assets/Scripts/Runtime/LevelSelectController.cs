using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����մϴ�.
/// </summary>
/// <remarks>
/// ���� ���� ��Ʈ�ѷ��� ���� ���� LeftSelectButton�� RightSelectButton�� �Բ� �����մϴ�.
/// </remarks>
public class LevelSelectController : MonoBehaviour
{
    /// <summary>
    /// ������ ���� ������Ʈ ����Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject[] _levelObjects;

    /// <summary>
    /// ���� ������ ������ �ε����Դϴ�.
    /// </summary>
    private int _currentSelectIndex = 0;

    /// <summary>
    /// LeftSelectButton ��ư�� Ŭ������ �� ������ �̺�Ʈ�Դϴ�.
    /// </summary>
    public void OnClickLeftSelectButton()
    {

    }

    /// <summary>
    /// RightSelectButton ��ư�� Ŭ������ �� ������ �̺�Ʈ�Դϴ�.
    /// </summary>
    public void OnClickRightSelecttButton()
    {

    }
}
