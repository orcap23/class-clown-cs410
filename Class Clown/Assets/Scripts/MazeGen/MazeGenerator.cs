using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool[] walls = new bool[4];
        public bool visited = false;
        public Vector2Int pos;
    }
    public Vector2Int size;
    Cell[,] board;
    public GameObject Hallway;
    public Vector2Int offset;

    void Start()
    {
        GenerateMaze();
    }
    void GenerateHallways()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                //Debug.Log(board[i,j].visited);
                RoomBehavior newHallway = Instantiate(Hallway, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                newHallway.UpdateRoom(board[i,j].walls);
            }
        }
    }

    void GenerateMaze()
    {
        board = new Cell[size.x, size.y];
        for (int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                board[i,j] = new Cell();
                board[i,j].pos = new Vector2Int(i, j);
            }
        }

        Cell current = board[0,0];
        current.visited = true;

        Stack<Cell> dfs = new Stack<Cell>();
        dfs.Push(current);

        while(dfs.Count != 0)
        {
            current = dfs.Pop();
            Debug.Log(current.pos);
            List<Cell> neighbors = getNeighbors(current);
            if (neighbors.Count != 0)
            {
                dfs.Push(current);
                Cell nextCell = neighbors[Random.Range(0, neighbors.Count)];
                breakWall(current, nextCell);
                current = nextCell;
                current.visited = true;
                dfs.Push(current);
            }
        }
        GenerateHallways();
    }

    void breakWall(Cell current, Cell nextCell)
    {
        Vector2Int t;
        t = current.pos - nextCell.pos;

        if (t == Vector2Int.left)
        {
            current.walls[2] = true;
            nextCell.walls[3] = true;
        }
        else if (t == Vector2Int.right)
        {
            current.walls[3] = true;
            nextCell.walls[2] = true;
        }
        else if (t == Vector2Int.up)
        {
            current.walls[0] = true;
            nextCell.walls[1] = true;
        }
        else if (t == Vector2Int.down)
        {
            current.walls[1] = true;
            nextCell.walls[0] = true;
        }
        else
        {
            Debug.Log("breakWall: Problem.");
            Debug.Log("current: " + current.pos + " nextcell: " + nextCell.pos + " t = " + t);
        }
    }

    List<Cell> getNeighbors(Cell current)
    {
        List<Cell> neighbors = new List<Cell>();
        int x = current.pos.x;
        int y = current.pos.y;
        
        // East Neighbor
        if (x+1 < size.x && !board[x+1, y].visited)
        {
            neighbors.Add(board[x+1, y]);
        }

        // West Neighbor
        if (x-1 >= 0 && !board[x-1, y].visited)
        {
            neighbors.Add(board[x-1, y]);
        }

        // South Neighbor
        if (y-1 >= 0 && !board[x, y-1].visited)
        {
            neighbors.Add(board[x, y-1]);
        }

        // North Neighbor
        if (y+1 < size.y && !board[x, y+1].visited)
        {
            neighbors.Add(board[x, y+1]);
        }

        return neighbors;
    }
    
}
