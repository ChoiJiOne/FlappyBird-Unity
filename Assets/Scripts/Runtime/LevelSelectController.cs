using System;
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
    /// �÷��̾��� ���� Ű ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// EASY: 0
    /// NORMAL: 1
    /// HARD: 2
    /// </remarks>
    private static string s_playerLevelKey = "Level";

    /// <summary>
    /// ���� ������Ʈ�� ��� ���� ���� ������Ʈ���� ��������� ��Ȱ��ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        if (PlayerPrefs.HasKey(s_playerLevelKey))
        {
            _currentSelectIndex = PlayerPrefs.GetInt(s_playerLevelKey);
        }

        for(int index = 0; index < _levelObjects.Length; ++index)
        {
            if (index == _currentSelectIndex)
            {
                continue;
            }

            SetActiveLevelObject(index, false);
        }
    }

    /// <summary>
    /// ������Ʈ�� �ı��Ǳ� �� �÷��̾� ���� ���� ������ �����մϴ�.
    /// </summary>
    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }

    /// <summary>
    /// LeftSelectButton ��ư�� Ŭ������ �� ������ �̺�Ʈ�Դϴ�.
    /// </summary>
    public void OnClickLeftSelectButton()
    {
        SetActiveLevelObject(_currentSelectIndex, false);

        if (_currentSelectIndex == 0)
        {
            _currentSelectIndex = _levelObjects.Length;
        }
        _currentSelectIndex--;
        PlayerPrefs.SetInt(s_playerLevelKey, _currentSelectIndex);

        SetActiveLevelObject(_currentSelectIndex, true);
    }

    /// <summary>
    /// RightSelectButton ��ư�� Ŭ������ �� ������ �̺�Ʈ�Դϴ�.
    /// </summary>
    public void OnClickRightSelecttButton()
    {
        SetActiveLevelObject(_currentSelectIndex, false);

        _currentSelectIndex = (_currentSelectIndex + 1) % _levelObjects.Length;
        PlayerPrefs.SetInt(s_playerLevelKey, _currentSelectIndex);

        SetActiveLevelObject(_currentSelectIndex, true);
    }

    /// <summary>
    /// ���� ������Ʈ�� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="levelObjectIndex">Ȱ��ȭ ���θ� ������ ���� ������Ʈ�� �ε����Դϴ�.</param>
    /// <param name="isActive">Ȱ��ȭ �����Դϴ�.</param>
    private void SetActiveLevelObject(int levelObjectIndex, bool isActive)
    {
        // �ε����� �迭�� ������ ����ٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
        if (levelObjectIndex < 0 || levelObjectIndex >= _levelObjects.Length)
        {
            return;
        }

        _levelObjects[levelObjectIndex].SetActive(isActive);
    }
}
