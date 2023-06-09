using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlarmMessage : MonoBehaviour
{
    private TMP_Text message;
    public GameObject parent;
    private Image parentImage;
    private AudioSource mAudioSource;
    private bool started = false;
    [SerializeField] private bool alert = true;
    // Start is called before the first frame update

    void Start()
    {
        started = false;
        message = GetComponent<TMP_Text>();
        parentImage = parent.GetComponent<Image>();
        mAudioSource = GetComponent<AudioSource>();
        message.enabled = false;
        parentImage.enabled = false;
    }

    private void Update()
    {
        if(UnlockEscape.alarmFlash && !started && alert)
        {
            started = true;
            StartCoroutine(blinkDisplay());
        }
    }

    private IEnumerator blinkDisplay()
    {
        for (int i = 0; i < 7; i++)
        {
            message.enabled = true;
            parentImage.enabled = true;
            mAudioSource.Play();
            yield return new WaitForSeconds(.5f);
            message.enabled = false;
            parentImage.enabled = false;
            yield return new WaitForSeconds(.25f);
        }
    }
    public IEnumerator GetBlinkDisplay()
    {
        for (int i = 0; i < 4; i++)
        {
            message.enabled = true;
            parentImage.enabled = true;
            yield return new WaitForSeconds(.5f);
            message.enabled = false;
            parentImage.enabled = false;
            yield return new WaitForSeconds(.25f);
        }
    }
}
