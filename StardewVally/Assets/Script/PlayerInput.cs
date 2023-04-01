using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Animator[] _animator;

    private void Awake()
    {
        _animator = GetComponentsInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("왼쪽키를 누름");
            _animator[0].SetBool("isLeft", true);
        }
    }
}
