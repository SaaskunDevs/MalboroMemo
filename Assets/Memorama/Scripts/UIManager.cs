using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]  GameObject menuUI;
    [SerializeField]  GameObject gameUI;
    [SerializeField]  GameObject instrucUI;
    [SerializeField]  GameObject winUI;
    [Header("Scripts")]
    [SerializeField]  Main main;

    public void GoMenu()
    {
        menuUI.SetActive(true);

        instrucUI.SetActive(false);
        gameUI.SetActive(false);
        winUI.SetActive(false);
    }
    public void GoInstructions()
    {
        instrucUI.SetActive(true);

        menuUI.SetActive(false);
        gameUI.SetActive(false);
        winUI.SetActive(false);
        
    }
    public void GoGame()
    {
        gameUI.SetActive(true);

        menuUI.SetActive(false);
        instrucUI.SetActive(false);
        winUI.SetActive(false);

        main.StartMemorama();
    }
    public void GoWin()
    {
        winUI.SetActive(true);
        
        menuUI.SetActive(false);
        gameUI.SetActive(false);
        instrucUI.SetActive(false);
        
    }
    public void resetGame()
    {
        SceneManager.LoadScene(0);
    }
}
