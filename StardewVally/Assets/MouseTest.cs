using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    private Camera _mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        Debug.Log($"스크린 좌표계에서의 마우스 좌표 : {Input.mousePosition}");
        Debug.Log($"위의 좌표값과 대응되는 월드 좌표 : {_mainCamera.ScreenToWorldPoint(Input.mousePosition)}");
    }

    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        Vector3 targetPosition = transform.TransformPoint(new Vector3(0, 0, -10f));

        _mainCamera.transform.position =
            Vector3.SmoothDamp(_mainCamera.transform.position, targetPosition, ref velocity, 0.3f);
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        transform.Translate(moveDirection * (10f * Time.deltaTime));
    }
}
