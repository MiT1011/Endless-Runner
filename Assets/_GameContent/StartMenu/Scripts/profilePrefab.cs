//This script is used in profile scroll image which is used for selecting profile image from scroll

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class profilePrefab : MonoBehaviour, IPointerDownHandler
{
    public int index;

    SelectProfileImagesUI selectProfileImagesUI_script;
    // MainMenuPanel mainMenuPanel_script;

    private void Start() {
        selectProfileImagesUI_script = FindAnyObjectByType<SelectProfileImagesUI>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Preference.Instance.User.profileIndex = index;
        Preference.Instance.SaveData();

        GameObject img_object = GameObject.Find("ProfileButton");

        if((img_object.GetComponent<Image>().sprite) != eventData.pointerEnter.gameObject.GetComponent<Image>().sprite){
            img_object.GetComponent<Image>().sprite = eventData.pointerEnter.gameObject.GetComponent<Image>().sprite;
        }

        selectProfileImagesUI_script.gameObject.SetActive(false);

        // CreateProfilePanel createProfilePanel_script = FindAnyObjectByType<CreateProfilePanel>();
        // createProfilePanel_script.selectProfileImagePanel.SetActive(false);
    }
    
    // public void UpdateProfileImage(){
        
    //     mainMenuPanel_script = FindAnyObjectByType<MainMenuPanel>();
    //     mainMenuPanel_script.profileImage.sprite = selectProfileImagesUI_script.profileSprites_List[Preference.Instance.User.profileIndex];
    // }
}