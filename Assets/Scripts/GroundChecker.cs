using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        var x = other.gameObject.GetComponent<PlatformBehaviour>();
        var y = other.gameObject.GetComponent<ButtonBehaviour>();
        if (x != null )
        {
            if(x.LifeCount > 0)
            {
                isGrounded = true;
                player.transform.SetParent(other.transform);
            }
            
        }
        else if (y != null)
        {
            if (y.LifeCount > 0)
            {
                isGrounded = true;
                player.transform.SetParent(other.transform);
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Button")
        {
            var x = other.gameObject.GetComponent<ButtonBehaviour>();
            if (x != null)
            {
                x.isPlayerAbove = true;
            }
        }
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Button")
        {
            var x = other.gameObject.GetComponent<ButtonBehaviour>();
            if (x != null)
            {
                x.isPlayerAbove = false;
            }
        }
        isGrounded = false;
        player.transform.SetParent(null);
    }
}
