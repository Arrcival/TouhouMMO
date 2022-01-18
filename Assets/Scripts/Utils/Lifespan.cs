using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float LifeSpan = 30f;

    float currentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= LifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
