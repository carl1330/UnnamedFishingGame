using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject FishingRod;
    Rigidbody2D RB;
    float firstPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChargePower();
        
    }

    void ChargePower() {

        float timePressed;
        if(Input.GetKeyDown("space")) {
            firstPress = Time.time;
        }
        if (Input.GetKeyUp("space"))
        {
            timePressed = Time.time - firstPress;
            CastFishingRod(timePressed);
        }
    }

    void CastFishingRod(float t)
    {
        //Throw
        float power = 5 * t;

        Vector2 Force = new Vector2(power, power);
        FishingRod.GetComponent<Rigidbody2D>().AddForce(Force, ForceMode2D.Impulse);
    }

}
