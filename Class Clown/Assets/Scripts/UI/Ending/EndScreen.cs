using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Player;
using TMPro;
public class EndScreen : MonoBehaviour
{
    public OpenPrankList pause;
    public GameObject EndingUI;
    public GameObject player;
    public TMP_Text scoretext;
    public TMP_Text speed;
    public TMP_Text timesdetected;
    public TMP_Text pranknum;
    public Score scorescript;
    public bool ending;
    private void Start()
    {
        pause = GameObject.Find("Canvas").GetComponent<OpenPrankList>();
        EndingUI = GameObject.Find("EndScreen");
        scorescript = EndingUI.GetComponent<Score>();
        scoretext = GameObject.Find("Score").GetComponent<TMP_Text>();
        timesdetected = GameObject.Find("Time Detected").GetComponent<TMP_Text>();
        speed = GameObject.Find("Speed").GetComponent<TMP_Text>();
        pranknum = GameObject.Find("Pranks Accomplished").GetComponent<TMP_Text>();
        EndingUI.SetActive(false);
        player = GameObject.Find("Player");


    }
    private void Update()
    {
        if(Timer.timerTime == 0)
        {
            endgame();
            Timer.timerTime = -1;
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

        scorescript.updateScore(scoretext,speed,pranknum,timesdetected);

        Cursor.lockState = CursorLockMode.Confined;
    }
}
