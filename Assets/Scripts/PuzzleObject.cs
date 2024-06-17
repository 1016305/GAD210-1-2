using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class PuzzleObject : MonoBehaviour
{
    
    public enum shape {circle, square, triangle}
    [SerializeField] private bool grabbable = true;
    [SerializeField] private shape sh;
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
    public shape GetShape()
    {
        return sh;
    }
}
