using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    [SerializeField] private bool grabbable = true;
    [SerializeField] int shapeID;
    public int GetShapeID()
    {
        return shapeID;
    }
    public void SetGrabbale()
    {
        grabbable = false;
    }
    public bool GetGrabbale()
    {
        return grabbable;
    }
}
