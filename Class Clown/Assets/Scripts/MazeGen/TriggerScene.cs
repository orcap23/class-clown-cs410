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
            SceneManager.LoadScene(components.levelIndex);
            Debug.Log(components.levelIndex);
        }
            
    }
}
