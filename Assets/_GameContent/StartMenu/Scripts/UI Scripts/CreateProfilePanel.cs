using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateProfilePanel : MonoBehaviour
{
    
    [SerializeField] private UIManager uIManager_Script;
    [SerializeField] private MainMenuPanel mainMenuPanel_Script;
    [SerializeField] private SelectProfileImagesUI selectProfileImagesUI_Script;
    [SerializeField] private Button submitButton;
    [SerializeField] private TextMeshProUGUI holderText;
    private string plyr_name;
    
    private void Awake() {
        submitButton.onClick.AddListener(() => {
            if (!CheckEmptyString(Preference.Instance.User.name)){
                Preference.Instance.User.firstTimeOpened = 1;
                Preference.Instance.SaveData();
                // Debug.Log("Changing");
                // this.gameObject.SetActive(false);
                uIManager_Script.ShowMainMenuPanel();
            }
            // if(mainMenuPanel_Script){
                // Debug.Log("Got From Data " + Preference.Instance.User.profileIndex);
                // mainMenuPanel_Script.profileImage.sprite = selectProfileImagesUI_Script.profileSprites_List[Preference.Instance.User.profileIndex];
            // }

        });
    }

    public void Close(){
        Preference.Instance.User.isGameStarted = false;
        Preference.Instance.SaveData();
        Application.Quit();
    }
    public GameObject selectProfileImagePanel;
    public void ProfileImageButton(){
        selectProfileImagePanel.SetActive(true);
    }

    public void InputFieldName_EndEdit(string name){
        bool emptyString = CheckEmptyString(name);
        plyr_name = name;
        Preference.Instance.User.name = plyr_name.Trim();

        if(!emptyString){
            holderText.gameObject.SetActive(false);
        }
        if(emptyString){
            holderText.gameObject.SetActive(true);
        }
    }
    
    public void OnSelectInputField(string name){
        holderText.gameObject.SetActive(false);
    }
    public void OnDeselectInputField(string name){
        holderText.gameObject.SetActive(true);
    }
    private bool CheckEmptyString(string name){
            if(name != null){
                for(int i = 0; i < name.Length ; i++ ){
                    if(!char.IsWhiteSpace(name, i)){
                        return false;
                    }
                }
            }
            return true;
        }
}
