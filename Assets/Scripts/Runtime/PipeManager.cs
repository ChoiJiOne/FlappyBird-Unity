using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ��ġ Y���� �����Դϴ�.
/// </summary>
[Serializable]
public struct PipeYPositionRange
{
    /// <summary>
    /// Y���� �ּڰ��Դϴ�.
    /// </summary>
    public float minYPosition;

    /// <summary>
    /// Y���� �ִ��Դϴ�.
    /// </summary>
    public float maxYPosition;

    /// <summary>
    /// ���� ���� [minYPosition, maxYPosition] ������ ������ ������ ����ϴ�.
    /// </summary>
    /// <returns>[minYPosition, maxYPosition] ������ ������ ���� ���� ��ȯ�ϴ�.</returns>
    public float GetRandomYPosition()
    {
        return UnityEngine.Random.Range(minYPosition, maxYPosition);
    }
}

/// <summary>
/// ���� ���� ������ ������Ʈ�� �����մϴ�.
/// </summary>
public class PipeManager : MonoBehaviour
{
    /// <summary>
    /// �������� �̵� �ӷ��� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }
        
    /// <summary>
    /// �������� ������ ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _pipePrefab;

    /// <summary>
    /// ������ �� ��ġ�� X��ǥ ���Դϴ�.
    /// </summary>
    [SerializeField]
    private float _endXPosition;

    /// <summary>
    /// �������� �̵� �ӵ��Դϴ�.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// ������ �Ŵ����� �����ϴ� �������� �����Դϴ�.
    /// </summary>
    [SerializeField]
    private int _pipeCount;

    /// <summary>
    /// �������� Y��ǥ ���� �����Դϴ�.
    /// </summary>
    [SerializeField]
    private PipeYPositionRange _pipeYPositionRange;

    /// <summary>
    /// ������ �Ŵ����� �����ϴ� ������ ������Ʈ ����Դϴ�.
    /// </summary>
    private GameObject[] _pipes;

    /// <summary>
    /// ��� ���� ������ ������Ʈ�� ť�Դϴ�.
    /// </summary>
    private Queue<GameObject> _waitPipeObjects;

    /// <summary>
    /// �������� Ȱ��ȭ�ϴ� �ð��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _activePipeStepTime;

    /// <summary>
    /// ������ �����췯�� ���� �ð����Դϴ�.
    /// </summary>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// ������ �Ŵ����� Ȱ��ȭ �Ǿ� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <remarks>
    /// �� ������ false��� ������ �Ŵ����� �Ŵ�¡�� �������� �ʰ�, ������ ������Ʈ�� ȭ�鿡 ���̱�� ������ �̵��� �����˴ϴ�.
    /// </remarks>
    private bool _isManagerActive = false;

    /// <summary>
    /// ������ ������Ʈ ���� �� ��� ť�� �߰��մϴ�.
    /// </summary>
    /// <remarks>
    /// ���� �ӷ� ���� ������ GameManager���� ����ǹǷ�, Start���� �ʱ�ȭ�� �����ؾ� �մϴ�.
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
    /// Ư�� �ð��� �Ǹ� ��� ť�� ������ ������Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
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
    /// ��� ť�� ������ ������Ʈ�� �����մϴ�.
    /// </summary>
    /// <param name="pipe">��� ť�� ������ ������ ������Ʈ�Դϴ�.</param>
    /// <remarks>
    /// ������ ������Ʈ�� PipeController�� �����ϰ� ���� ������ ���Ե��� �ʽ��ϴ�.
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
