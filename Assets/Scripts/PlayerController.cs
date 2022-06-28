using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float firstPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastFishingRod();
    }

    void CastFishingRod() {

        float timePressed;
        if(Input.GetKeyDown("space")) {
            print("Cast fishing rod");
            firstPress = Time.time;
        }
        else if(Input.GetKeyUp("space")) {
            print("Finished casting rod");
            timePressed = Time.time - firstPress;
            print("time held: " + timePressed);
        }
    }
}
