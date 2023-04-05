using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private float mousePositionX;
    private float mousePositionY;

    // animator를 집어넣을수 있게 해줬네..? 왜이렇게 했더라?? 어쨋든 Tool도 Body 하위 오브젝트니까 Body를 실행시키면 Tool도 실행될것.
    [SerializeField]
    private Animator _animator;

    [Range(0,10)] public float speed;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // if (Input.GetMouseButton(0))
        // {
        //     mousePositionX = Input.mousePosition.x;
        //     mousePositionY = Input.mousePosition.y;
        //
        //     Debug.Log(mousePositionX);
        //     Debug.Log(gameObject.transform.localPosition.x);
        //     // Left
        //     if (mousePositionX < gameObject.transform.position.x)
        //     {
        //         Debug.Log("좌로 클릭");
        //         _animator.SetFloat("Horizontal", mousePositionX);
        //     }
        // }
        
    }
}