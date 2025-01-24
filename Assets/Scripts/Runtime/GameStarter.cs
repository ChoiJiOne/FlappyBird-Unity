using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임을 시작합니다.
/// </summary>
public class GameStarter : MonoBehaviour
{
    /// <summary>
    /// 플레이어가 게임을 플레이하는 씬의 이름입니다.
    /// </summary>
    private string _playSceneName;

    /// <summary>
    /// 플레이어가 게임을 플레이하는 씬의 이름을 설정합니다.
    /// </summary>
    private void Awake()
    {
        _playSceneName = "PlayScene";
    }

    /// <summary>
    /// 게임 시작 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(_playSceneName);
    }
}
