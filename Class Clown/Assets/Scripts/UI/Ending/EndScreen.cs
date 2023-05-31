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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
