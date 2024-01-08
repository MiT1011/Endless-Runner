using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public void Continue(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart(){
        SceneManager.LoadScene("Level1");
    }
    public void Home(){
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
