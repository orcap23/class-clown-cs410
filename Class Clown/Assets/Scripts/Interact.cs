using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private LayerMask pickupable;
    [SerializeField] private float pickupdist = 2f;
    [SerializeField] private Transform grabpoint;
    [SerializeField] private AudioSource pickupSound;
    [SerializeField] private AudioSource throwSound;

    private bool holding = false;
    GameObject held;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit hit, pickupdist, pickupable) && !holding){
                Debug.Log(hit.transform.name);
                if (hit.transform.TryGetComponent(out PickUP PickUP)) {
                    pickupSound.Play();
                    PickUP.Grab(grabpoint,gameObject);
                    held = PickUP.gameObject;
                    holding = true;
                    Debug.Log("Grabbable");
                }else if(hit.transform.TryGetComponent(out Openable openable)){
                    openable.open();
                }
            }
            else if(holding && held != null){
                holding = false;
                held.GetComponent<PickUP>().Drop();
                held = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(holding && held != null)
            {
                Debug.Log("Throw");
                throwSound.Play();
                holding = false;
                held.GetComponent<PickUP>().Throw(gameObject.transform);
                held = null;
            }
        }
        if (held != null)
        {
            held.transform.rotation = Quaternion.Lerp(held.transform.rotation,playerCam.rotation, 12*Time.deltaTime);
        }
    }
}
