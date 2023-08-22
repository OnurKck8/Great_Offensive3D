using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public float speed = 0;
    GameObject flag,target;
    public Animator myAnim;
    public bool isGameOver = false;
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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.LookAt(target.transform);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0);
            transform.LookAt(target.transform);
            if (isGameOver)
            {
                flag.transform.Translate(new Vector3(0, -0.0085f, 0));
                gm.flagFill.fillAmount -= 0.00020f;
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
}
