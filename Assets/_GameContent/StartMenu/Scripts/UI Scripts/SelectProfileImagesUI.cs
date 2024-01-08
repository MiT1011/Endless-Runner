//This script is used for generating different profile image.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectProfileImagesUI : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject profileImagePrefab;
    public List<Sprite> profileSprites_List = new List<Sprite>();
    private int index = 0;

    private void Start() {
        foreach(Sprite profile in profileSprites_List){
            GameObject newProfile = Instantiate(profileImagePrefab, scrollViewContent);

            if(newProfile.TryGetComponent<profilePrefab>(out profilePrefab profilePrefab_Script)){
                profilePrefab_Script.index = index;
                index++;
            }

            if(newProfile.TryGetComponent<Image>(out Image img)){
                img.sprite = profile;
            }
        }
    }
}