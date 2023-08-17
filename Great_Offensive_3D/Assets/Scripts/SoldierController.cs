using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public float speed = 0;
    GameObject flag,target;
    public Animator myAnim;
    public bool isGameOver = false;
    void Start()
    {
        flag = GameObject.FindGameObjectWithTag("Flag");
        target = GameObject.FindGameObjectWithTag("Target");
    }
    void Update()
    {
        // transform.Translate(new Vector3(0, 0, speed));


        if (Vector3.Distance(transform.position, target.transform.position) > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0);
            if(isGameOver)
            {
                flag.transform.Translate(new Vector3(0, -0.1f, 0));
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Target")
        {
            myAnim.SetBool("Attack", true);
            myAnim.SetBool("Runner", false);
            isGameOver = true;
        }
        else
        {
            myAnim.SetBool("Runner", true);
            myAnim.SetBool("Attack", false);
            isGameOver = false;
        }
    }
}
