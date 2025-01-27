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
    /// ������ ������Ʈ�� �������Դϴ�.
    /// </summary>
    public GameObject _pipePrefab;

    /// <summary>
    /// �����층�ؾ� �� ������ ������Ʈ�Դϴ�.
    /// </summary>
    private Queue<GameObject> _pipeObjects;

    /// <summary>
    /// �����ٸ��� �������� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _pipeObjects = new Queue<GameObject>();
        for(int count = 0; count < MAX_PIPE_COUNT; ++count)
        {
            Vector3 position = transform.position;

            GameObject pipe = Instantiate(_pipePrefab);
            pipe.SetActive(false);

            _pipeObjects.Enqueue(pipe);
        }
    }

    private void Update()
    {
        
    }
}
