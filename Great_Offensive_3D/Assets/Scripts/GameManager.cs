using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlayActive = false;
    public GameObject spawnBoat;

    void Awake()
    {
        if (!isPlayActive)
        {
            Time.timeScale = 0;
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


}
