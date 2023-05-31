using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomBehavior : MonoBehaviour
{
    // 0 : North, 1 : South, 2 : East, 3 : West
    public GameObject[] walls;
    public GameObject[] triggerDoors;
    public Vector3 tp_coords;

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            walls[i].SetActive(!status[i]);
        }
    }

    public void UpdateEventRoom(bool[] status, int index)
    {
        List<int> active = new List<int>();
        for (int i = 0; i < status.Length; i++)
        {
            walls[i].SetActive(!status[i]);
            triggerDoors[i].SetActive(false);
            if (!status[i])
            {
                active.Add(i);
            }
        }
        triggerDoors[active[Random.Range(0, active.Count)]].SetActive(true);
        if (index == 3)
        {
            tp_coords = new Vector3(30, 1.3f, 40);
        }
        if (index == 4)
        {
            tp_coords = new Vector3(-5, 1.3f, 59);
        }
    }

    public void SetTpCoords(Vector3 newcoords)
    {
        tp_coords = newcoords;
    }
}
