using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rangespan : MonoBehaviour
{
    Rigidbody2D rb;
    public float MaxRange = 3f;

    float rangedone = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rangedone += rb.velocity.magnitude * Time.deltaTime;
        if (rangedone >= MaxRange)
            Destroy(gameObject);
    }
}
