using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ�� �浹 ó���� �����Ͽ� �̺�Ʈ�� �����մϴ�.
/// </summary>
public class CollisionTrigger : MonoBehaviour
{
    /// <summary>
    /// �浹�� ���� �߻����� �� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /// <summary>
    /// �浹�� ���� �߻��� ���Ŀ� �浹�� ��� ����ǰ� ���� �� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    /// <remarks>
    /// �浹�� ��� ����ǰ� �ִٸ� Update�� ȣ���� ������ ȣ��˴ϴ�.
    /// </remarks>
    private void OnTriggerEnterStay(Collider2D collision)
    {

    }

    /// <summary>
    /// �浹�� �߻��� ���� �浹���� ����� �� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="collision">�ش� ������Ʈ�� �浹�� �� �ٸ� ������Ʈ�� �浹ü(Collider)�Դϴ�.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
