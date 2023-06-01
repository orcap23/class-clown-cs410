using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScene : MonoBehaviour
{
    public GameObject room;
    void OnTriggerEnter(Collider other)
    {
        var components = room.GetComponent<RoomBehavior>();
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = components.tp_coords;
            if (components.setRot)
            {
                other.gameObject.transform.rotation = Quaternion.Euler(components.tp_rot);
            }
        }
    }
}
