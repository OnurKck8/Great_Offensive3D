using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public ParticleSystem blood;
    void Update()
    {
        Destroy(gameObject, 1f);
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(3,0,0)*Time.deltaTime*speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy" || other.tag=="Rotate")
        {
            Destroy(other.gameObject,1f);
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
