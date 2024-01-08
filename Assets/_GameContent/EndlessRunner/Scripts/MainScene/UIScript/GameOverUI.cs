using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int score;

    private void Start() {
        score = (int)(playerController.score);
        scoreText.text = "Score : " + score.ToString();

        CheckHighScore();
        highScoreText.text = "Highest : " + Preference.Instance.User.highScore.ToString();
    }

    private void CheckHighScore(){
        if(Preference.Instance.User.highScore < score){
            Preference.Instance.User.highScore = score;
        }
    }


    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
    public void RestartGame(){
        // StartCoroutine(RestartDelay());
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame(){
        // StartCoroutine(QuitDelay());
        Application.Quit();
    }
    // IEnumerator RestartDelay(){
    //     yield return new WaitForSeconds(0.5f);
    //     SceneManager.LoadScene("Level1");
    // }
    // IEnumerator QuitDelay(){
    //     yield return new WaitForSeconds(0.5f);
    //     Application.Quit();
    // }

}
