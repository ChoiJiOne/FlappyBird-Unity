using System;
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
    /// 레벨 오브젝트의 목록 내의 게임 오브젝트들을 명시적으로 비활성화합니다.
    /// </summary>
    private void Awake()
    {
        for(int index = 0; index < _levelObjects.Length; ++index)
        {
            if (index == _currentSelectIndex)
            {
                continue;
            }

            SetActiveLevelObject(index, false);
        }
    }

    /// <summary>
    /// LeftSelectButton 버튼을 클릭했을 때 실행할 이벤트입니다.
    /// </summary>
    public void OnClickLeftSelectButton()
    {
        SetActiveLevelObject(_currentSelectIndex, false);

        if (_currentSelectIndex == 0)
        {
            _currentSelectIndex = _levelObjects.Length;
        }
        _currentSelectIndex--;

        SetActiveLevelObject(_currentSelectIndex, true);
    }

    /// <summary>
    /// RightSelectButton 버튼을 클릭했을 때 실행할 이벤트입니다.
    /// </summary>
    public void OnClickRightSelecttButton()
    {
    }

    /// <summary>
    /// 레벨 오브젝트의 활성화 여부를 설정합니다.
    /// </summary>
    /// <param name="levelObjectIndex">활성화 여부를 설정할 레벨 오브젝트의 인덱스입니다.</param>
    /// <param name="isActive">활성화 여부입니다.</param>
    private void SetActiveLevelObject(int levelObjectIndex, bool isActive)
    {
        // 인덱스가 배열의 범위를 벗어난다면 아무 동작도 수행하지 않습니다.
        if (levelObjectIndex < 0 || levelObjectIndex >= _levelObjects.Length)
        {
            return;
        }

        _levelObjects[levelObjectIndex].SetActive(isActive);
    }
}
