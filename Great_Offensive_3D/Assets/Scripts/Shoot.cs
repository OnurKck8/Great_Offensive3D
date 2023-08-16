using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject point;
    public ParticleSystem fire;

    public void ShootFire()
    {

        Instantiate(bullet, point.transform.position, point.transform.rotation);
        fire.Play();

    }
}
