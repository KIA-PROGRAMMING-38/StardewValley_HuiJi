using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    [Range(4f, 10f)]
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 즉각적인 반응을 위해 GetAxisRaw() 사용
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticlaInput = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticlaInput);

        transform.Translate(moveDirection * (Speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int cellPosition = MapManager.Instance.GetCellPositionFromWorld(transform.position);
            Debug.Log($"플레이어의 현재 위치한 셀 좌표는 : {cellPosition}");
        }
    }
}
