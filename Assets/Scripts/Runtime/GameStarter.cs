using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ������ �����մϴ�.
/// </summary>
public class GameStarter : MonoBehaviour
{
    /// <summary>
    /// �÷��̾ ������ �÷����ϴ� ���� �̸��Դϴ�.
    /// </summary>
    private string _playSceneName;

    /// <summary>
    /// �÷��̾ ������ �÷����ϴ� ���� �̸��� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _playSceneName = "PlayScene";
    }

    /// <summary>
    /// ���� ���� ��ư�� Ŭ������ �� ������ �����Դϴ�.
    /// </summary>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(_playSceneName);
    }
}
