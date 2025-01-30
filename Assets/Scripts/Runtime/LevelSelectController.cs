using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 레벨 선택을 제어합니다.
/// </summary>
/// <remarks>
/// 레벨 선택 컨트롤러는 세팅 씬의 LeftSelectButton와 RightSelectButton가 함께 동작합니다.
/// </remarks>
public class LevelSelectController : MonoBehaviour
{
    /// <summary>
    /// 선택할 레벨 오브젝트 목록입니다.
    /// </summary>
    [SerializeField]
    private GameObject[] _levelObjects;

    /// <summary>
    /// 현재 선택한 레벨의 인덱스입니다.
    /// </summary>
    private int _currentSelectIndex = 0;

    /// <summary>
    /// LeftSelectButton 버튼을 클릭했을 때 실행할 이벤트입니다.
    /// </summary>
    public void OnClickLeftSelectButton()
    {

    }

    /// <summary>
    /// RightSelectButton 버튼을 클릭했을 때 실행할 이벤트입니다.
    /// </summary>
    public void OnClickRightSelecttButton()
    {

    }
}
