using System.Collections;
using System.Collections.Generic;
// using Assets.Scripts.Helper;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    // [SerializeField] private GameObject cube;
    public void ResumeButton(){

        Preference.Instance.User.isGameStarted = true;
        Preference.Instance.SaveData();
        
        gameObject.SetActive(false);
        // cube.SetActive(true);
        Time.timeScale = 1;
    }
    public void QuitButton(){
        Application.Quit();
    }
}