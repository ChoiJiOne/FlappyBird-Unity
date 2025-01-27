using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트의 충돌 처리를 감지하여 이벤트를 실행합니다.
/// </summary>
public class CollisionTrigger : MonoBehaviour
{
    /// <summary>
    /// 충돌이 최초 발생했을 때 호출됩니다.
    /// </summary>
    /// <param name="collision">해당 오브젝트와 충돌한 또 다른 오브젝트의 충돌체(Collider)입니다.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /// <summary>
    /// 충돌이 최초 발생한 이후에 충돌이 계속 진행되고 있을 때 호출됩니다.
    /// </summary>
    /// <param name="collision">해당 오브젝트와 충돌한 또 다른 오브젝트의 충돌체(Collider)입니다.</param>
    /// <remarks>
    /// 충돌이 계속 진행되고 있다면 Update를 호출할 때마다 호출됩니다.
    /// </remarks>
    private void OnTriggerEnterStay(Collider2D collision)
    {

    }

    /// <summary>
    /// 충돌이 발생한 이후 충돌에서 벗어났을 때 호출됩니다.
    /// </summary>
    /// <param name="collision">해당 오브젝트와 충돌한 또 다른 오브젝트의 충돌체(Collider)입니다.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
