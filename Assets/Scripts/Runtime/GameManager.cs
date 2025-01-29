using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷��� �� ���� ���� �� �� �̺�Ʈ�� �����մϴ�.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ������ ���¸� �����ϴ� �������Դϴ�.
    /// </summary>
    /// <remarks>
    /// Ready: ������ �����ϱ� ���Դϴ�.
    /// Play: ������ �÷����ϴ� �����Դϴ�.
    /// GameOver: ������ ����� �����Դϴ�.
    /// </remarks>
    public enum State
    {
        Ready,
        Play,
        GameOver,
    }

    /// <summary>
    /// ���� ���� �̵� �ӷ� ���Դϴ�
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    /// <summary>
    /// ���� ���� �׶��� ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _ground;

    /// <summary>
    /// �׶����� �������� �����մϴ�.
    /// </summary>
    private GroundController _groundController;

    /// <summary>
    /// ���� ���� ������ ������Ʈ�� �����ϴ� �Ŵ��� ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _pipeManager;

    /// <summary>
    /// ���� ���� ������ ������Ʈ�� �����ϴ� �Ŵ��� �Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ��� ������ ������ �������� �����մϴ�.
    /// </remarks>
    private PipeManager _pipeMgr;

    /// <summary>
    /// ���� ���� �÷��̾ �����ϴ� �� ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _bird;

    /// <summary>
    /// ���� ���� ���� �����մϴ�.
    /// </summary>
    private BirdController _birdController;

    /// <summary>
    /// �� ���� ĵ���� ���� GetReady UI ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _getReadyUI;

    /// <summary>
    /// �� ���� ĵ���� ���� Instructions UI ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _InstructionsUI;

    /// <summary>
    /// �� ���� ĵ���� ���� ���ھ ǥ���ϴ� �ؽ�Ʈ UI ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _scoreUI;

    /// <summary>
    /// ���� ���� �����Դϴ�.
    /// </summary>
    private State _currentGameState = State.Ready;
    
    /// <summary>
    /// ���� �Ŵ����� �����ؾ� �� ������Ʈ�� �����ϱ� ���� ������Ʈ ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _groundController = _ground.GetComponent<GroundController>();
        _groundController.MoveSpeed = _moveSpeed;

        _pipeMgr = _pipeManager.GetComponent<PipeManager>();
        _pipeMgr.MoveSpeed = _moveSpeed;

        _birdController = _bird.GetComponent<BirdController>();

        _scoreUI.SetActive(false);
    }

    /// <summary>
    /// ���� �÷��� ���¸� Ȱ��ȭ�մϴ�.
    /// </summary>
    public void ActivatePlayState()
    {
        // �̹� �÷��� ���� ���̰ų� ���� ���� ���¶�� �ƹ� ���۵� �������� �ʽ��ϴ�.
        if (_currentGameState == State.Play || _currentGameState == State.GameOver)
        {
            return;
        }

        _getReadyUI.SetActive(false);
        _InstructionsUI.SetActive(false);

        _scoreUI.SetActive(true);
        _pipeMgr.Active = true;

        _currentGameState = State.Play;
    }

    /// <summary>
    /// ���� ���� ���¸� Ȱ��ȭ�մϴ�.
    /// </summary>
    public void ActiveGameOverState()
    {
        // �̹� ���� ���� ���¶�� �ƹ� ���۵� �������� �ʽ��ϴ�.
        if (_currentGameState == State.GameOver)
        {
            return;
        }

        _pipeMgr.Active = false;
        _groundController.Movable = false;

        _currentGameState = State.GameOver;
    }
}
