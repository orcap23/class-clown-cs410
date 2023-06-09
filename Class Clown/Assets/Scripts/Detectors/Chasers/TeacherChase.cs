using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TeacherChase : MonoBehaviour
{
    public bool chasing = false;
    public Detection detection;
    public NavMeshAgent snitch;
    public NavMeshAgent teacher;
    // Update is called once per frame
    void Update()
    {
        if(detection.awareness >= 10)
        {
            snitch.SetDestination(teacher.gameObject.transform.position);

        }
    }
}
