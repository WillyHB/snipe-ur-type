using UnityEngine;

[CreateAssetMenu(fileName = "HairStyle", menuName = "Attributes/HairStyle")]
public class HairStyle : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public bool Male, Female;
    public string[] Descriptions;
    
}
