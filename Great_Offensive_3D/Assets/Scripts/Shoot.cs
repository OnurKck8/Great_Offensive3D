using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    public GameObject point;
    public ParticleSystem fire;
    GunR gunr;
    public Animator pasaAni;

    [Header("Bullet")]
    public TextMeshProUGUI bulletCount;
    public GameObject reload;
    void Update()
    {
        gunr = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunR>();
        bulletCount.text = gunr.bullet.ToString();

        if (gunr.bullet != 0)
        {
            reload.SetActive(false);
        }
        else
        {
            bulletCount.text = "0";
            reload.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(gunr.bullet!=0)
            {
                Instantiate(bullet, point.transform.position, point.transform.rotation);
                fire.Play();
                gunr.bullet--;
                gunr.fireSound.Play();
                pasaAni.SetBool("Fire", true);  
            }

           
            
        }
        else
        {
            pasaAni.SetBool("Fire", false);
        }
        
    }
}
