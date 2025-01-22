using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Background : MonoBehaviour
{
    /// <summary>
    /// 백드라운드의 트랜스폼입니다. 백그라운드의 스케일 값을 조정하기 위한 멤버 변수입니다.
    /// </summary>
    private Transform _transform;

    /// <summary>
    /// 백그라운드가 렌더링할 스프라이트를 설정할 스프라이트 렌더러입니다.
    /// </summary>
    private SpriteRenderer _spriteRenderer;
    
    /// <summary>
    /// 첫 프레임이 시작되기 전에 호출합니다.
    /// </summary>
    void Start()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 매 프레임 한 번 호출합니다.
    /// </summary>
    void Update()
    {
        
    }
}
