using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private float length;
    private float width;
    private float weight;
    public float maxLength = 2;
    public float minLength = 1;
    public float maxWídth = 2;
    public float minWidth= 1;
    public float mass = 1;
    private string fishType;
    //Lower is better
    public float luck = 2;
    public override string ToString()
    {
        return $"Species: {fishType} Length: {length:0.##}m Width: {width:0.##}m Weight: {weight:0.##}kg";
    }
    // Start is called before the first frame update
    void Start()
    {
        fishType = transform.name.Substring(0,transform.name.Length - 7);
        length = generateNum(luck, minLength, maxLength);
        width = generateNum(luck, minWidth + length / 8 , maxWídth);
        weight = ((length / 0.0254f) * (width / 0.0254f) * (width / 0.0254f)) / mass;
        Debug.Log(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float generateNum(float pow, float min, float max)
    {
        float result = Random.Range(.1f, .99f);
        result = Mathf.Pow(result, pow);
        return Mathf.Pow(Random.Range(.1f, .99f), pow) * (max - min) + min;
    }
}
