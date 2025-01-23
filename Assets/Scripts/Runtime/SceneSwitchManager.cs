using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 시작 씬 내에서 버튼과 함께 씬 전환을 수행하는 매니저입니다.
/// </summary>
public class SceneSwitchManager : MonoBehaviour
{
    /// <summary>
    /// 플레이 버튼을 클릭했을 때 전환할 씬의 이름입니다.
    /// </summary>
    private string _selectSceneName;

    /// <summary>
    /// 세팅 버튼을 클릭했을 때 전환할 씬의 이름입니다.
    /// </summary>
    private string _settingSceneName;

    /// <summary>
    /// 전환될 씬 이름을 설정합니다.
    /// </summary>
    void Start()
    {
        _selectSceneName = "SelectScene";
        _settingSceneName = "SettingScene";
    }

    /// <summary>
    /// 플레이 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickPlay()
    {
        SceneManager.LoadScene(_selectSceneName);
    }

    /// <summary>
    /// 스코어 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickScore()
    {
    }

    /// <summary>
    /// 세팅 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickSetting()
    {
        SceneManager.LoadScene(_settingSceneName);
    }
}
