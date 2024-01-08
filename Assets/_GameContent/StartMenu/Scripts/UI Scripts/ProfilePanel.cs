using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private UIManager uIManager_Script;
    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private MainMenuPanel mainMenuPanel_Script;
    [SerializeField] private SelectProfileImagesUI selectProfileImagesUI_Script;
    public Image profileImage;
    string playerName;
    void Start()
    {
        UpdateProfileImage();
    }
    public void UpdateNameText(){
        nameText.text = Preference.Instance.User.name;
    }
    public void UpdateProfileImage(){
        profileImage.sprite = selectProfileImagesUI_Script.profileSprites_List[Preference.Instance.User.profileIndex];
    }
    public void ProfileImageButton(){
        selectProfileImagesUI_Script.gameObject.SetActive(true);
    }
    public void OnClickBack(){
        playerName = Preference.Instance.User.name;
        if(playerName != null){            
            mainMenuPanel_Script.UpdateNameText(playerName);
        }
        mainMenuPanel_Script.UpdateProfileImage();
        uIManager_Script.ShowMainMenuPanel();
        // mainUI_Script.profileImage.sprite = selectProfileImagesUI_Script.profileSprites_List[Preference.Instance.User.profileIndex];

        // selectProfileImageUI_Object.SetActive(false);
    }

    public void ReadPlayerNameInput(string name){
        if(name.Length != 0){
            playerName = name;
            Preference.Instance.User.name = playerName.Trim();
            Preference.Instance.SaveData();
        }
        UpdateNameText();
    }
}
