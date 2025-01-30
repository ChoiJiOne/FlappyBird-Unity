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
    /// ���� ������Ʈ�� ��� ���� ���� ������Ʈ���� ��������� ��Ȱ��ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        for(int index = 0; index < _levelObjects.Length; ++index)
        {
            if (index == _currentSelectIndex)
            {
                continue;
            }

            _levelObjects[index].SetActive(false);
        }
    }

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
