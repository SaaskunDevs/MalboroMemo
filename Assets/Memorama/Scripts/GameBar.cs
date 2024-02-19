using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBar : MonoBehaviour
{
    int numberOfPoints;
    bool starCountDown = false;
    float timeCountDown;
    [SerializeField] float timeLeft;
    [SerializeField] Image imageTimer;
    [SerializeField] Main main;
    [SerializeField] UIManager uiManager;

    void Start()
    {
        timeCountDown = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (starCountDown)
        {
           // Debug.Log("Iniciando info");
            main.controlTimer("Stop");
            timeCountDown -= Time.deltaTime;
            imageTimer.fillAmount = timeCountDown / timeLeft;

            if (timeCountDown <= 0f)
            {
                starCountDown = false;
                main.controlTimer("Again");
                Debug.Log("Retornando memorama");
                uiManager.deactivateInfo();
                if (numberOfPoints == main.imgs.Length)
                {
                    main.WinMoment();
                }
            }
        }
    }

    public void StarInfo()
    {
        timeCountDown = timeLeft;
        starCountDown = true;
        numberOfPoints++;
    }
    public void StopInfo()
    {
        starCountDown = false;
    }
}
