using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ�� �浹 ó���� �����Ͽ� �̺�Ʈ�� �����մϴ�.
/// </summary>
public class CollisionTrigger : MonoBehaviour
{
    /// <summary>
    /// �浹 ���� �� ������ �̺�Ʈ�� ������ �� ����� ������Ƽ�Դϴ�.
    /// </summary>
    public CollisionTriggerEventHandler OnTriggerEnterEvent
    {
        set { _onTriggerEnterEvent = value; }
    }

    /// <summary>
    /// �浹�� ���� �߻��� ���Ŀ� �浹�� ��� ����ǰ� ���� �� ȣ���� �̺�Ʈ�� ������ �� ����� ������Ƽ�Դϴ�.
    /// </summary>
    public CollisionTriggerEventHandler OnTriggerStayEvent
    {
        set { _onTriggerStayEvent = value; }
    }

    /// <summary>
    /// �浹�� �߻��� ���� �浹���� ����� �� ȣ���� �̺�Ʈ�� ������ �� ����� ������Ƽ�Դϴ�.
    /// </summary>
    public CollisionTriggerEventHandler OnTriggerExitEvent
    {
        set { _onTriggerExitEvent = value; }
    }

    /// �浹 ���� �� ������ �̺�Ʈ�Դϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    public delegate void CollisionTriggerEventHandler(Collider2D collision);

    /// <summary>
    /// �浹�� ���� �߻����� �� ȣ���� �̺�Ʈ�Դϴ�.
    /// </summary>
    private CollisionTriggerEventHandler _onTriggerEnterEvent;

    /// <summary>
    /// �浹�� ���� �߻��� ���Ŀ� �浹�� ��� ����ǰ� ���� �� ȣ���� �̺�Ʈ�Դϴ�.
    /// </summary>
    private CollisionTriggerEventHandler _onTriggerStayEvent;

    /// <summary>
    /// �浹�� �߻��� ���� �浹���� ����� �� ȣ���� �̺�Ʈ�Դϴ�.
    /// </summary>
    private CollisionTriggerEventHandler _onTriggerExitEvent;

    /// <summary>
    /// �浹�� ���� �߻����� �� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onTriggerEnterEvent?.Invoke(collision);
    }

    /// <summary>
    /// �浹�� ���� �߻��� ���Ŀ� �浹�� ��� ����ǰ� ���� �� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    /// <remarks>
    /// �浹�� ��� ����ǰ� �ִٸ� Update�� ȣ���� ������ ȣ��˴ϴ�.
    /// </remarks>
    private void OnTriggerStay2D(Collider2D collision)
    {
        _onTriggerStayEvent?.Invoke(collision);
    }

    /// <summary>
    /// �浹�� �߻��� ���� �浹���� ����� �� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        _onTriggerExitEvent?.Invoke(collision);
    }
}
