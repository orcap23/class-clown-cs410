using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassRoomTeleport : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
            Debug.Log("Warp!");
        }
    }
}
