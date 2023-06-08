using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSound : MonoBehaviour
{
    private GameObject soundObj;
    private AudioSource mAudioSource;
    public string SoundName;
    void Start()
    {
        soundObj = GameObject.Find(SoundName);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        soundObj.TryGetComponent(out AudioSource src);
        src.Play();
    }
}
