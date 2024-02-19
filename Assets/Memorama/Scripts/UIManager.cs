using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]  GameObject menuUI;
    [SerializeField]  GameObject gameUI;
    [SerializeField]  GameObject memoramaGame;
    [SerializeField]  GameObject[] memoramaInfo;
    [SerializeField]  GameObject instrucUI;
    [SerializeField]  GameObject switchBtnNext;
    [SerializeField]  GameObject switchBtnReady;
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
    public void SwitchButton()
    {
        switchBtnNext.SetActive(false);
        switchBtnReady.SetActive(true);
    }
    public void GoGame()
    {
        gameUI.SetActive(true);
        memoramaGame.SetActive(true);

        menuUI.SetActive(false);
        instrucUI.SetActive(false);
        winUI.SetActive(false);

        main.StartMemorama();
    }
    public void GoWin()
    {
        winUI.SetActive(true);
        
        menuUI.SetActive(false);
        memoramaGame.SetActive(false);
        gameUI.SetActive(false);
        instrucUI.SetActive(false);
        
    }
    public void activateInfo()
    {
        foreach (var info in memoramaInfo)
        {
            info.SetActive(true);
        }
    }
    public void deactivateInfo()
    {
        foreach (var info in memoramaInfo)
        {
            info.SetActive(false);
        }
    }
    public void resetGame()
    {
        SceneManager.LoadScene(0);
    }
}
