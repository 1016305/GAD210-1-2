using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
public class PuzzleObject : MonoBehaviour
{
    public bool isComplex;
    public enum Shape {circle, square, triangle}
    [SerializeField] private bool grabbable = true;
    [SerializeField] private Shape sh;
    [SerializeField] int shapeID;
    [SerializeField] int materialID;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public int GetShapeID()
    {
        return shapeID;
    }
    public void SetGrabbale(bool grab)
    {
        grabbable = grab;
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
    public bool GetComplexShape()
    {
        return isComplex;
    }
    public void ReturnToStart()
    {
        transform.position = startPos;
    }
    public void SetMaterialID(int matID)
    {
        materialID = matID;
    }
    public int GetMaterialID()
    {
        return materialID;
    }

}
