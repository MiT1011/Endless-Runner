using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationCloseCheck : MonoBehaviour
{
    // [SerializeField] private GameObject gamePauseUI;
    // bool odd = true;

    // private void Start() {
    //     gamePauseUI.SetActive(false);
    // }
    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.Escape) && odd){
    //         pauseUI.SetActive(true);
    //         odd = false;
    //         Time.timeScale = 0;
    //     }
    //     else if(Input.GetKeyDown(KeyCode.Escape) && !odd){
    //         pauseUI.SetActive(false);
    //         odd = true;
    //         Time.timeScale = 1;
    //     }
    // }
    private void OnApplicationQuit()
    {
        // Debug.Log("Closing");
        Preference.Instance.User.isGameStarted = false;
        Preference.Instance.SaveData();
        
    }
    private void OnApplicationPause(){
        // Debug.Log("Pause");
        // gamePauseUI.SetActive(true);
        Preference.Instance.User.isGameStarted = false;
        Preference.Instance.SaveData();
    }

    // void OnApplicationPause(bool pauseStatus) {
    //     Debug.Log("Check1");
    //     if(pauseStatus){
    //         gamePauseUI.SetActive(true);
    //     }
    //     //time scale will 0
    //     Time.timeScale = 0;
    //     Preference.Instance.User.isGameStarted = false;
    //     Preference.Instance.SaveData();
    // }
}
