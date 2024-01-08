using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "PickerObject")]
public class ObjectsInPickerSO : ScriptableObject
{
    public Sprite sprite;
    public int Amount;
    public string objectName;
}
