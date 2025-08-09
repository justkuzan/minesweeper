using UnityEngine;

public struct Cell
{
    public enum Type
    {
        Empty,
        Mine,
        Number
    }

    public Vector3Int position;
    public Type type;
    public int number;
    public bool isRevealed;
    public bool isFlagged;
    public bool isExploded;
}