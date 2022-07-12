using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private float length;
    private float width;
    private float weight;
    public override string ToString()
    {
        return $"Length: {length:0.##}m Width: {width:0.##}m Weight: {weight:0.##}kg";
    }
    // Start is called before the first frame update
    void Start()
    {
        length = generateNum(2,1,5);
        width = generateNum(2,1,2);
        weight = generateNum(2,(int)(length * width), (int)(length * width + 1));
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
