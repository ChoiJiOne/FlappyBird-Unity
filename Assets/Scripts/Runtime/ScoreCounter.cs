using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScoreCounter;

/// <summary>
/// 스코어를 0부터 획득한 점수까지 증가시킵니다.
/// </summary>
public class ScoreCounter : MonoBehaviour
{
    /// <summary>
    /// 스코어의 카운팅이 종료되었을 때 실행할 델리게이트입니다.
    /// </summary>
    public delegate void OnProcessCounterDone();

    /// <summary>
    /// 카운터의 상태입니다.
    /// </summary>
    /// <remarks>
    /// Wait: 카운터가 대기 상태입니다.
    /// Process: 스코어의 카운팅이 진행중인 상태입니다.
    /// Done: 카운팅이 종료된 상태입니다.
    /// </remarks>
    public enum State
    {
        Wait,
        Process,
        Done,
    }

    /// <summary>
    /// 카운터의 상태에 대한 프로퍼티입니다.
    /// </summary>
    public State CurrentState
    {
        get { return _currentState; }
    }

    /// <summary>
    /// 현재 카운팅 중인 점수입니다.
    /// </summary>
    private int _currentScore = 0;

    /// <summary>
    /// 카운팅 타겟 점수입니다.
    /// </summary>
    private int _targetScore;

    /// <summary>
    /// 획득 점수까지 증가시키는 시간입니다.
    /// </summary>
    /// <remarks>
    /// 시간 단위는 초 단위입니다.
    /// </remarks>
    [SerializeField]
    private float _countTime;

    /// <summary>
    /// 현재 누적 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 시간 단위는 초 단위입니다.
    /// </remarks>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// 카운터의 현재 상태입니다.
    /// </summary>
    private State _currentState = State.Wait;

    /// <summary>
    /// 카운트 종료 시 실행할 델리게이트입니다.
    /// </summary>
    private OnProcessCounterDone _onProcessCounterDone;

    /// <summary>
    /// 스코어를 0부터 획득한 점수까지 증가시킵니다.
    /// </summary>
    private void Update()
    {
        if (_currentState != State.Process)
        {
            return;
        }

        _currentStepTime += Time.deltaTime;
        float t = Mathf.Clamp01(_currentStepTime / _countTime);
        float score = Mathf.Lerp(0.0f, (float)(_targetScore), t);
        _currentScore = (int)(score);

        ApplyScoreText(_currentScore);

        if (_currentStepTime >= _countTime)
        {
            _onProcessCounterDone?.Invoke();
            _currentState = State.Done;
        }
    }

    /// <summary>
    /// 카운터를 시작합니다. 이미 시작했는데, 다시 호출하면 초기화 후 처음부터 시작합니다.
    /// </summary>
    /// <param name="targetScore">카운터 대상이 되는 점수입니다. 0에서부터 대상이 되는 점수까지 증가합니다.</param>
    /// <param name="onProcessCounterDone">카운팅이 종료되었을 때 실행할 이벤트입니다.</param>
    public void StartCounter(int targetScore, OnProcessCounterDone onProcessCounterDone)
    {
        if (_currentState == State.Process || _currentState == State.Done)
        {
            _currentStepTime = 0.0f;
        }

        _targetScore = targetScore;
        _onProcessCounterDone = onProcessCounterDone;
        _currentState = State.Process;
    }

    /// <summary>
    /// 스코어의 텍스트를 적용합니다.
    /// </summary>
    /// <param name="score">업데이트할 스코어입니다.</param>
    private void ApplyScoreText(int score)
    {
        TMPro.TextMeshProUGUI scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        if (scoreText.text == _targetScore.ToString())
        {
            return;
        }

        scoreText.text = score.ToString();
    }
}
