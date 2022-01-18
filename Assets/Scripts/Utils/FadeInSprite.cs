using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeInSprite : MonoBehaviour
{

    public float Duration = 0.3f;

    public float Lifespan = 0f;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetOpacityTo(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Lifespan >= Duration)
        {
            SetOpacityTo(1f);
            // Remove script
        }

        SetOpacityTo(Lifespan / Duration);

        Lifespan += Time.deltaTime;



    }

    void SetOpacityTo(float value)
    {
        Color currentCol = sr.color;
        currentCol.a = value;
        sr.color = currentCol;
    }
}
