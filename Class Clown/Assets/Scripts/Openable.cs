using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    [SerializeField] private bool isopen = false;
    public Vector3 targetangle;
    private Vector3 startangle;
    // funny mutex lock but not really
    private bool opening = false;
    public void open()
    {
        startangle = transform.eulerAngles;
        targetangle = startangle;
        if (!isopen)
        {
            targetangle.y = startangle.y + 90;
            if (!opening)
            {
                StartCoroutine(LerpDoor(1f, startangle.y, targetangle.y));
                opening = true;
                isopen = true;
            }
        }
        else
        {
            targetangle.y = startangle.y - 90;
            if (!opening)
            {
                StartCoroutine(LerpDoor(1f, startangle.y, targetangle.y));
                opening = true;
                isopen = false;
            }
        }
    }
    IEnumerator LerpDoor(float duration, float startyangle,float targetyangle)
    {
        float time = 0;
        opening = true;
        while(time < duration)
        {
            float yangle = Mathf.Lerp(startyangle,targetyangle,(time/duration));
            time += Time.deltaTime;
            Vector3 temp = new Vector3(transform.rotation.x, yangle, transform.rotation.z);
            transform.eulerAngles = temp;
            yield return null;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, targetyangle, transform.rotation.z);
        opening = false;
        yield return null;
    }
}
