using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��ư�� �Բ� �� ��ȯ�� �����ϴ� �Ŵ����Դϴ�.
/// </summary>
public class SceneSwitchManager : MonoBehaviour
{
    /// <summary>
    /// ���� ������ �÷��� ��ư�� Ŭ������ �� ��ȯ�� ���� �̸��Դϴ�.
    /// </summary>
    private string _selectSceneName;

    /// <summary>
    /// ���� ������ ���� ��ư�� Ŭ������ �� ��ȯ�� ���� �̸��Դϴ�.
    /// </summary>
    private string _settingSceneName;

    /// <summary>
    /// ���� ������ ��� ��ư�� Ŭ������ �� ��ȯ�� ���� �̸��Դϴ�.
    /// </summary>
    private string _startSceneName;

    /// <summary>
    /// ��ȯ�� �� �̸��� �����մϴ�.
    /// </summary>
    void Start()
    {
        _selectSceneName = "SelectScene";
        _settingSceneName = "SettingScene";
        _startSceneName = "StartScene";
    }

    /// <summary>
    /// �÷��� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickPlay()
    {
        SceneManager.LoadScene(_selectSceneName);
    }

    /// <summary>
    /// ���ھ� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickScore()
    {
    }

    /// <summary>
    /// ���� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickSetting()
    {
        SceneManager.LoadScene(_settingSceneName);
    }

    /// <summary>
    /// ��� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickCancel()
    {
        SceneManager.LoadScene(_startSceneName);
    }
}
