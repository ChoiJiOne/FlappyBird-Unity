using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// ���� �÷��� �� ���� ���� �����մϴ�.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// ���� �߷� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    public bool Gravity
    {
        get { return _rigidbody.simulated; }
        set { _rigidbody.simulated = value; }
    }

    /// <summary>
    /// ���� �ִϸ��̼� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    public bool Animation
    {
        get { return _animator.enabled; }
        set { _animator.enabled = value; }
    }

    /// <summary>
    /// ���� ������ ���θ� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    /// <summary>
    /// �÷��̾ ȹ���� ������ ���� ������Ƽ�Դϴ�.
    /// </summary>
    public int Score
    {
        get { return _score; }
    }

    /// <summary>
    /// �÷��̾ �����ϴ� ���� �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// Idle: ���� ���� �� ��� �����Դϴ�.
    /// Jump: Ŭ���Ͽ� ���� ���� ���� �����Դϴ�.
    /// Fall: ������ ������ �������� �����Դϴ�.
    /// Crash: ���� �������� �浹�� �����Դϴ�.
    /// Dead: ������Ʈ�� �浹�� �����Դϴ�.
    /// </remarks>
    public enum State
    {
        Idle,
        Jump,
        Fall,
        Crash,
        Dead,
    }

    /// <summary>
    /// �� ������Ʈ ������ ����ϴ� ����� Ÿ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� �������� BirdController �������� ���˴ϴ�.
    /// </remarks>
    private enum AudioType
    {
        Swooshing = 0,
        Wing      = 1,
        Point     = 2,
        Hit       = 3,
        Die       = 4,
    }

    /// <summary>
    /// ���� �ִϸ��̼��� �����մϴ�.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// ���� ������ �� �浹 ó���� ���� ��ü(RigidBody)�Դϴ�.
    /// </summary>
    private Rigidbody2D _rigidbody;

    /// <summary>
    /// ���� ���� �����Դϴ�.
    /// </summary>
    private State _currentState = State.Idle;

    /// <summary>
    /// ���� ������ �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    private bool _canMove = false;

    /// <summary>
    /// ���� �ӷ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _jumpSpeed;

    /// <summary>
    /// ȸ�� �ӷ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _rotateSpeed;

    /// <summary>
    /// ���� �÷��� ���� ���� �Ŵ��� ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _gameManager;

    /// <summary>
    /// ���� �÷��� ���� ���� �Ŵ����Դϴ�.
    /// </summary>
    private GameManager _gameMgr;

    /// <summary>
    /// �� ���� ���� ���ھ� �ؽ�Ʈ UI�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _scoreUI;

    /// <summary>
    /// �÷��̾��� ���ھ��Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ���ھ�� �������� ����� Ƚ���� �����մϴ�.
    /// </remarks>
    private int _score = 0;

    /// <summary>
    /// �Է� ó�� �� GetMouseButtonDown�� ������ ���콺�� ���� ��ư �ڵ��Դϴ�.
    /// </summary>
    private const int LEFT_MOUSE_BUTTON_CODE = 0;

    /// <summary>
    /// ���� �ִ� ȸ�����Դϴ�.
    /// </summary>
    /// <remarks>
    /// �̶� ȸ������ ���ʺй� (ex, 30��, 60��) �����Դϴ�.
    /// </remarks>
    private const float MAX_ROTATE_ANGLE = 30.0f;

    /// <summary>
    /// ���� Y��ǥ �ִ� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ����� ���� �ܺη� ���� �� ������ �����ϱ� ���� ���Դϴ�.
    /// </remarks>
    private const float MAX_Y_POSITION = 5.0f;

    /// <summary>
    /// �� ������Ʈ ������ ����ϴ� ����� �ҽ� ����Դϴ�.
    /// </summary>
    private AudioSource[] _audioSources;

    /// <summary>
    /// �ִϸ��̼ǰ� ������ٵ��� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSources = GetComponents<AudioSource>();
        
        // ���ʿ� �������� ���� ���� ���°� �ٸ���, ������ �����ϸ� ���°� ����.
        this.Gravity = false;
        this.Animation = true;
    }

    /// <summary>
    /// ���� �Ŵ����� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Start()
    {
        _gameMgr = _gameManager.GetComponent<GameManager>();

        PlayAudioSource(AudioType.Swooshing);
    }

    private void Update()
    {
        switch(_currentState)
        {
            case State.Idle:
                if (CanJumpBird())
                {
                    StartJumpBird();
                    _canMove = true;
                    _gameMgr.CurrentGameState = GameManager.State.Play;
                }
                break;

            case State.Jump when _canMove:
                if (IsFallBird())
                {
                    _currentState = State.Fall;
                    this.Animation = false;
                }

                AdjustToBounds();
                break;

            case State.Fall when _canMove:
                if (CanJumpBird())
                {
                    StartJumpBird();
                }
                else
                {
                    RotateBird();
                    AdjustToBounds();
                }
                break;

            case State.Crash when _canMove:
                if (IsFallBird())
                {
                    RotateBird();
                }
                break;

            case State.Dead:
                // �ƹ� ���۵� �������� �ʽ��ϴ�.
                break;
        }
    }

    /// <summary>
    /// ���� ������ �� �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <returns>
    /// ������ �� �� �ִٸ� true, �׷��� ������ false�� ��ȯ�մϴ�.
    /// </returns>
    private bool CanJumpBird()
    {
        return Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON_CODE) && (_currentState == State.Idle || _currentState == State.Fall);
    }

    /// <summary>
    /// ���� �������� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <returns>���� �������� �ִٸ� true, �׷��� ������ false�� ��ȯ�մϴ�.</returns>
    private bool IsFallBird()
    {
        return _rigidbody.velocity.y <= 0.0f;
    }

    /// <summary>
    /// ������ �����մϴ�.
    /// </summary>
    /// <remarks>
    /// �� �޼���� ���� ���°� Idle Ȥ�� Fall �϶��� �����մϴ�. 
    /// ���� ���ο��� ���� ���¸� �����մϴ�.
    /// </remarks>
    private void StartJumpBird()
    {
        if (_currentState == State.Jump || _currentState == State.Dead)
        {
            return;
        }

        Vector2 velocity = Vector2.zero;
        velocity.x = _rigidbody.velocity.x;
        velocity.y = _jumpSpeed;
        _rigidbody.velocity = velocity;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, MAX_ROTATE_ANGLE);

        this.Gravity = true;
        this.Animation = true;
        
        PlayAudioSource(AudioType.Wing);
        _currentState = State.Jump;
    }

    /// <summary>
    /// ���� ȸ����ŵ�ϴ�.
    /// </summary>
    /// <remarks>
    /// ȸ�� ���� ������ ���ʺй� �������� -90 ���� 30 �����̰�, ���� ���°� Fall�϶��� �����մϴ�.
    /// </remarks>
    private void RotateBird()
    {
        float rotateAngle = -Time.deltaTime * _rotateSpeed;
        transform.Rotate(0.0f, 0.0f, rotateAngle);

        // 2���� ��鿡�� �� 3��и��� �� ���� 
        const float ROTATE_START_THIRD_QUADRANT = 240.0f;
        const float ROTATE_END_THIRD_QUADRANT = 270.0f;

        float rotateEulerAngleZ = transform.rotation.eulerAngles.z;
        if (rotateEulerAngleZ < ROTATE_START_THIRD_QUADRANT || rotateEulerAngleZ > ROTATE_END_THIRD_QUADRANT)
        {
            return;
        }

        Vector3 rotateEulerAngle = Vector3.zero;
        rotateEulerAngle.z = ROTATE_END_THIRD_QUADRANT;

        transform.rotation = Quaternion.Euler(rotateEulerAngle);
    }

    /// <summary>
    /// ���� ī�޶� ������ ����� ���ϰ� ��ġ�� �����մϴ�.
    /// </summary>
    private void AdjustToBounds()
    {
        if (transform.position.y < MAX_Y_POSITION)
        {
            return;
        }

        Vector3 adjustTargetPosition = transform.position;
        adjustTargetPosition.y = MAX_Y_POSITION;
        transform.position = adjustTargetPosition;
    }

    /// <summary>
    /// ����� �ҽ��� ����մϴ�.
    /// </summary>
    /// <param name="type">��</param>
    private void PlayAudioSource(AudioType type)
    {
        uint audioIndex = (uint)(type);
        _audioSources[audioIndex].Play();
    }

    /// <summary>
    /// ����� �ҽ��� �񵿱������� ����մϴ�.
    /// </summary>
    /// <param name="type">����� ������� �����Դϴ�.</param>
    /// <param name="delay">����� ����� ���� �ð��Դϴ�.</param>
    /// <remarks>
    /// StartCoroutine�� �Բ� ����ؾ� �մϴ�.
    /// </remarks>
    private IEnumerator PlayAudioSourceDelay(AudioType type, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayAudioSource(type);
    }

    /// <summary>
    /// �׶��� ������Ʈ���� �浹 ó���� �����մϴ�.
    /// </summary>
    /// <param name="collision">�׶��� ������Ʈ�� �ݸ����Դϴ�.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �̹� Dead ���¶�� �ƹ� ���۵� �������� ����.
        if (_currentState == State.Dead)
        {
            return;
        }
        else if (_currentState == State.Fall)
        {
            // �� ���´� �������� �浹���� �ʰ�, �ٷ� �ٴڰ� �浹�� ��Ȳ�Դϴ�.
            this.Animation = false;

            PlayAudioSource(AudioType.Hit);
            PlayAudioSource(AudioType.Die);

            _gameMgr.CurrentGameState = GameManager.State.GameOver;
        }

        _gameMgr.CurrentGameState = GameManager.State.Done;
        _currentState = State.Dead;
    }

    /// <summary>
    /// ������ ������Ʈ���� �浹�� �����ϰ� ó���մϴ�.
    /// </summary>
    /// <param name="collision">������ ������Ʈ ������ �ݶ��̴��Դϴ�.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ���°� �̹� Crash �����̰ų� Dead �����̸� �ƹ� ���۵� �������� �ʽ��ϴ�.
        if (_currentState == State.Crash || _currentState == State.Dead)
        {
            return;
        }

        // ������ ������Ʈ�� Zone ������ �浹�ߴٸ�...
        if (collision.gameObject.name == "Zone")
        {
            _score++;

            TMPro.TextMeshProUGUI scoreUI = _scoreUI.GetComponent<TMPro.TextMeshProUGUI>();
            scoreUI.text = _score.ToString();

            PlayAudioSource(AudioType.Point);
            return;
        }
                
        PlayAudioSource(AudioType.Hit);
        StartCoroutine(PlayAudioSourceDelay(AudioType.Die, 0.5f));

        // ���� �� ���������� �ش� �޼��� ȣ��.
        StartJumpBird();

        this.Animation = false;

        _gameMgr.CurrentGameState = GameManager.State.GameOver;
        _currentState = State.Crash;
    }
}
