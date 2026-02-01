using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "BodyType", menuName = "Attributes/BodyType")]
public class BodyType : ScriptableObject
{
    public string Name;
    public GameObject BodyPrefab;
    public AudioClip AudioComment;

    public string[] Descriptions;

    public RuntimeAnimatorController _animator;
}
