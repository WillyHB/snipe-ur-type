using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "BottomType", menuName = "Attributes/BottomType")]
public class BottomType : ScriptableObject
{
    public string Name;

    public string[] Descriptions;

    public AnimatorController _animator;
}
