using UnityEngine;

[CreateAssetMenu(fileName = "TopType", menuName = "Attributes/TopType")]
public class TopType : ScriptableObject
{
    public string Name;

    public string[] Descriptions;

    public bool Male, Female;

    public RuntimeAnimatorController _animator;
}
