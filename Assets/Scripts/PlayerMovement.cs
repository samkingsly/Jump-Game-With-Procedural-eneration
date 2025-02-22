using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private GroundChecker groundCheck;
    [SerializeField] private GameObject Camera;

    private Rigidbody rb;

    private void OnEnable()
    {
        Camera.transform.SetParent(transform.GetChild(1));
        Camera.transform.localPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(0, 0, -1) * Speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(groundCheck.isGrounded)
            {
                rb.AddForce(Vector3.up * JumpForce);
            }
            else
            {
                rb.AddForce(Vector3.zero);
            }
        }
    }
}
