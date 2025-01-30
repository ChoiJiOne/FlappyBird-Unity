using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스코어 UI를 제어합니다.
/// </summary>
/// <remarks>
/// 이때, 움직임의 속력은 시간 단위로 지정합니다.
/// 예를 들어 2초라고 지정하면 지정된 위치까지 2초동안 이동합니다.
/// </remarks>
public class ScoreUIController : MonoBehaviour
{
    /// <summary>
    /// 플레이어 스코어에 대한 프로퍼티입니다.
    /// </summary>
    public int PlayerScore
    {
        get { return _playerScore;  }
        set { _playerScore = value; }
    }

    /// <summary>
    /// 플레이어가 획득한 메달입니다.
    /// </summary>
    /// <remarks>
    /// 이 열거형은 스코어 UI를 제어하는 컨트롤러 내부에서만 사용합니다.
    /// </remarks>
    private enum Medal : uint
    {
        Bronze = 0,
        Silver = 1,
        Gold = 2,
    }

    /// <summary>
    /// UI의 랙 트랜스폼입니다.
    /// </summary>
    private RectTransform _rectTransform;

    /// <summary>
    /// UI의 이동 시간입니다.
    /// </summary>
    /// <remarks>
    /// 시간의 단위는 초 단위입니다.
    /// </remarks>
    [SerializeField]
    private float _moveTime;

    /// <summary>
    /// UI의 시작 위치입니다.
    /// </summary>
    private Vector2 _startPosition;

    /// <summary>
    /// UI의 도착 위치입니다.
    /// </summary>
    [SerializeField]
    private Vector2 _endPosition;

    /// <summary>
    /// UI가 이동하는 동안 누적된 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 이 값은 _moveTime 값을 넘어설 수 없습니다.
    /// </remarks>
    private float _moveStepTime = 0.0f;

    /// <summary>
    /// UI가 도착 위치에 있는지 확인합니다.
    /// </summary>
    private bool _isAtDestination = false;

    /// <summary>
    /// 플레이어의 스코어를 표시하는 텍스트 UI입니다.
    /// </summary>
    [SerializeField]
    private GameObject _playerScoreUI;

    /// <summary>
    /// 플레이어가 획득한 스코어를 0부터 증가시킵니다.
    /// </summary>
    private ScoreCounter _scoreCounter;

    /// <summary>
    /// 플레이어의 최고 점수를 표시하는 텍스트 UI입니다.
    /// </summary>
    [SerializeField]
    private GameObject _bestScoreUI;

    /// <summary>
    /// 플레이어의 점수에 따라 부여하는 메달 UI 목록입니다.
    /// </summary>
    [SerializeField]
    private GameObject[] _medalUIs;

    /// <summary>
    /// 플레이어가 획득한 점수입니다.
    /// </summary>
    int _playerScore = 0;

    /// <summary>
    /// 플레이어의 최고 점수입니다.
    /// </summary>
    int _playerBestScore = 0;
    
    /// <summary>
    /// UI의 랙 트랜스 폼과 시작 위치를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.anchoredPosition;

        _scoreCounter = _playerScoreUI.GetComponent<ScoreCounter>();

        foreach (GameObject medalUI in _medalUIs)
        {
            medalUI.SetActive(false);
        }
    }

    /// <summary>
    /// UI를 지정된 위치로 이동시킵니다.
    /// </summary>
    private void Update()
    {
        MoveScoreBoard();
    }

    /// <summary>
    /// 스코어 보드를 이동시킵니다.
    /// </summary>
    private void MoveScoreBoard()
    {
        // 도착했다면 아무 동작도 수행하지 않음.
        if (_isAtDestination)
        {
            return;
        }

        _moveStepTime += Time.deltaTime;
        if (_moveStepTime >= _moveTime)
        {
            _scoreCounter.StartCounter(_playerScore, this.ActivePlayerMetal);
            _isAtDestination = true;
        }

        float t = Mathf.Clamp01(_moveStepTime / _moveTime);
        Vector2 newPosition = Vector2.Lerp(_startPosition, _endPosition, t);

        _rectTransform.anchoredPosition = newPosition;
    }

    /// <summary>
    /// 플레이어가 획득한 점수에 따라 메달 오브젝트를 활성화합니다.
    /// </summary>
    /// <remarks>
    /// 최고 점수를 넘은 경우: Gold
    /// 최고 점수와 동일한 경우: Silver
    /// 최고 점수보다 낮은 경우: Bronze
    /// </remarks>
    private void ActivePlayerMetal()
    {
        uint medalUIIndex = 0;

        if (_playerScore > _playerBestScore)
        {
            medalUIIndex = (uint)(Medal.Gold);
        }
        else if (_playerScore == _playerBestScore)
        {
            medalUIIndex = (uint)(Medal.Silver);
        }
        else
        {
            medalUIIndex = (uint)(Medal.Bronze);
        }

        _medalUIs[medalUIIndex].SetActive(true);
    }
}
