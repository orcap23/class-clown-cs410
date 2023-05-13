using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private Transform grabpoint;
    private Rigidbody rb;
    public void Grab(Transform point, GameObject Player)
    {
        this.grabpoint = point;
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Player.GetComponent<Collider>());
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
        rb.AddForce(Player.forward * 10, ForceMode.Impulse);
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
}
