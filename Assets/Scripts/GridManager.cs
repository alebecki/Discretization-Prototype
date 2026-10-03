using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int[,] grid;
    public GameObject[,] gridGOs;
    public int columns, rows;
    public GameObject tilePrefab;

    private static GridManager _instance;
    public static GridManager Instance { get { return _instance; } }        

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

            // vertical = (int)Camera.main.orthographicSize;
        // horizontal = vertical * (Screen.width / Screen.height);
        // columns = horizontal * 2;
        // rows = vertical * 2;
        grid = new int[columns, rows];
        gridGOs = new GameObject[columns, rows];
        bool isBlack = true;

        for (int i = 0; i < columns;i++) 
        {
            Color tileColor;

            for (int j = 0; j < rows; j++)
            {
                if (isBlack == true) 
                {
                    tileColor = Color.black;
                    isBlack = false;
                }
                else
                {
                    tileColor = Color.white;
                    isBlack = true;
                }

                grid[i,j] = Random.Range(0, 10);
                SpawnTile(i, j, grid[i,j], tileColor);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
    }

    private void SpawnTile(int x, int y, int value, Color tileColor) 
    {
        GameObject tile = Instantiate(tilePrefab);
        tile.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        tile.GetComponent<SpriteRenderer>().color = tileColor;
        tile.transform.position = new Vector3(x - 0.5f, y - 0.5f);
        gridGOs[x,y] = tile;
    }

    public Vector3 GetGridPos(int x, int y) 
    {
        Debug.Log(gridGOs[x,y].name);
        return gridGOs[x,y].gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
