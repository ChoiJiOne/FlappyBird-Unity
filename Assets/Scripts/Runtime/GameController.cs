using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ����(����, ����, ����)�մϴ�.
/// </summary>
/// <remarks>
/// �� ��ũ��Ʈ�� �÷��� �� ���� GameController ������Ʈ�� �Բ� �����մϴ�.
/// </remarks>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// ���� ���� ��ȣ �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// Start : ���� ���� ��ȣ�Դϴ�.
    /// Pause : ���� ���� ��ȣ�Դϴ�.
    /// Resume : ���� �簳 ��ȣ�Դϴ�.
    /// GameOver : ���� ���� ��ȣ�Դϴ�.
    /// </remarks>
    public enum Signal
    {
        Start,
        Pause,
        Resume,
        GameOver,
    }

    /// <summary>
    /// �÷��� �� ���� �� ������Ʈ ��Ʈ�ѷ��Դϴ�.
    /// </summary>
    private BirdController _birdController;

    /// <summary>
    /// �÷��� �� ���� GetReady UI ������Ʈ�Դϴ�.
    /// </summary>
    private GameObject _getReadyUI;

    /// <summary>
    /// �÷��� �� ���� Instructions UI ������Ʈ�Դϴ�.
    /// </summary>
    private GameObject _instructionsUI;

    /// <summary>
    /// �����ؾ� �� ��� ������Ʈ�� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _birdController = GameObject.Find("Bird").GetComponent<BirdController>();
        _getReadyUI = GameObject.Find("GetReady");
        _instructionsUI = GameObject.Find("Instructions");
    }

    /// <summary>
    /// ���� ��Ʈ�ѷ��� ���� �ñ׳��� �����մϴ�.
    /// </summary>
    /// <param name="signal">������ �ñ׳��� �����Դϴ�.</param>
    public void SendGameSignal(Signal signal)
    {
        switch (signal)
        {
            case Signal.Start:
                OnProcessStartGameSignal();
                break;

            case Signal.Pause:
                break;

            case Signal.Resume:
                break;

            case Signal.GameOver:
                break;
        }
    }

    /// <summary>
    /// ���� ���� �ñ׳ο� �´� ������ �����մϴ�.
    /// </summary>
    private void OnProcessStartGameSignal()
    {
        _getReadyUI.SetActive(false);
        _instructionsUI.SetActive(false);
    }
}
