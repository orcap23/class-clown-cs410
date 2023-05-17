using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
public class ThirdPersonAim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCam;
    private StarterAssetsInputs starterAssetsInputs;
    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();

    }
    private void Update()
    {
        if (starterAssetsInputs.aim)
        {
            aimCam.gameObject.SetActive(true);
        }
        else
        {
            aimCam.gameObject.SetActive(false);
        }
    }
}
