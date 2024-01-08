using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float coinRotationSpeed = 20;
    PlayerManager playerManager;
    AudioManager audioManager;
    MainGameUI mainGameUI;
    void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
        mainGameUI = FindAnyObjectByType<MainGameUI>();
    }
    void Update()
    {
        // transform.Rotate(coinRotationSpeed * Time.deltaTime, 0, 0);
        transform.Rotate( 0, coinRotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            playerManager.SetCoins(1);
            mainGameUI.ChangeCoinText();
            audioManager.PlaySound("PickUpCoins");
            Destroy(gameObject);
        }
    }
}
