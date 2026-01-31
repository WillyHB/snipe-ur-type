using UnityEngine;

[CreateAssetMenu(fileName = "EyeTypes", menuName = "Attribute Collectors/EyeTypes")]
public class EyeTypes : ScriptableObject
{
    public EyeType[] Types;

    public EyeType GetRandom() => Types[Random.Range(0, Types.Length)];
}
