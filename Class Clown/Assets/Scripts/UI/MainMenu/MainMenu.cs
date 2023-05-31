using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameClassroom() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayGameHallways()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayGameGym()
    {
        SceneManager.LoadScene(3);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGame() {
        Application.Quit();
    }
}
