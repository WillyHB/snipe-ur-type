using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "ShoeType", menuName = "Attributes/ShoeType")]
public class ShoeType : ScriptableObject
{
    public string Name;

    public string[] Descriptions;

    public bool Male, Female;

    public AnimatorController _animator;
}
