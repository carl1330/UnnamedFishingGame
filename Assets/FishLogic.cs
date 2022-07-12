using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLogic : MonoBehaviour
{
    public struct Fish
    {
        public Fish(float weight, float radius, float length)
        {
            this.weight = weight;
            this.radius = radius;
            this.length = length;

        }
        float length;
        float weight;
        float radius;
        
        public override string ToString()
        {
            return $"Length: {length} Weight: {weight} Radius: {radius}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(generateFish());

    }

    // Update is called once per frame
    void Update()
    {



    }

    // Start is called before the first frame update


    Fish generateFish()
    {
    




        
        float lenght = GenerateNum(7,0.1f,10);
        float radius = GenerateNum(7,0.1f,5);
        float weight = radius * lenght;

        return new Fish(weight, radius, lenght);
    }

    float GenerateNum(int power, float min, float max)
    {
        float result = Random.Range(0.1f, 1.0f);
        


        result = Mathf.Pow(result, power);
        result += min;
        result *= max-min;
        return result;
    }

}
