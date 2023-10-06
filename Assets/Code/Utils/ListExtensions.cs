using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static T GetRandom<T>(this List<T> array) => array.Count == 0 ? default : array[Random.Range(0, array.Count)];
}