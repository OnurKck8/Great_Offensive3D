using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public ParticleSystem blood;
    GameManager gm;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Area").GetComponent<GameManager>();
    }
    void Update()
    {
        Destroy(gameObject, 2.25f);
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(3,0,0)*Time.deltaTime*speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            Destroy(other.gameObject,1f);
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            gm.money += 100;
        }
    }
}
