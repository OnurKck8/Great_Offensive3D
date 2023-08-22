using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 0;
    public int bossHealth;
    GameObject flag, target;
    public Animator myAnim;
    public bool isGameOver = false;
    GameManager gm;
    Animator pasa;
    void Start()
    {
        flag = GameObject.FindGameObjectWithTag("Flag");
        target = GameObject.FindGameObjectWithTag("Target");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pasa = GameObject.Find("Pasa").GetComponent<Animator>();
        bossHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, -90, 0);

        if (Vector3.Distance(transform.position, target.transform.position) > 0.55f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.LookAt(target.transform);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0);
            if (isGameOver)
            {
                flag.transform.Translate(new Vector3(0, -0.0085f, 0));
                gm.flagFill.fillAmount -= 0.00020f;
            }
        }

        if(bossHealth<=0)
        {
           
            pasa.SetBool("Victory", true);
            StartCoroutine(WaitGameOver());
        }
    }

    IEnumerator WaitGameOver()
    {
        myAnim.SetBool("Dead", true);
        myAnim.SetBool("Attack", false);
        myAnim.SetBool("Runner", false);
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
        gm.isBossDestroy = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
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
            bossHealth -= 1;
        }
    }
}
