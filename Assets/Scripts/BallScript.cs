using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rigidbody;

    public float force = 2f;

    [SerializeField]
    private Material daySkybox;
    [SerializeField]
    private Material nightSkybox;
    [SerializeField]
    private Light mainLight;
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

        if( Input.GetKeyDown(KeyCode.N) )
        {
            if( RenderSettings.skybox == daySkybox )
            {
                RenderSettings.skybox = nightSkybox;
                RenderSettings.skybox.SetFloat("_Exposure", 0.1f);

                RenderSettings.ambientIntensity = 0f;
                mainLight.intensity = 0f;
            }
            else
            {
                RenderSettings.skybox = daySkybox;
                RenderSettings.skybox.SetFloat("_Exposure", 1f);
                mainLight.intensity = 1f;
                RenderSettings.ambientIntensity = 1f;

            }
        }
    }
}
