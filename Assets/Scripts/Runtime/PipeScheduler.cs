using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 피해야 할 파이프를 스케줄링합니다.
/// </summary>
public class PipeScheduler : MonoBehaviour
{
    /// <summary>
    /// 파이프의 Y좌표 최댓값입니다.
    /// </summary>
    private const float MAX_Y_POSITION = 3.0f;

    /// <summary>
    /// 파이프의 Y좌표 최솟값입니다.
    /// </summary>
    private const float MIN_Y_POSITION = 0.0f;

    /// <summary>
    /// 스케쥴링해야 할 파이프의 최대 개수입니다.
    /// </summary>
    private const int MAX_PIPE_COUNT = 5;

    /// <summary>
    /// 파이프의 스케쥴링이 시작되었는지 확인합니다.
    /// </summary>
    private bool _isStart = false;
    
    /// <summary>
    /// 파이프를 활성화하는 시간입니다.
    /// </summary>
    private float _activePipeStepTime = 3.0f;

    /// <summary>
    /// 파이프 스케쥴러의 누적 시간값입니다.
    /// </summary>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// 파이프 오브젝트의 프리팹입니다.
    /// </summary>
    public GameObject _pipePrefab;

    /// <summary>
    /// 대기 중인 파이프 오브젝트입니다.
    /// </summary>
    private Queue<GameObject> _waitPipeObjectQueue;

    /// <summary>
    /// 스케줄링할 파이프를 생성합니다.
    /// </summary>
    private void Awake()
    {
        _waitPipeObjectQueue = new Queue<GameObject>();

        for(int count = 0; count < MAX_PIPE_COUNT; ++count)
        {
            Vector3 position = transform.position;

            GameObject pipe = Instantiate(_pipePrefab);
            pipe.SetActive(false);

            _waitPipeObjectQueue.Enqueue(pipe);
        }
    }

    /// <summary>
    /// 파이프의 스케줄링을 수행합니다.
    /// </summary>
    private void Update()
    {
        if (!_isStart)
        {
            return;
        }

        _currentStepTime += Time.deltaTime;
        if (_currentStepTime < _activePipeStepTime)
        {
            return;
        }

        _currentStepTime -= _activePipeStepTime;

        GameObject pipe = _waitPipeObjectQueue.Dequeue();
        pipe.SetActive(true);

        PipeController pipeController = pipe.GetComponent<PipeController>();
        pipeController.Speed = 5.0f;
        pipeController.Movable = true;
    }

    /// <summary>
    /// 파이프의 스케쥴링을 시작합니다.
    /// </summary>
    public void BeginScheduling()
    {
        if (_isStart)
        {
            return;
        }

        _isStart = true;
    }
}
