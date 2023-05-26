using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // check for object not moving found https://answers.unity.com/questions/739505/how-to-check-if-an-object-has-stopped-moving.html
    [SerializeField] private Transform playerCam;
    [SerializeField] private LayerMask pickupable;
    [SerializeField] private float pickupdist = 2f;
    [SerializeField] private Transform grabpoint;
    [SerializeField] private AudioSource pickupSound;
    [SerializeField] private AudioSource throwSound;
    private float noMovementThreshhold = 0.0001f;
    private const int nomoveframe = 5;
    private bool isMoving;

    Vector3[] prev = new Vector3[nomoveframe];
    public bool IsMoving
    {
        get { return isMoving; }
    }

    private Transform highlight;
    private bool holding = false;
    private GameObject held;
    public GameObject getHeld
    {
        get { return held;}
    }
    void Awake()
    {
        //For good measure, set the previous locations
        for (int i = 0; i < prev.Length; i++)
        {
            prev[i] = Vector3.zero;
        }
    }
    private void Update()
    {
        // raycast from player every frame its only one though so should be computationally trivial
        // outline selectable objects and allows user to interact with them
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        //Store the newest vector at the end of the list of vectors
        for (int i = 0; i < prev.Length - 1; i++)
        {
            prev[i] = prev[i + 1];
        }
        prev[prev.Length - 1] = transform.position;

        //Check the distances between the points in your previous locations
        //If for the past several updates, there are no movements smaller than the threshold,
        //you can most likely assume that the object is not moving
        for (int i = 0; i < prev.Length - 1; i++)
        {
            if (Vector3.Distance(prev[i], prev[i + 1]) >= noMovementThreshhold)
            {
                //The minimum movement has been detected between frames
                isMoving = true;
                break;
            }
            else
            {
                isMoving = false;
            }
        }
        if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit selectable, pickupdist, pickupable))
        {
            highlight = selectable.transform;
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
                        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), held.GetComponent<Collider>());
                        holding = true;
                        pickupSound.Play();
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
                throwSound.Play();
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