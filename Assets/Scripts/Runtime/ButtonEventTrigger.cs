using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 세팅 씬의 버튼 이벤트를 수행합니다.
/// </summary>
public class ButtonEventTrigger : MonoBehaviour
{
    /// <summary>
    /// 세팅 씬 내에 EXIT 버튼을 클릭했을 때 전환할 씬의 이름입니다.
    /// </summary>
    private string _exitSceneName;

    /// <summary>
    /// EXIT 버튼을 클릭했을 때 전환할 씬의 이름을 설정합니다.
    /// </summary>
    private void Awake()
    {
        _exitSceneName = "StartScene";
    }

    /// <summary>
    /// EXIT 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    /// <remarks>
    /// EXIT 버튼을 클릭하면 시작 씬으로 돌아갑니다.
    /// </remarks>
    public void OnClickExitButton()
    {
        SceneManager.LoadScene(_exitSceneName);
    }
}
