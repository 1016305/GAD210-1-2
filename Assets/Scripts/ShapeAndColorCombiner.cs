using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShapeAndColorCombiner : MonoBehaviour
{
    Material[,] intArray = new Material[3, 3];
    public bool isBothColorAndShape;
    [SerializeField] Material[] materialArray = new Material[6];
    public GameObject[] shapesIn = new GameObject[2];
    [SerializeField] UnityEngine.Object[] allShapes = new GameObject[6];
    UnityEngine.Object[,] outShapes = new UnityEngine.Object[3, 3];
    //dictionary converts complexshape to object
    //Guide for shapes!

    //         |   Circle    |    Square   |    Triangle
    //-----------------------|-------------|---------------
    //Circle   |    Sphere   |   Cylinder  |     Cone
    //Square   |   Cylinder  |     Cube    |     Prism
    //Triangle |     Cone    |    Prism    |    Pyramid

    //Allshapes array key
    //1 Circle
    //2 Square
    //3 Triangle
    //4 Sphere
    //5 Cylinder
    //6 Cone
    //7 Cube
    //8 Prism
    //9 Pyramid  


    Dictionary<PuzzleObject.Shape, int> shapeTable = new Dictionary<PuzzleObject.Shape, int>();
    private void Start()
    {
        LoadShapesArray();
        LoadColoursArray();
        shapeTable.Add(PuzzleObject.Shape.circle, 0);
        shapeTable.Add(PuzzleObject.Shape.square, 1);
        shapeTable.Add(PuzzleObject.Shape.triangle, 2);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (CheckForShapes(collision.gameObject))
        {
            ShapeLookUp(shapesIn[0].GetComponent<PuzzleObject>().GetShape(), shapesIn[1].GetComponent<PuzzleObject>().GetShape());
            ReloadShapes();
        }
    }
    void LoadShapesArray()
    {
        outShapes[0, 0] = allShapes[0];
        outShapes[0, 1] = allShapes[4];
        outShapes[0, 2] = allShapes[5];

        outShapes[1, 0] = allShapes[4];
        outShapes[1, 1] = allShapes[1];
        outShapes[1, 2] = allShapes[3];

        outShapes[2, 0] = allShapes[5];
        outShapes[2, 1] = allShapes[3];
        outShapes[2, 2] = allShapes[2];
    }
    void LoadColoursArray()
    {
        intArray[0, 0] = materialArray[0];
        intArray[0, 1] = materialArray[4];
        intArray[0, 2] = materialArray[5];

        intArray[1, 0] = materialArray[4];
        intArray[1, 1] = materialArray[1];
        intArray[1, 2] = materialArray[3];

        intArray[2, 0] = materialArray[5];
        intArray[2, 1] = materialArray[3];
        intArray[2, 2] = materialArray[2];
    }
    bool CheckForShapes(GameObject shapeIn)
    {
        if (shapeIn.GetComponent<PuzzleObject>().isComplex == true)
        {
            return false;
        }
        else
        {
            if (shapesIn[0] == null)
            {
                shapesIn[0] = shapeIn;
                shapeIn.GetComponent<PuzzleObject>().SetGrabbale(false);
                return false;
            }
            else if (shapesIn[1] == null)
            {
                shapesIn[1] = shapeIn;
                shapeIn.GetComponent<PuzzleObject>().SetGrabbale(false);
                
                return true;
            }
            else return false;
        }
    }
    void ShapeLookUp(PuzzleObject.Shape shape1, PuzzleObject.Shape shape2)
    {
        // Take in shape enum
        int x;
        int y;
        int colorX;
        int colorY;

        if (!isBothColorAndShape)
        {
            GameObject newShape;

            shapeTable.TryGetValue(shape1, out x);
            shapeTable.TryGetValue(shape2, out y);
            newShape = Instantiate(outShapes[x, y]) as GameObject;
            newShape.GetComponent<MeshCollider>().convex = true;
        }
        else if (isBothColorAndShape)
        {
            GameObject newShape;
            Material newMat;

            colorX = shapesIn[0].GetComponent<PuzzleObject>().GetShapeID();
            colorY = shapesIn[0].GetComponent<PuzzleObject>().GetShapeID();
            newMat = intArray[colorX, colorY];
            shapeTable.TryGetValue(shape1, out x);
            shapeTable.TryGetValue(shape2, out y);
            newShape = Instantiate(outShapes[x, y]) as GameObject;
            newShape.GetComponent<MeshCollider>().convex = true;
            newShape.GetComponent<Renderer>().material = newMat;
        }
    }
    void ReloadShapes()
    {
        GameObject reloadShape1;
        GameObject reloadShape2;
        Destroy(shapesIn[0]);
        Destroy(shapesIn[1]);
        reloadShape1 = Instantiate(shapesIn[0], new Vector3(-3.5f, 0f, 0f), Quaternion.identity);
        reloadShape2 = Instantiate(shapesIn[1], new Vector3(3.5f, 0f, 0f), Quaternion.identity);
        reloadShape1.GetComponent<PuzzleObject>().SetGrabbale(true);
        reloadShape2.GetComponent<PuzzleObject>().SetGrabbale(true);
        reloadShape1.transform.rotation = Quaternion.Euler(90f, 0, 0);
        reloadShape2.transform.rotation = Quaternion.Euler(90f, 0, 0);
        shapesIn[0] = null;
        shapesIn[1] = null;
    }
}
