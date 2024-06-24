using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class PuzzleObject : MonoBehaviour
{
    
    public enum Shape {circle, square, triangle}
    public enum ComplexShape { sphere, cone, cylinder, cube, prism, pyramid}
    [SerializeField] private bool grabbable = true;
    [SerializeField] private Shape sh;
    [SerializeField] private ComplexShape csh;
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
    public Shape GetShape()
    {
        return sh;
    }
    public void SetShapeID(int x)
    {
        shapeID = x;
    }
    public void SetComplexShapeEnum(ComplexShape e)
    {
        csh = e;
    }

}
