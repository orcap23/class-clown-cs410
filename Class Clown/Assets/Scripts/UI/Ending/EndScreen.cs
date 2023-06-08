using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Player;
public class EndScreen : MonoBehaviour
{
    public OpenPrankList pause;
    public GameObject EndingUI;
    public GameObject player;
    public bool ending;
    private void Start()
    {
        pause = GameObject.Find("Canvas").GetComponent<OpenPrankList>();
        EndingUI = GameObject.Find("EndScreen");
        EndingUI.SetActive(false);
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(Timer.timerTime == 0)
        {
            endgame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endgame();
        }
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void endgame()
    {
        Destroy(player.GetComponent<ThirdPersonController>());
        Destroy(player.GetComponent<ThirdPersonAim>());
        Destroy(player.GetComponent<PlayerInputs>());
        Destroy(player.GetComponent<PlayerInput>());
        pause.ToDoUI.SetActive(false);
        Destroy(pause);

        Time.timeScale = 0f;
        EndingUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
