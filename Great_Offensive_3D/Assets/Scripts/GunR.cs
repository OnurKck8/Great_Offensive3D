using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunR : MonoBehaviour
{
    Animator myAnim;
    public int bullet;
    public int rBulletCount;

    public AudioSource fireSound;
    public AudioClip[] reloadsound;
    GameManager gm;
    void Start()
    {
        myAnim = this.gameObject.GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(bullet <= rBulletCount)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                myAnim.SetBool("R", true);
                bullet = rBulletCount;
                fireSound.clip=reloadsound[1];
                fireSound.Play();
                gm.money -= 50;
            }

            if(Input.GetMouseButtonDown(0))
            {
                myAnim.SetBool("R", false);
                fireSound.clip = reloadsound[0];
            }
        }
        

    }
}
