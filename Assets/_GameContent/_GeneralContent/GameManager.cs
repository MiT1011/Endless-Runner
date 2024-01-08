using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;}

    public event EventHandler OnStatechanged;

    private enum State {
        
        WaitTime,
        LoadingTime,
        MainMenu,
        GamePlaying,
        GameOver,
    }

    private State state;
    public float waitTimer = 1f;
    public float loadingTimer = 5f;

    [HideInInspector]
    public bool waitingState = true;

    [HideInInspector]
    public bool isGamePlaying = false;
    public bool isGameOver = false;
    
    public void Awake() {
        instance = this;
        state = State.WaitTime;
    }

    private void Update() {
        switch (state){

            case State.WaitTime:
                waitTimer -= Time.deltaTime;
                if(waitTimer < 0f){
                    state = State.LoadingTime;
                    OnStatechanged?.Invoke(this, EventArgs.Empty);

                }
                break;

            case State.LoadingTime:
                loadingTimer -= Time.deltaTime;
                if(loadingTimer < 0f){
                    state = State.MainMenu;
                    OnStatechanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.MainMenu:
                if(isGamePlaying){
                    state = State.GamePlaying;
                    OnStatechanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GamePlaying:
                if(isGameOver){
                    state = State.GameOver;
                    OnStatechanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GameOver:
                break;
        }
        // Debug.Log(state);
    }

    public bool IsWaiting(){
        return state == State.WaitTime;
    }
    public bool IsLoading(){
        return state == State.LoadingTime;
    }
    public bool IsGamePlaying(){
        return state == State.GamePlaying;
    }
    public bool IsMainMenu(){
        return state == State.MainMenu;
    }

    public float GetCountDownTimer(){
        return loadingTimer;
    }
    public void ChangeToMainMenu(){
        state = State.MainMenu;
    }
}
