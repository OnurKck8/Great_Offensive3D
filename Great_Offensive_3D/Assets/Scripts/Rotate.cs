using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float xRotation,yRotation;
    public float mouseSensivity = 100f;
    public GameObject character;

    void FixedUpdate()
    {


        //xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;

        //xRotation = Mathf.Clamp(xRotation, -132f, -45f);
        //transform.eulerAngles = new Vector3(80, -90, xRotation);


        float xMouse = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;
        float yMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;

        xRotation -= xMouse;
        xRotation = Mathf.Clamp(xRotation, -132f, -45f);

        yRotation += yMouse;
        yRotation = Mathf.Clamp(yRotation, 75f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, -90, xRotation);
        //character.transform.Rotate(Vector3.up * yMouse);

       

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
