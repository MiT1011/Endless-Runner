using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApllicationStatus : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    public void OnApplicationPause(bool pauseStatus){
        if(pauseStatus){
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            Preference.Instance.User.isGameStarted = false;
        }else{
            Preference.Instance.User.isGameStarted = true;
        }
        Preference.Instance.SaveData();
    }
}
