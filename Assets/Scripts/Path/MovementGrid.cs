using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementGrid : MonoBehaviour
{
    public int _cellSize;//the cell size of the gridcell

    //grid width and height
    public int _gridWidth,
               _gridHeight;

    //prdab for the points
    public GameObject _gridPointPrefab;

    public float _startX,
                 _startY;

    //bool GenrateGrid = false;
   public GameObject[,] gridPoints;

    private void Start()
    {
        gridPoints = new GameObject[_gridWidth, _gridHeight];
        MakeGrid();
    }
    private void Update()
    {
        // MakeGrid();
    //#if UNITY_EDITOR
    //      if(GenrateGrid)  MakeGrid();
    //#endif

    }

    private void MakeGrid()
    {
        for (int i = 0; i < _gridWidth ; i++)
        {
            for (int j = 0; j < _gridHeight + 1; j++)
            {
                //drawing the grid wrt the size and the position gicen in the inspector
                Vector2 spawnPos = new Vector2(_startX + (_cellSize * i ), -_startY + (_cellSize * (j)));
                var spawItem = Instantiate(_gridPointPrefab, spawnPos, Quaternion.identity);
                spawItem.name = $"{i} : {j}";
                spawItem.transform.parent = this.transform;
               
            }
            ///
            //Vector2 spawnPos = new Vector2(_startX +(_cellSize * i%_gridWidth) , _startY + (_cellSize * (i/_gridWidth))) ;
            //var spawItem = Instantiate(_gridBackgroundPrefab, spawnPos, Quaternion.identity);
            // spawItem.name = $"{spawnPos.x} : {spawnPos.y}";
            //    spawItem.transform.parent = this.transform;
        }
    }
}
