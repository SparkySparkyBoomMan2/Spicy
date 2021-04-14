using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class relocateTargetConst : MonoBehaviour
{
    Transform target;

    private IEnumerator targetSubR;

    float waitTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        targetSubR = NewTargetPoint();
        StartCoroutine(targetSubR);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NewTargetPoint()
    {
        while (true)
        {
            target.position = new Vector2(Random.Range(-4f, 22f), Random.Range(-7f, 13f));
            yield return new WaitForSeconds(waitTime);
        }

    }
}
