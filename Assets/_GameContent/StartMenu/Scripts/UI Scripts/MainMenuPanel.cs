using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private UIManager uIManager_Script;
    [SerializeField] private SelectProfileImagesUI selectProfileImagesUI_Script;
    [SerializeField] private TextMeshProUGUI name_Text;
    [SerializeField] private ProfilePanel profilePanel_Script;
    [SerializeField] private TextMeshProUGUI coinText;
    public UnityEngine.UI.Image profileImage;
    private void Start() {
        UpdateNameText(Preference.Instance.User.name);
        UpdateProfileImage();
        UpdateCoin();    
        // GameManager.instance.OnStatechanged += GameManager_OnStateChanged;
    }
    public void UpdateNameText(string name){
        name_Text.text = name;
    }
    public void UpdateProfileImage(){
        profileImage.sprite = selectProfileImagesUI_Script.profileSprites_List[Preference.Instance.User.profileIndex];
    }
    public void UpdateCoin(){
        coinText.text = Preference.Instance.User.coins.ToString();
    }

    // private void GameManager_OnStateChanged(object sender, System.EventArgs e){
    //     if(GameManager.instance.IsGamePlaying()){
    //         // uIManager_Script.ShowMainMenuPanel();
    //         Debug.Log("Start the game");
    //     }
    // }



    public void PlayGame(){
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level1");
    }


    public void SpinWheelButton(){
        StartCoroutine(SpinSceneDelay());
    }
    IEnumerator SpinSceneDelay(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SpinWheelScene");
    }



    public void StoreButton(){
        uIManager_Script.ShowCharacterPanel();
    }
    public void MissionButton(){
        uIManager_Script.ShowMissionPanel();
    }
    public void SettingButton(){
        uIManager_Script.ShowSettingPanel();
        profilePanel_Script.UpdateNameText();
    }
    public void ProfileButton(){
        uIManager_Script.ShowProfilePanel();
        profilePanel_Script.UpdateNameText();
    }
}
