//This Script have one class User which have the user's data for saving the profile of the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class User
{
    public string name { get; set; } //Player Name Text
    public int profileIndex { get; set; } //Player Profile Image Index
    public int coins { get; set; }
    // public int playerIndex { get; set; } //Current character index
    // public int controllerIndex { get; set; } //Selected Controller Type Index
    // public List<int> unLockedCharacter = new List<int>(); //List for Unlocked and locked Character
    public string spinTimer { get; set; } //Picker Wheel Timer
    public int firstTimeOpened = 0; //Game Stating First time or not for CreateProfile UI
    public bool isGameStarted ; //Game Stated or not for StartingUI Management
    public int highScore { get; set; } //Highest Score
}
