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
    /// 파이프 오브젝트의 프리팹입니다.
    /// </summary>
    public GameObject _pipePrefab;

    /// <summary>
    /// 대기 중인 파이프 오브젝트입니다.
    /// </summary>
    private Queue<GameObject> _waitPipeObjectQueue;

    /// <summary>
    /// 활성화된 파이프 오브젝트입니다.
    /// </summary>
    private Queue<GameObject> _activePipeObjectQueue;

    /// <summary>
    /// 스케줄링할 파이프를 생성합니다.
    /// </summary>
    private void Awake()
    {
        _waitPipeObjectQueue = new Queue<GameObject>();
        _activePipeObjectQueue = new Queue<GameObject>();

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
    }
}
