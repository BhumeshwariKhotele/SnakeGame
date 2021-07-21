using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] SnakeTile snakeTilePrefab;

    private List<SnakeTile> snakePieces;
    public List<SnakeTile> SnakePieces
    {
        get
        {
            return snakePieces;
        }
    }

    public void InitializeSnake()
    {
        snakePieces = new List<SnakeTile>();
        transform.position = GridManager.Instance.GetRandomTile(5);
        snakeTilePrefab snakeTile = Instantiate(snakeTilePrefab, transform.position, Quaternion.identity);
        snakeTile.transform.parent = transform;
    }

    void AddPiece()
    {
        snakeTilePrefab snakeTile = Instantiate(snakeTilePrefab, transform.position);
    }

}