using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// ������ ������Ʈ ���� �� ��� ť�� �߰��մϴ�.
    /// </summary>
    /// <remarks>
    /// ���� �ӷ� ���� ������ GameManager���� ����ǹǷ�, Start���� �ʱ�ȭ�� �����ؾ� �մϴ�.
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
}
