using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] public Icon[] icons;
    [SerializeField] public Texture2D[] imgs;

    #region Scripts
    [SerializeField] UIManager uiManager;
    [SerializeField] GameBar gameBar;
    [SerializeField] SoundsManager soundsManager;
    #endregion
    private bool started;
    private bool waitForCheck;
    

    #region infoZone
    [SerializeField] public Texture2D infoImage;
    [SerializeField] public InfoCigarrette[] infoCigarrettes;
    [SerializeField] Image imgInfo;
    [SerializeField] TextMeshProUGUI infoText;
    #endregion

    #region Timer
    [SerializeField] private int timeToPlay = 60; // Tiempo en segundos
    [SerializeField] private TextMeshProUGUI timeText; // Texto para mostrar el tiempo restante
    private float timeLeft; // Tiempo restante en segundos
    #endregion

    #region Score
    [SerializeField] private TextMeshProUGUI scoreTxt; // Texto para mostrar el score
    [SerializeField] TextMeshProUGUI Finalscore;
    [SerializeField] TextMeshProUGUI avanceGame;
    private int score, sizeBegin;
    #endregion

    public int selected;

    private Icon item1, item2;

    public int[] randomArray; // Arreglo de enteros aleatorios

    private void Start()
    {
        //CreateIDs();
    }

    private void Update()
    {
        if (started)
        {
            CheckTouches();
            UpdateTimeText();
        }
    }

    public void CreateIDs(int size)
    {
        randomArray = CreateRandomArray(size);

        for (int i = 0; i < randomArray.Length; i++)
        {
            icons[i].SetImage(randomArray[i], imgs[randomArray[i] - 1]);
        }
    }

    private int[] CreateRandomArray(int size)
    {
        int[] array = new int[size];
        List<int> availableNumbers = new List<int>();

        for (int i = 1; i <= size / 2; i++)
        {
            availableNumbers.Add(i);
            availableNumbers.Add(i);
        }

        for (int i = 0; i < size; i++)
        {
            int randomIndex = Random.Range(0, availableNumbers.Count);
            array[i] = availableNumbers[randomIndex];
            availableNumbers.RemoveAt(randomIndex);
        }

        return array;
    }



    public void StartMemorama()
    {
        timeLeft = timeToPlay;
        started = true;
    }

    void CheckTouches()
    {
        if (waitForCheck)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Realizar una prueba de colisi�n en la posici�n del clic
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero, Mathf.Infinity);

            if (hit.collider != null)
            {
 //               Debug.Log("Collider " + hit.collider.name + " ha sido tocado");

                Icon icn = hit.collider.GetComponent<Icon>();

                if (icn.CanInteract())
                {

                    if (selected == 0)
                    {
                        item1 = icn;
                        icn.UserClick();
                        selected++;
                    }
                    else if (selected == 1)
                    {
                        item2 = icn;
                        icn.UserClick();
                        selected++;
                        waitForCheck = false;
                    }
                }
                
            }
        }
    }

    public void CheckItems()
    {
        if (waitForCheck)
            return;
       // canSelect = true;
        if (selected != 2)
            return;
        waitForCheck = true;
        Debug.Log("Check items");
        StartCoroutine(DelayToCheck());
    }

    IEnumerator DelayToCheck()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Check");
        if (item1.GetID() == item2.GetID())
        {
            
            item1.ParticlesAndDisable();
            item2.ParticlesAndDisable();
            soundsManager.PlaySound("Good");
            Score();
            sizeBegin++;
            avanceGame.text = sizeBegin + "/" + imgs.Length;
            Debug.Log(sizeBegin + " / " + imgs.Length);
            gameBar.StarInfo();
            Debug.Log("Iniciando info ID ELEGIDO: " + item1.GetID());
            infoText.text = infoCigarrettes[item1.GetID() - 1].infoCiga; 
            imgInfo.sprite = infoCigarrettes[item1.GetID() - 1].imgCigarrette;
            uiManager.activateInfo();
            // if (sizeBegin == imgs.Length)
            // {
            //     controlTimer("Stop");
            //     Finalscore.text = timeText.text;
                
            //     // uiManager.GoWin();
            // }
        }
        else
        {
  //          Debug.Log("Tamal");
            item1.ReturnAnim();
            item2.ReturnAnim();
        }

        yield return new WaitForSeconds(0.3f);
        selected = 0;
        waitForCheck = false;
    }

    void Score()
    {
        score += 100;
        scoreTxt.text = score.ToString();
    }
    private void UpdateTimeText()
    {
        timeLeft += Time.deltaTime;


        if (timeLeft >= 0)
        {
           // Debug.Log("Tiempo agotado.");
            Finalscore.text = score.ToString();
            // uiManager.GoWin();
        }

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void controlTimer(string controlTime)
    {
        switch (controlTime)
        {
            case "Again":
                started = true;
                break;
            case "Stop":
                started = false;
                break;
        }
    }

    public void WinMoment()
    {
        controlTimer("Stop");
        Finalscore.text = timeText.text;
        uiManager.GoWin();
    }
}
