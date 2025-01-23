using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���� ��ȯ�Ͽ� ������ �����մϴ�.
/// </summary>
/// <remarks>
/// �� ������Ʈ�� ���� ���� StartButton�� �Բ� �����մϴ�.
/// </remarks>
public class GameStarter : MonoBehaviour
{
    /// <summary>
    /// START ��ư�� Ŭ������ �� �����մϴ�.
    /// </summary>
    public void OnClickStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
