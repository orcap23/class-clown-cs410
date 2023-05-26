using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
    // 0 : North, 1 : South, 2 : East, 3 : West
    public GameObject[] walls;
    public GameObject[] triggerDoors;

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            walls[i].SetActive(!status[i]);
        }
    }

    public void UpdateEventRoom(bool[] status)
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
    }
}
