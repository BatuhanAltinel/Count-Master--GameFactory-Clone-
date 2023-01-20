using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject playerCountCanvas;
    [SerializeField] GameObject slideBar;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
            Destroy(gameObject);
        
        slideBar.SetActive(true);
    }

    public void InActiveSlideBar()
    {
        slideBar.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void WinPanelActivation()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.WIN)
        {
            winPanel.SetActive(true);
            playerCountCanvas.SetActive(false);
        }   
        else
        {
            winPanel.SetActive(false);
            playerCountCanvas.SetActive(true);
        }
            
    }
    public void LosePanelActiviation()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.LOSE)
        {
            losePanel.SetActive(true);
            playerCountCanvas.SetActive(false);
        }   
        else
        {
            losePanel.SetActive(false);
            playerCountCanvas.SetActive(true);
        }
    }

    public void DeActivePlayerCountCanvas()
    {
        playerCountCanvas.SetActive(false);
    }
}
