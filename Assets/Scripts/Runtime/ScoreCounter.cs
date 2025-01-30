using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ھ 0���� ȹ���� �������� ������ŵ�ϴ�.
/// </summary>
public class ScoreCounter : MonoBehaviour
{
    /// <summary>
    /// ī������ �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// Wait: ī���Ͱ� ��� �����Դϴ�.
    /// Process: ���ھ��� ī������ �������� �����Դϴ�.
    /// Done: ī������ ����� �����Դϴ�.
    /// </remarks>
    public enum State
    {
        Wait,
        Process,
        Done,
    }

    /// <summary>
    /// ī������ ���¿� ���� ������Ƽ�Դϴ�.
    /// </summary>
    public State CurrentState
    {
        get { return _currentState; }
    }

    /// <summary>
    /// ���� ī���� ���� �����Դϴ�.
    /// </summary>
    private int _currentScore = 0;

    /// <summary>
    /// ī���� Ÿ�� �����Դϴ�.
    /// </summary>
    private int _targetScore;

    /// <summary>
    /// ȹ�� �������� ������Ű�� �ð��Դϴ�.
    /// </summary>
    /// <remarks>
    /// �ð� ������ �� �����Դϴ�.
    /// </remarks>
    [SerializeField]
    private float _countTime;

    /// <summary>
    /// ���� ���� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �ð� ������ �� �����Դϴ�.
    /// </remarks>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// ī������ ���� �����Դϴ�.
    /// </summary>
    private State _currentState = State.Wait;

    /// <summary>
    /// ���ھ 0���� ȹ���� �������� ������ŵ�ϴ�.
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

        UpdateScoreText(_currentScore);

        if (_currentStepTime >= _countTime)
        {
            _currentState = State.Done;
        }
    }

    /// <summary>
    /// ī���͸� �����մϴ�. �̹� �����ߴµ�, �ٽ� ȣ���ϸ� �ʱ�ȭ �� ó������ �����մϴ�.
    /// </summary>
    public void StartCounter(int targetScore)
    {
        if (_currentState == State.Process || _currentState == State.Done)
        {
            _currentStepTime = 0.0f;
        }

        _targetScore = targetScore;
        _currentState = State.Process;
    }

    /// <summary>
    /// ���ھ��� �ؽ�Ʈ�� ������Ʈ�մϴ�.
    /// </summary>
    /// <param name="score">������Ʈ�� ���ھ��Դϴ�.</param>
    private void UpdateScoreText(int score)
    {
        TMPro.TextMeshProUGUI scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        if (scoreText.text == _targetScore.ToString())
        {
            return;
        }

        scoreText.text = score.ToString();
    }
}
