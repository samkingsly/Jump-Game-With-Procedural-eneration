using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public float pressDepth = 0.2f; 
    public float pressSpeed = 5f;   
    public float releaseSpeed = 5f;

    private Vector3 originalPosition;
    public bool ButtonPressed = false;
    public bool isPlayerAbove = false;

    public int LifeCount;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        LifeCount = GetComponentInParent<PlatformBehaviour>().LifeCount;
        if (isPlayerAbove)
        {
            ButtonPressed = true;
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition - new Vector3(0, pressDepth, 0), Time.deltaTime * pressSpeed);
        }
        else
        {
            ButtonPressed = false;
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * releaseSpeed);
        }
    }


}
