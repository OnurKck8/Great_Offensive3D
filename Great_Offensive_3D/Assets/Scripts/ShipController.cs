using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 0;
    public Animator rotateBoat;
    GameManager gm;
    
    public GameObject[] greekSoldier;
    AudioSource boatSound;
    bool soundPlay = true;

    void Start()
     {
        gm = GameObject.FindGameObjectWithTag("Area").GetComponent<GameManager>();
        boatSound = GetComponent<AudioSource>();

      
    }

    void Update()
    {
        if(gm.isPlayActive==true && gm.isBossDestroy==false)
        {
            transform.Translate(Vector3.down * speed);

            if (soundPlay)
            {
                boatSound.Play();
                soundPlay = false;
            }

        }
        else
        {
            boatSound.Stop();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(gm.isBossDestroy==false)
        {
            if (other.tag == "Rotate")
            {
                speed = 0;

                rotateBoat.SetBool("RotateBoat", true);
                StartCoroutine(WaitBoat());
                boatSound.volume=0.045f;
            }
           
        } 
        
    }

   

    public IEnumerator WaitBoat()
    {
        
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < greekSoldier.Length; i++)
        {
            Animator myAnim = greekSoldier[i].GetComponent<Animator>();
            myAnim.SetBool("Runner", true);
            greekSoldier[i].GetComponent<SoldierController>().speed = 25f;
            greekSoldier[i].transform.SetParent(null);
        }

        yield return new WaitForSeconds(5f);
        speed = 1;
        boatSound.Play();

        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
