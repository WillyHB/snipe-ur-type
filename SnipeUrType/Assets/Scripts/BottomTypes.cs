using UnityEngine;

[CreateAssetMenu(fileName = "BottomTypes", menuName = "Attribute Collectors/BottomTypes")]
public class BottomTypes : ScriptableObject
{
    public BottomType[] Types;

    public BottomType GetRandom() => Types[Random.Range(0, Types.Length)];
}
