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
    public bool setRot = false;
    public Vector3 tp_rot;

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            walls[i].SetActive(!status[i]);
        }
    }

    public void UpdateEventRoom(bool[] status, int RoomID)
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
        if (RoomID == 0)
        {
            tp_coords = new Vector3(30f, 1.3f, 34f);
            tp_rot = new Vector3(0, 270, 0);
            setRot = true;
        }
        if (RoomID == 1)
        {
            tp_coords = new Vector3(-6f, 1.3f, 52f);
            tp_rot = new Vector3(0, 270, 0);
            setRot = true;
        }
    }

    public void SetPos(Vector3 NewPos)
    {
        tp_coords = NewPos;
    }
}
