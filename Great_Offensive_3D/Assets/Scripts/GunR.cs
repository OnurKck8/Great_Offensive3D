using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunR : MonoBehaviour
{
    Animator myAnim;
    public int bullet;
    public int rBulletCount;
    void Start()
    {
        myAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bullet==0)
        {
            myAnim.SetBool("R", true);
            bullet = rBulletCount;
        }
        else
        {
            myAnim.SetBool("R", false);
        }
    }
}
