using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 0;
    public Animator rotateBoat;
    GameManager gm;
    
    public GameObject[] greekSoldier;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Area").GetComponent<GameManager>();
        
    }
    void Update()
    {
        if(gm.isPlayActive==true)
        {
            transform.Translate(Vector3.down * speed);
        }
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Rotate")
        {
            speed = 0;
            rotateBoat.SetBool("RotateBoat", true);
            StartCoroutine(WaitBoat());
        }

        if(other.tag=="Spawn")
        {
            Destroy(gameObject);

            Instantiate(gm.spawnBoat, transform.position, Quaternion.Euler(-90, 0,-90));
        }
        
    }

    public IEnumerator WaitBoat()
    {
        yield return new WaitForSeconds(1f);
        for(int i=0;i<greekSoldier.Length;i++)
        {
            Animator myAnim = greekSoldier[i].GetComponent<Animator>();
            myAnim.SetBool("Runner", true);
            greekSoldier[i].GetComponent<SoldierController>().speed = 30f;
            greekSoldier[i].transform.SetParent(null);
           
        }
        yield return new WaitForSeconds(5f);
        speed = 1;
    }
}
