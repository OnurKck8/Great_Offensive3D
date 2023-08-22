using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isPlayActive = false;
    public bool isBossDestroy = false;
    public GameObject gunsPoint;
    public GameObject failedPanel;
    int myGunName;
    GameObject myGun;

    public Image flagFill;


    public int killInt;
    int bestKillCount;

    public AudioSource managerSound, panelSound;

    [Header("FailedPanel")]
    public TextMeshProUGUI bestKill,currentKill,killScore;
   

    [Header("GunsPanel")]
    public GameObject gunsPanel,gunsBuyBtn;
    public int money;
    public TextMeshProUGUI myMoney;
    public GameObject[] guns;
    

    void Awake()
    {
        if (!isPlayActive)
        {
            Time.timeScale = 0;
            
        }

        myGun = Instantiate(guns[myGunName], gunsPoint.transform.position, guns[myGunName].transform.rotation);
        myGun.transform.parent = gunsPoint.transform;

        money=PlayerPrefs.GetInt("MyMoney");
        myMoney.text = money.ToString();

        bestKillCount=PlayerPrefs.GetInt("MyKill");
        bestKill.text = bestKillCount.ToString();
        killScore.text = "0";


        if (PlayerPrefs.HasKey("MyGunName"))
        {
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGunName =PlayerPrefs.GetInt("MyGunName");
            myGun = Instantiate(guns[myGunName], gunsPoint.transform.position, guns[myGunName].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
        }

        flagFill.fillAmount = 1;
        
    }
    void Start()
    {
        
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isPlayActive = true;
           
        }

        if (isPlayActive)
        {
            Time.timeScale = 1;
            
        }
        else
        {
            Time.timeScale = 0;
        }

        if (flagFill.fillAmount==0 || isBossDestroy)
        {
            failedPanel.SetActive(true);
            managerSound.Stop();
            isPlayActive = false;
        }

    

        killScore.text = killInt.ToString();
        currentKill.text = killInt.ToString();

        myMoney.text = money.ToString();
        PlayerPrefs.SetInt("MyMoney", money);


        if (killInt>bestKillCount || killInt>=0)
        {
            PlayerPrefs.SetInt("MyKill", killInt);
            bestKill.text = killInt.ToString();
        }
        else
        {
            bestKill.text = bestKillCount.ToString();
            currentKill.text = killInt.ToString();
        }
       
    }

    public void GunsBuy()
    {
        gunsPanel.SetActive(true);
        gunsBuyBtn.SetActive(false);
    }

    public void GunOne()
    {
        if(money>=1000)
        {
            myGunName = 0;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[0], gunsPoint.transform.position, guns[0].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 1000;
            
        }
        gunsPanel.SetActive(false);
        gunsBuyBtn.SetActive(true);
    }
    public void GunTwo()
    {
        if (money >= 2500)
        {
            myGunName = 1;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[1], gunsPoint.transform.position, guns[1].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 2500;
           
        }
        gunsPanel.SetActive(false);
        gunsBuyBtn.SetActive(true);
    }
    public void GunThree()
    {
        if (money >= 4000)
        {
            myGunName = 2;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[2], gunsPoint.transform.position, guns[2].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 4000;
           
        }
        gunsPanel.SetActive(false);
        gunsBuyBtn.SetActive(true);
    }
    public void GunFour()
    {
        if (money >= 6500)
        {
            myGunName = 3;
            PlayerPrefs.SetInt("MyGunName", myGunName);
            Destroy(gunsPoint.transform.GetChild(0).gameObject);
            myGun = Instantiate(guns[3], gunsPoint.transform.position, guns[3].transform.rotation);
            myGun.transform.parent = gunsPoint.transform;
            money -= 6500;
          
        }
        gunsPanel.SetActive(false);
        gunsBuyBtn.SetActive(true);
    }



    public void Menu()
    {
        SceneManager.LoadScene(0);
        panelSound.Stop();
    }
}
