using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameLogoandNamePanel;
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject characterPanel;
    [SerializeField] private GameObject missionPanel;
    [SerializeField] private GameObject profilePanel;
    [SerializeField] private GameObject createProfilePanel;

    void Start()
    {
        // Debug.Log(Preference.Instance.User.isGameStarted);
        if(!Preference.Instance.User.isGameStarted){
            ShowLogoNamePanel();
            Preference.Instance.User.isGameStarted = true;
        }
        // else if(Preference.Instance.User.firstTimeOpened == 0){
        //     ShowCreateProfilePanel();
        //     // ShowMainMenuPanel();
        // }
        else{
            GameManager.instance.ChangeToMainMenu();
            ShowMainMenuPanel();
        }
    }

    private void HideAllPanel(){
        gameLogoandNamePanel.SetActive(false);
        loadingPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(false);
        characterPanel.SetActive(false);
        missionPanel.SetActive(false);
        profilePanel.SetActive(false);
        createProfilePanel.SetActive(false);
    }
    public void ShowLogoNamePanel(){
        HideAllPanel();
        gameLogoandNamePanel.SetActive(true);
    }
    public void ShowLodingPanel(){
        HideAllPanel();
        loadingPanel.SetActive(true);
    }
    public void ShowMainMenuPanel(){
        HideAllPanel();
        mainMenuPanel.SetActive(true);
    }
    public void ShowSettingPanel(){
        HideAllPanel();
        settingPanel.SetActive(true);
    }
    public void ShowCharacterPanel(){
        HideAllPanel();
        characterPanel.SetActive(true);
    }
    public void ShowMissionPanel(){
        HideAllPanel();
        missionPanel.SetActive(true);
    }
    public void ShowProfilePanel(){
        HideAllPanel();
        profilePanel.SetActive(true);
    }
    public void ShowCreateProfilePanel(){
        HideAllPanel();
        createProfilePanel.SetActive(true);
    }
}
