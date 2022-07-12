using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private float length;
    private float width;
    private float weight;
    public int maxLength = 2;
    public int minLength = 1;
    public int maxWídth = 2;
    public int minWidth= 1;
    private string fishType;
    //Lower is better
    public int luck = 2;
    public override string ToString()
    {
        return $"Species: {fishType} Length: {length:0.##}m Width: {width:0.##}m Weight: {weight:0.##}kg";
    }
    // Start is called before the first frame update
    void Start()
    {
        fishType = transform.name.Substring(0,transform.name.Length - 7);
        length = generateNum(luck, minLength, maxLength);
        width = generateNum(luck, minWidth, maxWídth);
        weight = generateNum(luck, (int)(length * width), (int)(length * width + 1));
        Debug.Log(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float generateNum(int pow, int min, int max)
    {
        float result = Random.Range(.1f, .99f);
        result = Mathf.Pow(result, pow);
        return Mathf.Pow(Random.Range(.1f, .99f), pow) * (max - min) + min;
    }
}
