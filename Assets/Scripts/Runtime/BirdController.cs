using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 게임 플레이 씬 내의 새를 제어합니다.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// 새의 중력 활성화 여부를 설정합니다.
    /// </summary>
    public bool Gravity
    {
        get { return _rigidbody.simulated; }
        set { _rigidbody.simulated = value; }
    }

    /// <summary>
    /// 새의 애니메이션 활성화 여부를 설정합니다.
    /// </summary>
    public bool Animation
    {
        get { return _animator.enabled; }
        set { _animator.enabled = value; }
    }

    /// <summary>
    /// 새의 움직임 여부를 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    /// <summary>
    /// 플레이어가 획득한 점수에 대한 프로퍼티입니다.
    /// </summary>
    public int Score
    {
        get { return _score; }
    }

    /// <summary>
    /// 플레이어가 제어하는 새의 상태입니다.
    /// </summary>
    /// <remarks>
    /// Idle: 게임 시작 전 대기 상태입니다.
    /// Jump: 클릭하여 새가 점프 중인 상태입니다.
    /// Fall: 점프가 끝나고 떨어지는 상태입니다.
    /// Crash: 새가 파이프와 충돌한 상태입니다.
    /// Dead: 오브젝트와 충돌한 상태입니다.
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
    /// 새 오브젝트 내에서 사용하는 오디오 타입입니다.
    /// </summary>
    /// <remarks>
    /// 이 열거형은 BirdController 내에서만 사용됩니다.
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
    /// 새의 애니메이션을 제어합니다.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// 새의 움직임 및 충돌 처리를 위한 강체(RigidBody)입니다.
    /// </summary>
    private Rigidbody2D _rigidbody;

    /// <summary>
    /// 현재 새의 상태입니다.
    /// </summary>
    private State _currentState = State.Idle;

    /// <summary>
    /// 새가 움직일 수 있는지 확인합니다.
    /// </summary>
    private bool _canMove = false;

    /// <summary>
    /// 점프 속력입니다.
    /// </summary>
    [SerializeField]
    private float _jumpSpeed;

    /// <summary>
    /// 회전 속력입니다.
    /// </summary>
    [SerializeField]
    private float _rotateSpeed;

    /// <summary>
    /// 게임 플레이 씬의 게임 매니저 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _gameManager;

    /// <summary>
    /// 게임 플레이 씬의 게임 매니저입니다.
    /// </summary>
    private GameManager _gameMgr;

    /// <summary>
    /// 인 게임 내의 스코어 텍스트 UI입니다.
    /// </summary>
    [SerializeField]
    private GameObject _scoreUI;

    /// <summary>
    /// 플레이어의 스코어입니다.
    /// </summary>
    /// <remarks>
    /// 이 스코어는 파이프를 통과한 횟수와 동일합니다.
    /// </remarks>
    private int _score = 0;

    /// <summary>
    /// 입력 처리 시 GetMouseButtonDown에 전달할 마우스의 왼쪽 버튼 코드입니다.
    /// </summary>
    private const int LEFT_MOUSE_BUTTON_CODE = 0;

    /// <summary>
    /// 새의 최대 회전각입니다.
    /// </summary>
    /// <remarks>
    /// 이때 회전각은 육십분법 (ex, 30도, 60도) 기준입니다.
    /// </remarks>
    private const float MAX_ROTATE_ANGLE = 30.0f;

    /// <summary>
    /// 새의 Y좌표 최대 값입니다.
    /// </summary>
    /// <remarks>
    /// 이 상수는 새가 외부로 나갈 수 없도록 조정하기 위한 값입니다.
    /// </remarks>
    private const float MAX_Y_POSITION = 5.0f;

    /// <summary>
    /// 새 오브젝트 내에서 사용하는 오디오 소스 목록입니다.
    /// </summary>
    private AudioSource[] _audioSources;

    /// <summary>
    /// 애니메이션과 리지드바디의 참조를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSources = GetComponents<AudioSource>();
        
        // 최초에 시작했을 때만 서로 상태가 다르고, 게임을 시작하면 상태가 동일.
        this.Gravity = false;
        this.Animation = true;
    }

    /// <summary>
    /// 게임 매니저를 초기화합니다.
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
                // 아무 동작도 수행하지 않습니다.
                break;
        }
    }

    /// <summary>
    /// 새가 점프를 뛸 수 있는지 확인합니다.
    /// </summary>
    /// <returns>
    /// 점프를 뛸 수 있다면 true, 그렇지 않으면 false를 반환합니다.
    /// </returns>
    private bool CanJumpBird()
    {
        return Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON_CODE) && (_currentState == State.Idle || _currentState == State.Fall);
    }

    /// <summary>
    /// 새가 떨어지고 있는지 확인합니다.
    /// </summary>
    /// <returns>새가 떨어지고 있다면 true, 그렇지 않으면 false를 반환합니다.</returns>
    private bool IsFallBird()
    {
        return _rigidbody.velocity.y <= 0.0f;
    }

    /// <summary>
    /// 점프를 시작합니다.
    /// </summary>
    /// <remarks>
    /// 이 메서드는 현재 상태가 Idle 혹은 Fall 일때만 동작합니다. 
    /// 또한 내부에서 현재 상태를 변경합니다.
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
    /// 새를 회전시킵니다.
    /// </summary>
    /// <remarks>
    /// 회전 각의 범위는 육십분법 기준으로 -90 에서 30 사이이고, 현재 상태가 Fall일때만 동작합니다.
    /// </remarks>
    private void RotateBird()
    {
        float rotateAngle = -Time.deltaTime * _rotateSpeed;
        transform.Rotate(0.0f, 0.0f, rotateAngle);

        // 2차원 평면에서 제 3사분면의 각 범위 
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
    /// 새가 카메라 영역을 벗어나지 못하게 위치를 조정합니다.
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
    /// 오디오 소스를 출력합니다.
    /// </summary>
    /// <param name="type">추</param>
    private void PlayAudioSource(AudioType type)
    {
        uint audioIndex = (uint)(type);
        _audioSources[audioIndex].Play();
    }

    /// <summary>
    /// 오디오 소스를 비동기적으로 출력합니다.
    /// </summary>
    /// <param name="type">출력할 오디오의 종류입니다.</param>
    /// <param name="delay">오디오 출력의 지연 시간입니다.</param>
    /// <remarks>
    /// StartCoroutine와 함께 사용해야 합니다.
    /// </remarks>
    private IEnumerator PlayAudioSourceDelay(AudioType type, float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayAudioSource(type);
    }

    /// <summary>
    /// 그라운드 오브젝트와의 충돌 처리를 수행합니다.
    /// </summary>
    /// <param name="collision">그라운드 오브젝트의 콜리젼입니다.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 이미 Dead 상태라면 아무 동작도 수행하지 않음.
        if (_currentState == State.Dead)
        {
            return;
        }
        else if (_currentState == State.Fall)
        {
            // 이 상태는 파이프와 충돌하지 않고, 바로 바닥과 충돌한 상황입니다.
            this.Animation = false;

            PlayAudioSource(AudioType.Hit);
            PlayAudioSource(AudioType.Die);

            _gameMgr.CurrentGameState = GameManager.State.GameOver;
        }

        _gameMgr.CurrentGameState = GameManager.State.Done;
        _currentState = State.Dead;
    }

    /// <summary>
    /// 파이프 오브젝트와의 충돌을 감지하고 처리합니다.
    /// </summary>
    /// <param name="collision">파이프 오브젝트 하위의 콜라이더입니다.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 현재 상태가 이미 Crash 상태이거나 Dead 상태이면 아무 동작도 수행하지 않습니다.
        if (_currentState == State.Crash || _currentState == State.Dead)
        {
            return;
        }

        // 파이프 오브젝트의 Zone 영역과 충돌했다면...
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

        // 점프 후 떨어지도록 해당 메서드 호출.
        StartJumpBird();

        this.Animation = false;

        _gameMgr.CurrentGameState = GameManager.State.GameOver;
        _currentState = State.Crash;
    }
}
