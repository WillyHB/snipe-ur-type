using UnityEngine;

[CreateAssetMenu(fileName = "BodyType", menuName = "Attributes/BodyType")]
public class BodyType : ScriptableObject
{
    public string Name;
    public bool IsFemale;
    public GameObject BodyPrefab;

    public string[] Descriptions;
    
}
