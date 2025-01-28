using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 내의 파이프 오브젝트를 관리합니다.
/// </summary>
public class PipeManager : MonoBehaviour
{
    /// <summary>
    /// 파이프의 이동 속력을 설정하는 프로퍼티입니다.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// 파이프의 프리팹 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _pipePrefab;

    /// <summary>
    /// 파이프 끝 위치의 X좌표 값입니다.
    /// </summary>
    [SerializeField]
    private float _endXPosition;

    /// <summary>
    /// 파이프의 이동 속도입니다.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// 파이프 매니저가 관리하는 파이프의 개수입니다.
    /// </summary>
    [SerializeField]
    private int _pipeCount;

    /// <summary>
    /// 대기 중인 파이프 오브젝트의 큐입니다.
    /// </summary>
    private Queue<GameObject> _waitPipeObjects;

    /// <summary>
    /// 파이프를 활성화하는 시간입니다.
    /// </summary>
    [SerializeField]
    private float _activePipeStepTime;

    /// <summary>
    /// 파이프 스케쥴러의 누적 시간값입니다.
    /// </summary>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// 파이프 오브젝트 생성 후 대기 큐에 추가합니다.
    /// </summary>
    /// <remarks>
    /// 게임 속력 관련 설정은 GameManager에서 수행되므로, Start에서 초기화를 수행해야 합니다.
    /// </remarks>
    private void Start()
    {
        _waitPipeObjects = new Queue<GameObject>();

        for(int count = 0; count < _pipeCount; ++count)
        {
            GameObject pipe = Instantiate(_pipePrefab);
            pipe.SetActive(false);

            PipeController pipeController = pipe.GetComponent<PipeController>();
            pipeController.MoveSpeed = _moveSpeed;
            pipeController.EndXPosition = _endXPosition;
            pipeController.Movable = false;

            _waitPipeObjects.Enqueue(pipe);
        }
    }

    /// <summary>
    /// 특정 시간이 되면 대기 큐의 파이프 오브젝트를 활성화시킵니다.
    /// </summary>
    private void Update()
    {
        _currentStepTime += Time.deltaTime;
        if (_currentStepTime < _activePipeStepTime)
        {
            return;
        }

        _currentStepTime -= _activePipeStepTime;

        GameObject pipe = _waitPipeObjects.Dequeue();
        pipe.SetActive(true);

        PipeController pipeController = pipe.GetComponent<PipeController>();
        pipeController.Movable = true;
    }
}
