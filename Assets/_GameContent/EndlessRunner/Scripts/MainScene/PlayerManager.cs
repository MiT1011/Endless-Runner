using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public int numberOfCoins = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;

    private void Start() {
        Time.timeScale = 1;
        numberOfCoins = 0;
        isGameStarted = false;
    }

    private void Update() {
        if(SwipeManager.tap){
            isGameStarted = true;
            Destroy(startingText);
        }
    }
    public void GameOver(){
        Time.timeScale = 0;
        SaveCoins(numberOfCoins);
        gameOverPanel.SetActive(true);
    }

    public void SetCoins(int coinValue){
        numberOfCoins += coinValue;
    }
    public void SaveCoins(int coin){
        Preference.Instance.User.coins += coin;
        Preference.Instance.SaveData();
    }
}
