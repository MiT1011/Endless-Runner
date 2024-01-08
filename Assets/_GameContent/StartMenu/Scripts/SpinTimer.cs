//This script is used in 24 hour timer which is used in picker spin wheel

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// using Assets.Scripts.Helper;


    public class SpinTimer : MonoBehaviour
    {
        [SerializeField] private TryPickerWheel tryPickerWheel_Script ;
        [SerializeField] private TextMeshProUGUI timeText ;
        private DateTime endTime;
        private TimeSpan diff;
        private bool isSpinTimerOver = true;

        //called when we want to start timer
        public void StartTimer(){
            isSpinTimerOver = false;
            
            // Start the timer
            DateTime startTime = DateTime.Now;

            TimeSpan duration = new TimeSpan(24, 0, 0);

            // // Save the timer value
            // PlayerPrefs.SetString("LockTimer", startTime.Add(duration).ToString());

            // // Check the timer
            // string savedTime = PlayerPrefs.GetString("LockTimer");

            string savedTime = startTime.Add(duration).ToString();

            

            endTime = DateTime.Parse(savedTime);
            SaveSpinerTimer(endTime.ToString());
        }

        //Called on start 
        public void CheckTimerOnStart(){
            if((LoadSpinnerTimer() != "") && (LoadSpinnerTimer() != null) ){
                endTime = DateTime.Parse(LoadSpinnerTimer());
                isSpinTimerOver = false;
                tryPickerWheel_Script.coinSpinButton.gameObject.SetActive(true);
            }
        }

        //called on update
        public void Check24Hours(){

            diff = (endTime - DateTime.Now);
            string hours = diff.Hours.ToString("D2");
            string minutes = diff.Minutes.ToString("D2");
            string seconds = diff.Seconds.ToString("D2");

            timeText.text = hours + ":" + minutes + ":" + seconds;
            // if ((DateTime.Now > endTime) && endTime != null)
            if (diff < TimeSpan.Zero)
            {
                isSpinTimerOver = true;
                // PlayerPrefs.SetString("EndTimer","");
            }
            
            if(isSpinTimerOver){
                tryPickerWheel_Script.spinButton.gameObject.SetActive(true);
                timeText.gameObject.SetActive(false);
                tryPickerWheel_Script.coinSpinButton.gameObject.SetActive(false);
            }else{
                tryPickerWheel_Script.spinButton.gameObject.SetActive(false);
                timeText.gameObject.SetActive(true);
            }
        }

        public void SaveSpinerTimer(string timerString){
            Preference.Instance.User.spinTimer = timerString;
            Preference.Instance.SaveData();
        }
        
        public string LoadSpinnerTimer(){
            // return null;
            return Preference.Instance.User.spinTimer;
        }
    }