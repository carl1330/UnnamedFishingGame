using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFishing : MonoBehaviour
{
    private IEnumerator coroutine;


    bool isFishing;
    bool isCasting;
    float balanceIndex;
    float power;
    const float max=10;
    const float min=0.1f;
    bool chargeCast;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndPrint(0.01f);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            if(isCasting==false)
            {

                isCasting = true;
              
                power = 0;
                StartCoroutine(WaitAndPrint(0.005f));
            }

        }
        if(Input.GetMouseButtonUp(0))
        {
            isCasting = false;
            //StopCoroutine(StartCoroutine(WaitAndPrint(0.01f)));

        }
    }

    void fishingGame()
    {
        while(isFishing)
        {



        }
    }

  

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (isCasting)
        {
            if(power>=10f)
            {
                chargeCast = false;

            }
            else if(power<=0.0f)
            {
                chargeCast = true;
            }
            if(chargeCast)
            {
                power += 0.1f;
            }
            else if(!chargeCast)
            {
                power -= 0.1f;
            }
         
                yield return new WaitForSeconds(waitTime);
                print("Power: " + power);
            
          

            
        
        }
    }
}
