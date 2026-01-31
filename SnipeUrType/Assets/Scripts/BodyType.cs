using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyType", menuName = "Attributes/BodyType")]
public class BodyType : ScriptableObject
{
    public string Name;
    public bool IsFemale;
    public GameObject BodyPrefab;
    public AudioClip AudioComment;

    public string[] Descriptions;

    public AnimatorController _animator;
}
