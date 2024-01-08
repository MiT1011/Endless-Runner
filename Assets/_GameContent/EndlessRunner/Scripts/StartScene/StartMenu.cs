using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame(){
        StartCoroutine(StartDelay());
    }

    public void QuitGame(){
        // StartCoroutine(QuitDelay());
    }

    IEnumerator StartDelay(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level1");
    }
    // IEnumerator QuitDelay(){
    //     yield return new WaitForSeconds(0.5f);
    //     Application.Quit();
    // }
}
