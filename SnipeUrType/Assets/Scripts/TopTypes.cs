using UnityEngine;

[CreateAssetMenu(fileName = "TopTypes", menuName = "Attribute Collectors/TopTypes")]
public class TopTypes : ScriptableObject
{
    public TopType[] Types;

    public TopType GetRandom() => Types[Random.Range(0, Types.Length)];
}
