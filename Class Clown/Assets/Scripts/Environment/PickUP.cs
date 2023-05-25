using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    private Transform grabpoint;
    private Rigidbody rb;
    private GameObject Player;
    // check for object not moving found https://answers.unity.com/questions/739505/how-to-check-if-an-object-has-stopped-moving.html


    public void Grab(Transform point, GameObject Player)
    {
        this.Player = Player;
        this.grabpoint = point;

        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<Collider>(), true);
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

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        Physics.IgnoreCollision(Player.GetComponent<Collider>(), GetComponent<Collider>(), false);
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }
}
