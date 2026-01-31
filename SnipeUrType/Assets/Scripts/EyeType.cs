using UnityEngine;

[CreateAssetMenu(fileName = "EyeType", menuName = "Attributes/EyeType")]
public class EyeType : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public string[] Descriptions;
}
