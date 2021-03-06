using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    GridTile GridTilePrefab;

    [SerializeField]
    Transform playArea;

    [SerializeField]
    int gridSize = 10;

    public int GridSize
    {
        get
        {
            return gridSize;  
        }
    }

    Vector3 startPoint;
    public Vector3 StartPoint
    {
        get
        {
            return startPoint;
        }
    }

    int width, height;

    Transform[,] grid;

    public Vector3 GetRandomTile(int margin=0)
    {
        if((margin>width || margin>height) && margin<0)
        {
            return GetTileAt(0, 0);
        }
        int x = UnityEngine.Random.Range(0 + margin, width - margin);
        int y = UnityEngine.Random.Range(0 + margin, height - margin);
        return GetTileAt(x, y);
    }

    private Vector3 GetTileAt(int x, int y)
    {
       if( grid[x,y] != null )
        {
            return grid[x, y].GetComponent<GridTile>();
        }
        return null;
    }

    public void InitializeGrid()
    {
        width = Mathf.RoundToInt(playArea.localScale.x * gridSize);
        height = Mathf.RoundToInt(playArea.localScale.y * gridSize);
        grid = new Transform[width, height];
        startPoint = playArea.GetComponent<Renderer>().bounds.min;
        Debug.Log(startPoint);
        CreateGridTile();
    }

    private void CreateGridTile()
    {
        if (GridTilePrefab == null)
            return;

        for(int i=0; i < width; i++)
        {
            for(int j=0; j < height; j++)
            {
                Vector3 worldPos = GetWorldPos(i,j);
                GridTile gridTile = Instantiate(GridTilePrefab, worldPos, Quaternion.identity);
                gridTile.name = string.Format("Tile({0},{1})", i, j);
                grid[i, j] = gridTile.transform;
            }
        }
    }

    private Vector3 GetWorldPos(int a, int b)
    {
        float sp = a;
        float ap = b;
        return new Vector3(startPoint.x + (sp / gridSize), startPoint.y + (ap / gridSize),startPoint.z);
    
    }

    private void Start()
    {
        InitializeGrid();
    }

}
