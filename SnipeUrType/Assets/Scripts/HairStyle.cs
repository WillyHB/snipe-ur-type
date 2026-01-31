using UnityEngine;

[CreateAssetMenu(fileName = "HairStyle", menuName = "Attributes/HairStyle")]
public class HairStyle : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public string[] Descriptions;
    
}
