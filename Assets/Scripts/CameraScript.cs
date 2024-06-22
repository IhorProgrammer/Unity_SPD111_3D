using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private GameObject ball;
    private Vector3 offset; // зміщення камери відносно персонажу
    private Vector3 mAngles;

    private float sensitivityH = 2f;
    private float sensitivityV = 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.ball = GameObject.Find("Ball");
        this.offset = this.transform.position - ball.transform.position;
        mAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        mAngles.y += Input.GetAxis("Mouse X") * sensitivityH;
        mAngles.x -= Input.GetAxis("Mouse Y") * sensitivityV;


        if (mAngles.x > 75f) mAngles.x = 75f;  
        if (mAngles.x < 5f) mAngles.x = 5f;

        if (mAngles.y > 360) mAngles.y -= 360; 
        if (mAngles.y < 0) mAngles.y += 360;
    }

    private void LateUpdate()
    {
        // вплив на камеру краще робити в LateUpdate
        this.transform.position = (ball.transform.position) 
            + Quaternion.Euler( 0, mAngles.y, 0 )  * offset;
        this.transform.eulerAngles = mAngles;
    }
}
