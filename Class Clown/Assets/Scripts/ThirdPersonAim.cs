using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Player;
public class ThirdPersonAim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCam;
    private PlayerInputs PlayerInput;
    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInputs>();

    }
    private void Update()
    {
        if (PlayerInput.aim)
        {
            aimCam.gameObject.SetActive(true);
        }
        else
        {
            aimCam.gameObject.SetActive(false);
        }
    }
}
