using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogoAndNamePanel : MonoBehaviour
{
    [SerializeField] UIManager uIManager_Script;
    private void Start() {
        GameManager.instance.OnStatechanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e){
        if(GameManager.instance.IsLoading()){
            uIManager_Script.ShowLodingPanel();

            
            // Preference.Instance.User.isGameStarted = true;
            Preference.Instance.SaveData();
        }
    }
}
