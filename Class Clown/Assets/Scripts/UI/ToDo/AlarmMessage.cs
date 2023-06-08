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
    // Start is called before the first frame update

    void Start()
    {
        message = GetComponent<TMP_Text>();
        parentImage = parent.GetComponent<Image>();
        message.enabled = false;
        parentImage.enabled = false;
    }

    public void DisplayMessage()
    {  
        StartCoroutine(blinkDisplay());
    }

    private IEnumerator blinkDisplay()
    {
        for (int i = 0; i < 3; i++)
        {
            message.enabled = true;
            parentImage.enabled = true;
            yield return new WaitForSeconds(2);
            message.enabled = false;
            parentImage.enabled = false;
            yield return new WaitForSeconds(1);
            Debug.Log($"loop {i}");
        }
    }
}
