using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TurningMrSmith : MonoBehaviour
{
    // Start is called before the first frame update
    public Turn spinningSmith;
    public Detection smithSight;
    public PrankList list;
    public NavMeshAgent smith;
    public GameObject Player;
    public Interact playerinter;
    // Update is called once per frame
    void Update()
    {
        if(smithSight.awareness >= 10 && playerinter.GetHeld!=null)
        {
            spinningSmith.fallen = true;
            smith.SetDestination(Player.transform.position);
            smith.updateRotation = true;
        }
        if (spinningSmith.fallen)
        {
            for (int i = 0; i < list.PrankText.Length; i++)
            {
                if (list.PrankText[i].text == "Knock over Mr.Smith" && list.PrankText[i].color != Color.green)
                {
                    list.PrankText[i].color = Color.green;
                    list.pranksdone++;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && smithSight.awareness >=10)
        {
            //pick up the player and drag him back to spawn
            Debug.Log("You've been caught");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PickUP throwable))
        {
            if(collision.gameObject.TryGetComponent(out Rigidbody rb))
            {
                if(rb.velocity.x != 0 || rb.velocity.y != 0 || rb.velocity.z != 0)
                {
                    smith.enabled = false;
                    var teacher = smith.gameObject.transform;
                    var rot = teacher.eulerAngles;
                    rot.z = -90;
                    teacher.eulerAngles = rot;

                    for (int i = 0; i < list.PrankText.Length; i++)
                    {
                        if (list.PrankText[i].text == "Knock over Mr.Smith" && list.PrankText[i].color != Color.green)
                        {
                            list.PrankText[i].color = Color.green;
                            list.pranksdone++;
                        }
                    }
                    Destroy(this);
                }
            }
        }
    }
}
