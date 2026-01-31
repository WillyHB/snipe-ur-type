using UnityEngine;
using System;

public static class Helpers
{
    public static T GetRandom<T>(T[] arr) => arr[UnityEngine.Random.Range(0, arr.Length)];

}
