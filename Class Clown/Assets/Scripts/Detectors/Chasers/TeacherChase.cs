using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeacherChase : MonoBehaviour
{
    public bool chasing = false;
    public int recalculateTrys = 3;
    public int tryCounter = 0;
    public Detection detection;
    public Animator snitchanimator;
    public NavMeshAgent snitch;
    public NavMeshAgent SelectedTeacher;
    public GameObject[] teachers;
    public GameObject Player;
    public NavMeshPath[] paths;
    bool alerted = false;
    int teacherindex = 0;
    Polyperfect.People.People_WanderScript wander;
    // Update is called once per frame
    private void Start()
    {
        snitch = GetComponent<NavMeshAgent>();  
        teachers = GameObject.FindGameObjectsWithTag("Teacher Hallway");
        paths = new NavMeshPath[teachers.Length];
        for(int i = 0; i < teachers.Length; i++)
        {
            paths[i] = new NavMeshPath();
        }
        wander = GetComponent<Polyperfect.People.People_WanderScript>();
    }
    void Update()
    {
        if(detection.awareness >= 10)
        {
            wander.enabled = false;
            chasing = true;
        }

        if (!chasing)
        {
            wander.enabled = true;
        }
        else 
        {
            if (recalculateTrys > tryCounter)
            {
                float min = float.MaxValue;
                int i = 0;
                foreach (GameObject teacher in teachers)
                {
                    //Debug.Log("Teacher position" + teacher.transform.position);
                    //Debug.Log("Snitch position" + snitch.gameObject.transform.position);
                    NavMesh.CalculatePath(snitch.gameObject.transform.position,
                        teacher.transform.position,
                        NavMesh.GetAreaFromName("Walkable"),
                        paths[i]);
                }
                i = 0;
                foreach (NavMeshPath path in paths)
                {
                    float a = PathLength(path,teachers[i].transform.position);
                    //Debug.Log("current path length " + a);
                    //Debug.Log("min path length " + min);
                    if (a <= min)
                    {
                        min = a;
                        teacherindex = i;
                    }
                    i++;
                    // Debug.Log("teacher index" + teacherindex);
                }
                snitch.SetDestination(teachers[teacherindex].transform.position - Vector3.right);
                SelectedTeacher = teachers[teacherindex].GetComponent<NavMeshAgent>();
                snitch.speed = 4;
                snitchanimator.SetBool("isRunning", true);
                snitchanimator.SetBool("isWalking", false);
                snitchanimator.SetBool("isTexting", false);
                tryCounter++;
            }
            if (snitch.remainingDistance < 1f){
                chasing = false;
                alerted = true;
                tryCounter = 0;
            }
        }
        if (SelectedTeacher != null && alerted)
        {
            SelectedTeacher.gameObject.GetComponent<Polyperfect.People.People_WanderScript>().enabled = false;
            SelectedTeacher.SetDestination(Player.transform.position);
            if (SelectedTeacher.remainingDistance < 1f)
            {
                SelectedTeacher.gameObject.GetComponent<Polyperfect.People.People_WanderScript>().enabled = true;
                alerted = false;
            }
        }
    }
    float PathLength(NavMeshPath path, Vector3 targetPosition)
    {
        // https://www.reddit.com/r/Unity3D/comments/2zfaeu/grabbing_distances_on_navmesh/
        // Create an array of points which is the length of the number of corners in the path + 2.
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        // The first point is the enemy's position.
        allWayPoints[0] = transform.position;

        // The last point is the target position.
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        // The points inbetween are the corners of the path.
        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        // Create a float to store the path length that is by default 0.
        float pathLength = 0;

        // Increment the path length by an amount equal to the distance between each waypoint and the next.
        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    }
}
