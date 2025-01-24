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
    /// ��ȯ�� ���� �̸� ���� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _settingSceneName = "SettingScene";
    }

    /// <summary>
    /// ���� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickSetting()
    {
        SceneManager.LoadScene(_settingSceneName);
    }
}
