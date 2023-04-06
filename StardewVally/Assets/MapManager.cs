using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // MapManager�� ��� ��𼭵� ������ �ʿ��ϱ� ������ �̱��� ���
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
