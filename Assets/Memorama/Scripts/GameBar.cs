using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBar : MonoBehaviour
{
    bool starCountDown = false;
    [SerializeField] float timeCountDown;
    [SerializeField] Image imageTimer;
    [SerializeField] Main main;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (starCountDown)
        {
            Debug.Log("Iniciando info");
            main.controlTimer("Stop");
            timeCountDown -= Time.deltaTime;
            imageTimer.fillAmount = timeCountDown / 20f;

            if (timeCountDown <= 0f)
            {
                starCountDown = false;
                main.controlTimer("Again");
                Debug.Log("Retornando memorama");
            }
        }
    }

    public void StarInfo()
    {
        starCountDown = true;
        timeCountDown = 20f;
    }
    public void StopInfo()
    {
        starCountDown = false;
    }
}
