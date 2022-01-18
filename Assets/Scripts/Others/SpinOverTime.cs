using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOverTime : MonoBehaviour
{
    public bool IsSpinning = true;
    public float DegreesPerSecond = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, DegreesPerSecond * Time.deltaTime);
    }
}
