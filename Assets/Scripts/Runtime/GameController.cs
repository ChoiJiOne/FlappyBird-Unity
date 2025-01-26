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
    /// �÷��� �� ���� �� ������Ʈ ��Ʈ�ѷ��Դϴ�.
    /// </summary>
    private BirdController _birdController;

    /// <summary>
    /// �÷��� �� ���� �ٴ� �������� �����մϴ�.
    /// </summary>
    private GroundScroller _groundScroller;

    /// <summary>
    /// �÷��� �� ���� GetReady UI ������Ʈ�Դϴ�.
    /// </summary>
    private GameObject _getReadyUI;

    /// <summary>
    /// �÷��� �� ���� Instructions UI ������Ʈ�Դϴ�.
    /// </summary>
    private GameObject _instructionsUI;

    /// <summary>
    /// �÷��� �� ���� PauseButton UI ������Ʈ�Դϴ�.
    /// </summary>
    private GameObject _pauseButtonUI;

    /// <summary>
    /// �÷��� �� ���� ResumeButton UI ������Ʈ�Դϴ�.
    /// </summary>
    private GameObject _resumeButtonUI;

    /// <summary>
    /// �����ؾ� �� ��� ������Ʈ�� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _birdController = GameObject.Find("Bird").GetComponent<BirdController>();
        _groundScroller = GameObject.Find("Ground").GetComponent<GroundScroller>();
        _getReadyUI = GameObject.Find("GetReady");
        _instructionsUI = GameObject.Find("Instructions");
        _pauseButtonUI = GameObject.Find("PauseButton");
        _resumeButtonUI = GameObject.Find("ResumeButton");

        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(false);
    }

    /// <summary>
    /// ���� ���� �ñ׳ο� �´� ������ �����մϴ�.
    /// </summary>
    public void OnProcessStartGameSignal()
    {
        _getReadyUI.SetActive(false);
        _instructionsUI.SetActive(false);
        _pauseButtonUI.SetActive(true);
    }

    /// <summary>
    /// ���� ���� �ñ׳ο� �´� ������ �����մϴ�.
    /// </summary>
    public void OnProcessPauseGameSignal()
    {
        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(true);

        _groundScroller.Movable = false;
        _birdController.Movable = false;
    }
}
