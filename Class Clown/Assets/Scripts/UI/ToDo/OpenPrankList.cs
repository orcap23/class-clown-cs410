using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using System;

public class OpenPrankList : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerInputs PlayerInput;
    public static bool ToDoOpen = false;
    public GameObject ToDoUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (ToDoOpen)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        ToDoUI.SetActive(true);
        Time.timeScale = 0f;
        ToDoOpen = true;
    }

    private void Resume()
    {
        ToDoUI.SetActive(false);
        Time.timeScale = 1f;
        ToDoOpen = false;
    }
}
