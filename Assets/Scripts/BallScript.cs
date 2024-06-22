using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rigidbody;

    public float force = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float fx = Input.GetAxis("Horizontal") * Time.timeScale * force;
        float fz = Input.GetAxis("Vertical") * Time.timeScale * force;



        // rb.AddForce(fx, 0, fz); - за світовими координатами, незалежно від камери 
        // якщо потрібно обертати камеру, то слід використовувати її вектори 
        // forward тa right

        Vector3 camForward = Camera.main.transform.forward; 
        camForward.y = 0f;
        camForward = camForward.normalized;
        
        Vector3 moveDirection = fz * camForward + fx * Camera.main.transform.right;
        rigidbody.AddForce(moveDirection);
    }
}
