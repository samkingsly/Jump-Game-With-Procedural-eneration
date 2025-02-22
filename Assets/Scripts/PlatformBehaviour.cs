using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class PlatformBehaviour : MonoBehaviour
{
    public int LifeCount;
    public int InitDirection;
    public float Speed;

    [SerializeField] private TextMeshProUGUI LifeCountText;

    void Start()
    {
        LifeCountText.text = LifeCount.ToString();
        if (transform.tag == "moveWithButton")
        {
            StartCoroutine("moveWithButton");
        }
        else if (transform.tag == "moveHorizontal")
        {
            StartCoroutine("MoveHorizontal");
        }
        else if (transform.tag == "moveVertical")
        {
            StartCoroutine("MoveVertical");
        }
    }

    void Update()
    {

    }

    IEnumerator moveWithButton()
    {
        Debug.Log("Started");
        if (transform.GetChild(0) != null)
        {
            Vector3 initPos = transform.position;
            GameObject button = transform.GetChild(0).gameObject;
            int direction = InitDirection;
            while (true)
            {

                if (button.GetComponent<ButtonBehaviour>().ButtonPressed == true)
                {
                    if (Vector3.Distance(initPos, transform.position) >= 10)
                    {
                        initPos = transform.position;
                        direction *= -1;
                    }

                    transform.Translate(new Vector3(0, 0, 1) * direction * Speed * Time.deltaTime);
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator MoveVertical()
    {
        Vector3 initPos = transform.position;
        int direction = InitDirection;
        while (true)
        {
            if (Vector3.Distance(initPos, transform.position) >= 10)
            {
                initPos = transform.position;
                direction *= -1;
            }

            transform.Translate(new Vector3(0, 1, 0) * direction * Speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }


    IEnumerator MoveHorizontal()
    {
        Vector3 initPos = transform.position;
        int direction = InitDirection;
        while (true)
        {
            if (Vector3.Distance(initPos, transform.position) >= 10)
            {
                initPos = transform.position;
                direction *= -1;
            }

            transform.Translate(new Vector3(0, 0, 1) * direction * Speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            LifeCount--;
            LifeCountText.text = LifeCount.ToString();
            CheckLife(collider);
        }
        
    }

    void CheckLife(Collider player)
    {
        if (LifeCount == 0)
        {
            player.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
