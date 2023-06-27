using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    Material mat;
    float distance;
    private float counter = 0;
    [Range(0f, 1f)]
    public float speed = 0.2f;
    void Start()
    {
        mat = GetComponent<Renderer>().material;

    }
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 3)
        {
            speed += 0.05f;
            counter = 0;
        }
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
