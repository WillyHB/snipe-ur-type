using UnityEngine;

[CreateAssetMenu(fileName = "ShoeTypes", menuName = "Attribute Collectors/ShoesTypes")]
public class ShoeTypes : ScriptableObject
{
    public ShoeType[] Types;

    public ShoeType GetRandom() => Types[Random.Range(0, Types.Length)];
}
