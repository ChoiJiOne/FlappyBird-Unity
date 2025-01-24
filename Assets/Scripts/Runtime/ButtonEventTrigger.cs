using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���� ���� ��ư �̺�Ʈ�� �����մϴ�.
/// </summary>
public class ButtonEventTrigger : MonoBehaviour
{
    /// <summary>
    /// ���� �� ���� EXIT ��ư�� Ŭ������ �� ��ȯ�� ���� �̸��Դϴ�.
    /// </summary>
    private string _exitSceneName;

    /// <summary>
    /// EXIT ��ư�� Ŭ������ �� ��ȯ�� ���� �̸��� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _exitSceneName = "StartScene";
    }

    /// <summary>
    /// EXIT ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// EXIT ��ư�� Ŭ���ϸ� ���� ������ ���ư��ϴ�.
    /// </remarks>
    public void OnClickExitButton()
    {
        SceneManager.LoadScene(_exitSceneName);
    }
}
