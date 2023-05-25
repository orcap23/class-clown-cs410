using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    // Start is called before the first frame update
    public Interact player;
    void Start()
    {
        StartCoroutine(TurnAround(180));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Caught");
        }
    }

    IEnumerator LerpTurn(float duration, float startyangle, float targetyangle)
    {
        float time = 0;
        while (time < duration)
        {
            float yangle = Mathf.Lerp(startyangle, targetyangle, (time / duration));
            time += Time.deltaTime;
            Vector3 temp = new Vector3(transform.rotation.x, yangle, transform.rotation.z);
            transform.eulerAngles = temp;
            yield return null;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, targetyangle, transform.rotation.z);
        yield return null;
    }
    IEnumerator TurnAround(float degree)
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
