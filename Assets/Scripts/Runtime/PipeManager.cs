using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 파이프의 위치 Y값의 범위입니다.
/// </summary>
[Serializable]
public struct PipeYPositionRange
{
    /// <summary>
    /// Y값의 최솟값입니다.
    /// </summary>
    public float minYPosition;

    /// <summary>
    /// Y값의 최댓값입니다.
    /// </summary>
    public float maxYPosition;

    /// <summary>
    /// 닫힌 구간 [minYPosition, maxYPosition] 사이의 임의의 난수를 얻습니다.
    /// </summary>
    /// <returns>[minYPosition, maxYPosition] 사이의 임의의 난수 값을 반환니다.</returns>
    public float GetRandomYPosition()
    {
        return UnityEngine.Random.Range(minYPosition, maxYPosition);
    }
}

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
    /// 파이프의 Y좌표 값의 범위입니다.
    /// </summary>
    [SerializeField]
    private PipeYPositionRange _pipeYPositionRange;

    /// <summary>
    /// 파이프 매니저가 관리하는 파이프 오브젝트 목록입니다.
    /// </summary>
    private GameObject[] _pipes;

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
    /// 파이프 매니저가 활성화 되어 있는지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 이 변수가 false라면 파이프 매니저는 매니징을 수행하지 않고, 파이프 오브젝트는 화면에 보이기는 하지만 이동이 중지됩니다.
    /// </remarks>
    private bool _isManagerActive = false;

    /// <summary>
    /// 파이프 오브젝트 생성 후 대기 큐에 추가합니다.
    /// </summary>
    /// <remarks>
    /// 게임 속력 관련 설정은 GameManager에서 수행되므로, Start에서 초기화를 수행해야 합니다.
    /// </remarks>
    private void Start()
    {
        _pipes = new GameObject[_pipeCount];
        _waitPipeObjects = new Queue<GameObject>();
        for(int index = 0; index < _pipeCount; ++index)
        {
            GameObject pipe = Instantiate(_pipePrefab);
            pipe.SetActive(false);

            PipeController pipeController = pipe.GetComponent<PipeController>();
            pipeController.MoveSpeed = _moveSpeed;
            pipeController.EndXPosition = _endXPosition;
            pipeController.Movable = false;
            pipeController.PipeManager = this;
            pipeController.YPosition = _pipeYPositionRange.GetRandomYPosition();

            _pipes[index] = pipe;
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

    /// <summary>
    /// 대기 큐에 파이프 오브젝트를 삽입합니다.
    /// </summary>
    /// <param name="pipe">대기 큐에 삽입할 파이프 오브젝트입니다.</param>
    /// <remarks>
    /// 삽입할 오브젝트가 PipeController를 소유하고 있지 않으면 삽입되지 않습니다.
    /// </remarks>
    public void EnqueuePipeToWaitQueue(GameObject pipe)
    {
        PipeController pipeController = pipe.GetComponent<PipeController>();
        if (pipeController == null)
        {
            return;
        }
        
        pipeController.Movable = false;
        pipeController.YPosition = _pipeYPositionRange.GetRandomYPosition();

        pipe.SetActive(false);
        _waitPipeObjects.Enqueue(pipe);
    }
}
