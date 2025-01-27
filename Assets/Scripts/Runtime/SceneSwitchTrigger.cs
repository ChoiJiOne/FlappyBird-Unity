using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 씬 전환 감지 및 전환을 수행합니다.
/// </summary>
/// <remarks>
/// 이 SceneSwitchTrigger는 UI 버튼과 함께 동작합니다.
/// </remarks>
public class SceneSwitchTrigger : MonoBehaviour
{
    /// <summary>
    /// 전환 대상이 되는 씬의 이름입니다.
    /// </summary>
    [SerializeField]
    private string _targetSwitchSceneName;

    /// <summary>
    /// 씬 전환을 수행해야 하는 버튼을 클릭했을 때 실행합니다.
    /// </summary>
    public void OnClickSceneSwitchButton()
    {
        SceneManager.LoadScene(_targetSwitchSceneName);
    }
}