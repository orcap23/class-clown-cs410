using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TurningMrSmith : MonoBehaviour
{
    // Start is called before the first frame update
    public Turn spinningSmith;
    public Detection smithsight;
    public PrankList list;
    public NavMeshAgent smith;
    public GameObject Player;
    public Interact playerinter;
    // Update is called once per frame
    void Update()
    {
        if(smithsight.awareness >= 10 && playerinter.GetHeld!=null)
        {
            spinningSmith.fallen = true;
            smith.SetDestination(Player.transform.position);
            smith.updateRotation = false;
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
        if (other.CompareTag("Player") && smithsight.awareness >=10)
        {
            Debug.Log("You've been caught");
        }
    }
}
