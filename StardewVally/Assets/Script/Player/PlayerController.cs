using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private PlayerFSM _fsm;

    // animator를 집어넣을수 있게 해줬네..? 왜이렇게 했더라?? 어쨋든 Tool도 Body 하위 오브젝트니까 Body를 실행시키면 Tool도 실행될것.
    [SerializeField]
    private Animator _animator;

    [Range(0,10)] public float speed;

    private void Awake()
    {
        _fsm = new PlayerFSM(gameObject);
        // PlayerController의 speed를 PlayerFSM의 speed로 설정해준다.
        _fsm.speed = this.speed;
        _fsm.animator = this._animator;
    }

    void Update()
    {
        _fsm.Update();
    }
}