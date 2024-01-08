using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject pauseUI;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;
    private void Start() {
        ShowScore(0);
        ChangeCoinText();
    }
    public void ShowScore(int score){
        scoreText.text = score.ToString();
    }
    
    public void ChangeCoinText(){
        coinText.text = playerManager.numberOfCoins.ToString();
    }
    public void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }
}
