using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �� ��ȯ ���� �� ��ȯ�� �����մϴ�.
/// </summary>
/// <remarks>
/// �� SceneSwitchTrigger�� UI ��ư�� �Բ� �����մϴ�.
/// </remarks>
public class SceneSwitchTrigger : MonoBehaviour
{
    /// <summary>
    /// ��ȯ ����� �Ǵ� ���� �̸��Դϴ�.
    /// </summary>
    [SerializeField]
    private string _targetSwitchSceneName;

    /// <summary>
    /// �� ��ȯ�� �����ؾ� �ϴ� ��ư�� Ŭ������ �� �����մϴ�.
    /// </summary>
    public void OnClickSceneSwitchButton()
    {
        SceneManager.LoadScene(_targetSwitchSceneName);
    }
}