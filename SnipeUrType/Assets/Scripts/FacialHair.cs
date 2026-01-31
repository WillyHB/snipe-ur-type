using UnityEngine;

[CreateAssetMenu(fileName = "FacialHair", menuName = "Attributes/FacialHair")]
public class FacialHair : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public string[] Descriptions;
}

