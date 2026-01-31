using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "TopType", menuName = "Attributes/TopType")]
public class TopType : ScriptableObject
{
    public string Name;

    public string[] Descriptions;

    public AnimatorController _animator;
}
