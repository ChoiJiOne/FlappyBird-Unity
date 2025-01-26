using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ����(����, ����, ����)�մϴ�.
/// </summary>
/// <remarks>
/// �� ��ũ��Ʈ�� �÷��� �� ���� GameController ������Ʈ�� �Բ� �����մϴ�.
/// </remarks>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// �÷��� �� ���� �� ������Ʈ ��Ʈ�ѷ��Դϴ�.
    /// </summary>
    BirdController _birdController;

    /// <summary>
    /// �÷��� �� ���� GetReady UI ������Ʈ�Դϴ�.
    /// </summary>
    GameObject _getReadyUI;

    /// <summary>
    /// �÷��� �� ���� Instructions UI ������Ʈ�Դϴ�.
    /// </summary>
    GameObject _instructionsUI;

    /// <summary>
    /// �����ؾ� �� ��� ������Ʈ�� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _birdController = GameObject.Find("Bird").GetComponent<BirdController>();
        _getReadyUI = GameObject.Find("GetReady");
        _instructionsUI = GameObject.Find("Instructions");
    }

    private void Update()
    {
        
    }
}
