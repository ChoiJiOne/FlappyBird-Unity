using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 시작 씬의 씬 전환을 수행합니다.
/// </summary>
public class SceneSwitchTrigger : MonoBehaviour
{
    /// <summary>
    /// 게임 설정을 수행하는 씬의 이름입니다.
    /// </summary>
    private string _settingSceneName;

    /// <summary>
    /// 게임 시작 전 선택을 수행하는 씬의 이름입니다.
    /// </summary>
    private string _selectSceneName;

    /// <summary>
    /// 전환할 씬의 이름 값을 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _settingSceneName = "SettingScene";
        _selectSceneName = "SelectScene";
    }

    /// <summary>
    /// 세팅 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickSettingButton()
    {
        SceneManager.LoadScene(_settingSceneName);
    }

    /// <summary>
    /// 플레이 버튼을 클릭했을 때 수행할 동작합니다.
    /// </summary>
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(_selectSceneName);
    }
}
