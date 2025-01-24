using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���� ���� �� ��ȯ�� �����մϴ�.
/// </summary>
public class SceneSwitchTrigger : MonoBehaviour
{
    /// <summary>
    /// ���� ������ �����ϴ� ���� �̸��Դϴ�.
    /// </summary>
    private string _settingSceneName;

    /// <summary>
    /// ���� ���� �� ������ �����ϴ� ���� �̸��Դϴ�.
    /// </summary>
    private string _selectSceneName;

    /// <summary>
    /// ��ȯ�� ���� �̸� ���� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _settingSceneName = "SettingScene";
        _selectSceneName = "SelectScene";
    }

    /// <summary>
    /// ���� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickSettingButton()
    {
        SceneManager.LoadScene(_settingSceneName);
    }

    /// <summary>
    /// �÷��� ��ư�� Ŭ������ �� ������ �����մϴ�.
    /// </summary>
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(_selectSceneName);
    }
}
