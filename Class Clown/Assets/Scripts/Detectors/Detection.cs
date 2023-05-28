using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Detection : MonoBehaviour
{
    // followed this guide 
    // https://github.com/Comp3interactive/FieldOfView
    // and edited to draw fov cone
    public MeshRenderer Detector;
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
    private Material undetected;
    private PlayerInputs PlayerInput;
    private Material[] matlist;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        undetected = Detector.materials[MatNum];
        PlayerInput = playerRef.GetComponent<PlayerInputs>();
        StartCoroutine(FOVRoutine());
    }
    private void Update()
    {
        matlist = Detector.materials;
        if (canSeePlayer)
        {
            matlist[MatNum] = detected;
            Detector.materials = matlist;
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
            if (PlayerInput.crouch)
            {
                DrawFOV();
            }
            else
            {
                // clear fov
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
    private void DrawFOV()
    {

    }
}