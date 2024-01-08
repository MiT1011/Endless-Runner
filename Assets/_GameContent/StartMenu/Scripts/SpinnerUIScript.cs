//This UI script is used for updating the visual of SpinnerUI.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using Assets.Scripts.Helper;
using UnityEngine.SceneManagement;

    public class SpinnerUIScript : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private GameObject coinWarningText;
        [SerializeField] private MainMenuPanel mainMenuPanel_Script;
        public GameObject pauseUI;

        private void Start() {
            coinWarningText.SetActive(false);
            ChangeCoinText();
            GetComponentInChildren<TryPickerWheel>().ActiveCoinSpinButton();
        }


        public void Close(){
            coinWarningText.SetActive(false);
            // startSceneUIController.EnableMainUI();
            // ChangeCoinText();
            GetComponentInChildren<TryPickerWheel>().ActiveSpinButton();
            GetComponentInChildren<TryPickerWheel>().ResetRotation();
            
            if(GetComponentInChildren<TryPickerWheel>().detailsUI){
                Destroy(GetComponentInChildren<TryPickerWheel>().detailsUI);
            }

            SceneManager.LoadScene("StartScene");
        }
        public void ChangeCoinText(){
            coinText.text = GetCoins().ToString();
        }
        private int GetCoins(){
            return Preference.Instance.User.coins;
        }
        public void ActiveWarningCoinText(){
            StartCoroutine(WarningCoinText());
        }

        private IEnumerator WarningCoinText(){
            coinWarningText.SetActive(true);
            yield return new WaitForSeconds(3f);
            coinWarningText.SetActive(false);
        }
    }