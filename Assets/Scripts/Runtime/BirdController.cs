using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 새를 제어합니다.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// 새의 색상 별 애니메이션 클립을 제어합니다.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// 새의 색상 별 애니메이션 클립을 제어하는 애니메이터를 초기화합니다.
    /// </summary>
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
}
