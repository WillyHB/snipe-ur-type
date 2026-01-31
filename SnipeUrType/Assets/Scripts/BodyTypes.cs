using UnityEngine;

[CreateAssetMenu(fileName = "BodyTypes", menuName = "Attribute Collectors/BodyTypes")]
public class BodyTypes : ScriptableObject
{
    public BodyType[] Types;

    public BodyType GetRandom() => Types[Random.Range(0, Types.Length)];
}
