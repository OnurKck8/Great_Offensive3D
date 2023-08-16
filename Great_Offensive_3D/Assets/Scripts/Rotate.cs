using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float xRotation;
    public float mouseSensivity = 100f;
    public GameObject character;

    void FixedUpdate()
    {

        if(Input.GetMouseButton(0))
        {
            xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;
            xRotation = Mathf.Clamp(xRotation, -132f, -45f);
            transform.eulerAngles = new Vector3(80, -90, xRotation);
        }
        


    }

    void Update()
    {


        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.right * 1000f, Color.red);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        //    {
                //if (hit.collider.gameObject.tag == "Enemy")
                //{
                //    Destroy(hit.collider.gameObject);
                //}
        //    }

        //}
    }


}
