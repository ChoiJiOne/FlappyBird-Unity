using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 그라운드를 제어합니다.
/// </summary>
/// <remarks>
/// 주로 횡 스크롤 속도 및 충돌 처리를 수행합니다.
/// </remarks>
public class GroundController : MonoBehaviour
{
    /// <summary>
    /// 그라운드 오브젝트의 횡 스크롤 속력입니다.
    /// </summary>
    [SerializeField]
    private float _scrollSpeed;

    /// <summary>
    /// 셰이더에 전달할 그라운드 텍스처의 오프셋 값입니다.
    /// </summary>
    private Vector2 _textureOffset = Vector2.zero;

    /// <summary>
    /// 그라운드 오브젝트의 재질입니다.
    /// </summary>
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
