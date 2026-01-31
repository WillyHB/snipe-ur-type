using UnityEngine;

[CreateAssetMenu(fileName = "BodyType", menuName = "Attributes/BodyType")]
public class BodyType : ScriptableObject
{
    public string Name;
    public GameObject BodyPrefab;

    public string[] Descriptions;

    public AnimatorOverrideController _animator;
}
