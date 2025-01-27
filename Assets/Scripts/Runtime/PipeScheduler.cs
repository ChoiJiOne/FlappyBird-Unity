using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ���ؾ� �� �������� �����ٸ��մϴ�.
/// </summary>
public class PipeScheduler : MonoBehaviour
{
    /// <summary>
    /// �������� Y��ǥ �ִ��Դϴ�.
    /// </summary>
    private const float MAX_Y_POSITION = 3.0f;

    /// <summary>
    /// �������� Y��ǥ �ּڰ��Դϴ�.
    /// </summary>
    private const float MIN_Y_POSITION = 0.0f;

    /// <summary>
    /// �����층�ؾ� �� �������� �ִ� �����Դϴ�.
    /// </summary>
    private const int MAX_PIPE_COUNT = 5;

    /// <summary>
    /// �������� �����층�� ���۵Ǿ����� Ȯ���մϴ�.
    /// </summary>
    private bool _isStart = false;
    
    /// <summary>
    /// �������� Ȱ��ȭ�ϴ� �ð��Դϴ�.
    /// </summary>
    private float _activePipeStepTime = 3.0f;

    /// <summary>
    /// ������ �����췯�� ���� �ð����Դϴ�.
    /// </summary>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// ������ ������Ʈ�� �������Դϴ�.
    /// </summary>
    public GameObject _pipePrefab;

    /// <summary>
    /// ��� ���� ������ ������Ʈ�Դϴ�.
    /// </summary>
    private Queue<GameObject> _waitPipeObjectQueue;

    /// <summary>
    /// �����ٸ��� �������� �����մϴ�.
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
    /// �������� �����ٸ��� �����մϴ�.
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
    /// �������� �����층�� �����մϴ�.
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
