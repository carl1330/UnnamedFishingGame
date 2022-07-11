using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingWindow : MonoBehaviour
{
    public RenderTexture test;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject main = GameObject.Find("Main Camera");
        GameObject canvas = GameObject.Find("TestCanvas");
        cam.targetTexture = test;
        canvas.transform.position = new Vector3(main.transform.position.x + 2, main.transform.position.y - 2.5f, 0);   

    }
}
