using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
    Image powerBar;
    GameObject powerbar;
    // Start is called before the first frame update
    void Start()
    {
        
        powerBar = GameObject.Find("bar").GetComponent<Image>();
        coroutine = WaitAndPrint(0.01f);
        powerbar = GameObject.Find("PowerBar");
        powerbar.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();

            if(isCasting==false)
            {
                powerbar.SetActive(true);
                isCasting = true;
              
                power = 0;
                StartCoroutine(WaitAndPrint(0.005f));
            }

        }
        if(Input.GetMouseButtonUp(0))
        {
            
            isCasting = false;
            StartCoroutine(Delay(2.0f));
           
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
            powerBar.fillAmount = power * 0.1f;
                print("Power: " + power);
            
          

            
        
        }
    }
    IEnumerator Delay(float time)
    {
        

        yield return new WaitForSeconds(time);
        powerbar.SetActive(false);
        // Code to execute after the delay
    }
}
