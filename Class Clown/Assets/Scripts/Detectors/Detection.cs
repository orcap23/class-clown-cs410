using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Detection : MonoBehaviour
{
    // followed this guide 
    // https://github.com/Comp3interactive/FieldOfView
    // and edited to draw fov cone
    public Renderer Detector;
    public Renderer awarenessgauge;
    public Color start;
    public Color end;
    public int MatNum;
    public Material detected;
    public Material fovmat;
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    private bool firstDetection = true;
    [Range(0,20)] public float awareness;
    private Material undetected;
    private Material[] matlist;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        undetected = Detector.materials[MatNum];
        StartCoroutine(FOVRoutine());
        StartCoroutine(Awareness());
    }
    private void Update()
    {
        matlist = Detector.materials;
        if (awareness > 10)
        {
            matlist[MatNum] = detected;
            Detector.materials = matlist;
            if (firstDetection)
            {
                Score.num_detected++;
                firstDetection = false;
            }
        }
        else
        {
            matlist[MatNum] = undetected;
            Detector.materials = matlist;
        }

    }
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private IEnumerator Awareness() 
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            if(awareness <= 0)
            {
                awarenessgauge.enabled = false;
            }
            else
            {
                awarenessgauge.enabled = true;
            }
            if (canSeePlayer && awareness < 20)
            {
                awareness++;
                awarenessgauge.material.SetColor("_Color",
                                    Color.Lerp(awarenessgauge.material.color, end, (awareness / 20)));
            }
            else if (awareness > 0)
            {
                awareness--;
                awarenessgauge.material.SetColor("_Color",
                    Color.Lerp(awarenessgauge.material.color, start, (awareness / 20)));
            }
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        // checks if player is in the list of collisions on the target layermask from a overlap sphere
        if (rangeChecks.Length != 0)
        {
            // first one it sees
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {

                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}