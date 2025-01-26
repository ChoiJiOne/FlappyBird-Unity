using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���� ��Ʈ�ѷ��� ���� ������ ������Ʈ�Դϴ�.
/// </summary>
/// <remarks>
/// �÷��� �� ������ ���� ��Ʈ�ѷ��� �����ؾ� �� ������Ʈ�� �� Ŭ������ ��ӹ޾ƾ� �մϴ�.
/// </remarks>
public class ControllableObject : MonoBehaviour
{
    /// <summary>
    /// ���� ��Ʈ�ѷ� ������Ʈ�Դϴ�.
    /// </summary>
    protected GameController _gameController;

    /// <summary>
    /// ���� ������Ʈ ��Ʈ�ѷ��� �ʱ�ȭ�մϴ�.
    /// </summary>
    protected void Awake()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
}
