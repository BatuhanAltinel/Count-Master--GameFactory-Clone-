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
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void WinPanelActivation()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.WİN)
            winPanel.SetActive(true);
        else
            winPanel.SetActive(false);
    }
    public void LosePanelActiviation()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.LOSE)
            losePanel.SetActive(true);
        else
            losePanel.SetActive(false);
    }
}
