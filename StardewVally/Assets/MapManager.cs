using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // MapManager의 경우 어디서든 접근이 필요하기 때문에 싱글톤 사용
    public static MapManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = GameObject.FindObjectOfType<MapManager>();
            }

            return s_instance;
        }
    }

    private static MapManager s_instance;

    private Grid _grid;

    private void Awake()
    {
        _grid = GetComponent<Grid>();
        
        if (s_instance == null)
        {
            s_instance = this;
        }
    }

    public Vector3Int GetCellPositionFromWorld(Vector3 worldPosition) => _grid.WorldToCell(worldPosition);
}
