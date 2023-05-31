using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2Int startpos;
    Cell[,] board;
    public GameObject Hallway;
    public GameObject TriggerRoom;
    public GameObject StartRoom;
    public GameObject EndRoom;
    public List<Cell> EventRooms; // 0: Gym, 1: Office, 2: cafe
    public Vector2Int offset;
    public int nTriggers = 2;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze();
    }


    public class Cell
    {
        public bool[] walls = new bool[4];
        public bool visited;
        public Vector2Int pos;
    }

    void GenerateSchool()
    {
        List<Cell> visited = new List<Cell>();


        // Generate rooms using maze data structure
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell current = board[i, j];
                if (current.visited)
                {
                    visited.Add(current);
                    var newHallway = Instantiate(Hallway, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                    newHallway.UpdateRoom(current.walls);
                    newHallway.name += " " + i + "-" + j;
                }

            }
        }

        // Generate event-rooms
        EventRooms = new List<Cell>();
        EventRooms.Add(visited[(int)Floor(.2 * visited.Count - 1)]);
        //EventRooms.Add(visited[(int)Floor(.5 * visited.Count - 1)]);
        EventRooms.Add(visited[(int)Floor(.8 * visited.Count - 1)]);
        int idx = 3;
        foreach (Cell room in EventRooms)
        {
            int x = room.pos.x;
            int y = room.pos.y;
            var instEvent = Instantiate(TriggerRoom, new Vector3(x * offset.x, 0, -y * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
            instEvent.UpdateEventRoom(room.walls, idx);
            if (idx == 3)
            {
                var gym_hallway = GameObject.Find("Gym_Hallway").GetComponent<RoomBehavior>();
                gym_hallway.SetTpCoords(new Vector3(x * offset.x, 1.3f, -y * offset.y));
            }
            if (idx == 4)
            {

            }
            idx++;
        }

        // Instantiate start/end rooms
        var instStart = Instantiate(StartRoom, new Vector3(0, 0, 0), Quaternion.identity, transform).GetComponent<RoomBehavior>();
        var instEnd = Instantiate(EndRoom, new Vector3((size.x - 1) * offset.x, 0, -(size.y - 1) * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
        instStart.UpdateRoom(board[0, 0].walls);
        instEnd.UpdateRoom(board[size.x - 1, size.y - 1].walls);
    }

    void GenerateMaze()
    {
        board = new Cell[size.x, size.y];
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board[i, j] = new Cell();
                board[i, j].pos = new Vector2Int(i, j);
            }
        }

        Cell current = board[startpos.x, startpos.y];
        current.visited = true;

        Stack<Cell> dfs = new Stack<Cell>();
        dfs.Push(current);

        while (dfs.Count != 0)
        {
            current = dfs.Pop();
            if (current == board[size.x - 1, size.y - 1])
            {
                break;
            }
            //Debug.Log(current.pos);
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
        GenerateSchool();
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
        if (x + 1 < size.x && !board[x + 1, y].visited)
        {
            neighbors.Add(board[x + 1, y]);
        }

        // West Neighbor
        if (x - 1 >= 0 && !board[x - 1, y].visited)
        {
            neighbors.Add(board[x - 1, y]);
        }

        // South Neighbor
        if (y - 1 >= 0 && !board[x, y - 1].visited)
        {
            neighbors.Add(board[x, y - 1]);
        }

        // North Neighbor
        if (y + 1 < size.y && !board[x, y + 1].visited)
        {
            neighbors.Add(board[x, y + 1]);
        }

        return neighbors;
    }

}