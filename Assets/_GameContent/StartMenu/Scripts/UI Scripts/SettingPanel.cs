using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] Sprite offImage;
    [SerializeField] Sprite onImage;

    bool isChanged = true;

    public void ChangeButtonIcon(Button btn){
        if(!isChanged){
            btn.image.sprite = offImage;
            Debug.Log("Off the " + btn.name);

            isChanged = true;
        }
        else{
            btn.image.sprite = onImage;
            Debug.Log("On the " + btn.name);

            isChanged = false;
        }
    }
}
