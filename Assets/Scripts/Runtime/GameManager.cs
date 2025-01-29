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
    /// None: �ʱ�ȭ�� ������� ���� �����Դϴ�.
    /// Ready: ������ �����ϱ� ���Դϴ�.
    /// Play: ������ �÷����ϴ� �����Դϴ�.
    /// GameOver: �� ������Ʈ�� �������� �浹�� �����Դϴ�.
    /// Done: ������ ����� �����Դϴ�.
    /// </remarks>
    public enum State
    {
        None,
        Ready,
        Play,
        GameOver,
        Done,
    }

    /// <summary>
    /// ������ ���� ���¿� ���� ������Ƽ�Դϴ�.
    /// </summary>
    /// <remarks>
    /// ���� ���� ���� �����ϸ� ���� ���׿� �°� ��ü ���� ���µ� ���� ����˴ϴ�.
    /// </remarks>
    public State CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case State.Ready:
                    ActiveReadyState();
                    break;

                case State.Play:
                    ActivatePlayState();
                    break;

                case State.GameOver:
                    ActiveGameOverState();
                    break;
            }
        }
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
    private State _currentGameState = State.None;
    
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

        this.CurrentGameState = State.Ready;
    }

    /// <summary>
    /// ���� ��� ���¸� Ȱ��ȭ�մϴ�.
    /// </summary>
    private void ActiveReadyState()
    {
        // �̹� ��� ���� ���¶�� �ƹ� ���۵� �������� �ʽ��ϴ�.
        if (_currentGameState == State.Ready)
        {
            return;
        }

        _scoreUI.SetActive(false);

        _currentGameState = State.Ready;
    }

    /// <summary>
    /// ���� �÷��� ���¸� Ȱ��ȭ�մϴ�.
    /// </summary>
    private void ActivatePlayState()
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
    private void ActiveGameOverState()
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
