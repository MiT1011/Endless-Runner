using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] private UIManager uIManager_Script;
    [SerializeField] private Image faderImage;
    private void Start() {
        faderImage.fillAmount = 0;
        GameManager.instance.OnStatechanged += GameManager_OnStateChanged;
    }
    private void Update() {
        FadeLoadingBar();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e){
        if(GameManager.instance.IsMainMenu()){
            if(Preference.Instance.User.firstTimeOpened == 0){
                uIManager_Script.ShowCreateProfilePanel();
            }
            else{
                uIManager_Script.ShowMainMenuPanel();
            }
        }
    }

    private void FadeLoadingBar(){
        faderImage.fillAmount = (5 - GameManager.instance.loadingTimer) / 5;
    }
}
