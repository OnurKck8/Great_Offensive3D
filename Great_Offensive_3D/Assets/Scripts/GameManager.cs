using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayActive = false;
    public GameObject spawnBoat;
    public GameObject gunsPoint;
    public int myGunName;
    GameObject myGun;

    [Header("GunsPanel")]
    public int money;
    public GameObject[] guns;

    void Awake()
    {
        if (!isPlayActive)
        {
            Time.timeScale = 0;
        }

        if (PlayerPrefs.HasKey("MyGunName"))
        {
            myGunName=PlayerPrefs.GetInt("MyGunName");
            myGun = Instantiate(guns[myGunName], gunsPoint.transform.position, guns[myGunName].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
        }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPlayActive = true;
        }

        if (!isPlayActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

        }
    }

    public void GunOne()
    {
        if(money>=150)
        {
            myGunName = 0;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[0], gunsPoint.transform.position, guns[0].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 150;
        }
    }
    public void GunTwo()
    {
        if (money >= 170)
        {
            myGunName = 1;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[1], gunsPoint.transform.position, guns[1].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 170;
        }
    }
    public void GunThree()
    {
        if (money >= 200)
        {
            myGunName = 2;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[2], gunsPoint.transform.position, guns[2].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 200;
        }
    }
    public void GunFour()
    {
        if (money >= 220)
        {
            myGunName = 3;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[3], gunsPoint.transform.position, guns[3].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 200;
        }
    }

}
