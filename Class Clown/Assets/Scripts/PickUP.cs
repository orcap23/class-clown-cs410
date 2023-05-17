using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private Transform grabpoint;
    private Rigidbody rb;
    private GameObject Player;
    // check for object not moving found https://answers.unity.com/questions/739505/how-to-check-if-an-object-has-stopped-moving.html
    private float noMovementThreshhold = 0.0001f;
    private const int nomoveframe = 5;
    private bool isMoving;

    Vector3[] prev = new Vector3[nomoveframe];
    public bool IsMoving
    {
        get { return isMoving; }
    }
    void Awake()
    {
        //For good measure, set the previous locations
        for (int i = 0; i < prev.Length; i++)
        {
            prev[i] = Vector3.zero;
        }
    }
    public void Grab(Transform point, GameObject Player)
    {
        this.Player = Player;
        this.grabpoint = point;

        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    public void Drop()
    {
        grabpoint = null;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    public void Throw(Transform Player)
    {
        grabpoint = null;
        rb.isKinematic = false;
        rb.useGravity = true;
        Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<Collider>(), true);
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        StartCoroutine(Wait());

    }
    private void FixedUpdate()
    {
        if(grabpoint != null)
        {
            float lerpspeed = 20f;
            Vector3 newpos  = Vector3.Lerp(transform.position, grabpoint.position, Time.deltaTime * lerpspeed);
            rb.MovePosition(newpos);
        }

    }
    private void Update()
    {
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
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<Collider>(), false);
    }
}
