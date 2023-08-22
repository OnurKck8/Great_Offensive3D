using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShipController : MonoBehaviour
{

    public float speed = 0;
    public Animator rotateBoat;
    GameManager gm;

    public GameObject bossSoldier;
    AudioSource boatSound;
    bool soundPlay = true;
    bool bossSpawn = false;




    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Area").GetComponent<GameManager>();
        boatSound = GetComponent<AudioSource>();


    }

    void Update()
    {
        if (gm.isPlayActive == true && gm.isBossDestroy == false)
        {
            transform.Translate(Vector3.down * speed);

            if (soundPlay)
            {
                boatSound.Play();
                soundPlay = false;
            }

        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (gm.isBossDestroy == false)
        {
            if (other.tag == "Rotate")
            {
                speed = 0;

                rotateBoat.SetBool("RotateBoat", true);
                StartCoroutine(WaitBoat());
                boatSound.Stop();
            }

        }

    }



    public IEnumerator WaitBoat()
    {

        yield return new WaitForSeconds(1f);

    
     
        Animator myAnim = bossSoldier.GetComponent<Animator>();
        myAnim.SetBool("Runner", true);
        bossSoldier.GetComponent<BossController>().speed = 30f;
        bossSoldier.transform.SetParent(null);
     

        yield return new WaitForSeconds(5f);
        speed = 1;
        boatSound.Play();

        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
