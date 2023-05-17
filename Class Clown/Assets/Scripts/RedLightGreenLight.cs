using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightGreenLight : MonoBehaviour
{
    // Start is called before the first frame update
    bool turning = false;
    void Start()
    {
        StartCoroutine(Turn(180));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LerpTurn(float duration, float startyangle, float targetyangle)
    {
        float time = 0;
        turning = true;
        while (time < duration)
        {
            float yangle = Mathf.Lerp(startyangle, targetyangle, (time / duration));
            time += Time.deltaTime;
            Vector3 temp = new Vector3(transform.rotation.x, yangle, transform.rotation.z);
            transform.eulerAngles = temp;
            yield return null;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, targetyangle, transform.rotation.z);
        turning = false;
        yield return null;
    }
    IEnumerator Turn(float degree)
    {
        while (true)
        {
            float startangle = transform.eulerAngles.y;
            yield return StartCoroutine(LerpTurn(3, startangle, startangle+degree));
            yield return new WaitForSeconds(5);
            startangle = transform.eulerAngles.y;
            yield return StartCoroutine(LerpTurn(3, startangle, startangle-degree));
            yield return new WaitForSeconds(2);
        }

    }
}
