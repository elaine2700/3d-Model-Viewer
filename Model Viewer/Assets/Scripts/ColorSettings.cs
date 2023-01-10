using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSettings", menuName = "ScriptableObjects/ColorSettings")]
public class ColorSettings : ScriptableObject
{
    public Color defaultColor = Color.gray;
    public Color hoverColor = Color.blue;
    public Color selectedColor = Color.red;
}
