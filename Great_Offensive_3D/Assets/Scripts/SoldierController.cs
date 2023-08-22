using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public float speed = 0;
    GameObject flag,target;
    public Animator myAnim;
    public bool isGameOver = false;
    bool enemyTag = false;
    GameManager gm;
    void Start()
    {
        flag = GameObject.FindGameObjectWithTag("Flag");
        target = GameObject.FindGameObjectWithTag("Target");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {

        if (Vector3.Distance(transform.position, target.transform.position) > 0.85f)
        {
            if(enemyTag == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                transform.LookAt(target.transform);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0);
                transform.LookAt(target.transform);
            }
        }
        else
        {
            if(enemyTag==true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0);
                transform.LookAt(target.transform);
            }
           
            if (isGameOver)
            {
                flag.transform.Translate(new Vector3(0, -0.0085f, 0));
                gm.flagFill.fillAmount -= 0.000185f;
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

        if(other.tag=="Fire")
        {
            myAnim.SetBool("Runner", false);
            myAnim.SetBool("Attack", false);
            myAnim.SetBool("Die", true);
            isGameOver = false;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.85f)
            {
                enemyTag = true;
            }
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.85f)
            {
                enemyTag = false;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.85f)
            {
                enemyTag = false;
            }
        }
    }
 

   
}
