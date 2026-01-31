using UnityEngine;

[CreateAssetMenu(fileName = "TopType", menuName = "Attributes/TopType")]
public class TopType : ScriptableObject
{
    public string Name;

    public AnimatorOverrideController _animator;
}
