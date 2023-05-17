using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private LayerMask pickupable;
    [SerializeField] private float pickupdist = 2f;
    [SerializeField] private Transform grabpoint;
    private Transform highlight;
    private bool holding = false;
    GameObject held;
    private void Update()
    {
        // raycast from player every frame its only one though so should be computationally trivial
        // outline selectable objects and allows user to interact with them
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit selectable, pickupdist, pickupable))
        {
            highlight = selectable.transform;
            Debug.Log(highlight.name);
            if (selectable.transform.CompareTag("Selectable"))
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (highlight.TryGetComponent(out PickUP PickUP))
                    {
                        PickUP.Grab(grabpoint, gameObject);
                        held = PickUP.gameObject;
                        holding = true;
                        Debug.Log("Grabbable");
                    }
                    else if (highlight.TryGetComponent(out Openable openable))
                    {
                        openable.open();
                    }

                }
            }
            else
            {
                highlight = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(holding && held != null)
            {
                Debug.Log("Throw");
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
