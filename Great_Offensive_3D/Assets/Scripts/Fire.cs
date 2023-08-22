using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public GameObject blood;
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
        transform.Translate(new Vector3(1,0,0)*Time.deltaTime*speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject bloodNew = Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(bloodNew,0.15f);
            gm.money += 150;
            gm.myMoney.text = gm.money.ToString();
            gm.killInt += 1;
            gm.killScore.text = gm.killInt.ToString();
        }
        
        if(other.tag=="Boss")
        {
            GameObject bloodNews = Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(bloodNews, 0.15f);
        }
    }
}
