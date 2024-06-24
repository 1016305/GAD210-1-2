using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShapeAndColorCombiner : MonoBehaviour
{
    Material[,] intArray = new Material[3, 3];
    [SerializeField] Material[] materialArray = new Material[6];
    GameObject[] shapesIn = new GameObject[2];
    [SerializeField] UnityEngine.Object[] allShapes = new GameObject[6];
    string[,] outShapes = new string[3, 3];
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

        shapeTable.Add(PuzzleObject.Shape.circle, 0);
        shapeTable.Add(PuzzleObject.Shape.square, 1);
        shapeTable.Add(PuzzleObject.Shape.triangle, 2);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (CheckForShapes(collision.gameObject))
        {
            ShapeLookUp(shapesIn[0].GetComponent<PuzzleObject>().GetShape(), shapesIn[1].GetComponent<PuzzleObject>().GetShape());
        }
    }
    void LoadShapesArray()
    {
        outShapes[0, 0] = "sphere";
        outShapes[0, 1] = "cylinder";
        outShapes[0, 2] = "cone";

        outShapes[1, 0] = "cylinder";
        outShapes[1, 1] = "cube";
        outShapes[1, 2] = "prism";

        outShapes[2, 0] = "cone";
        outShapes[2, 1] = "prism";
        outShapes[2, 2] = "pyramid";

        //get the shape enum from the input shape
        //dictionary labels enum as int
        //int checks the table
        //table identifies the correct complex shape?
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
        if (shapesIn[0] == null)
        {
            shapesIn[0] = shapeIn;
            return false;
        }
        else if (shapesIn[1] == null)
        {
            shapesIn[1] = shapeIn;
            return true;
        }
        else return false;
    }
    void ShapeLookUp(PuzzleObject.Shape shape1, PuzzleObject.Shape shape2)
    {
        // Take in shape enum
        int x;
        int y;
        shapeTable.TryGetValue(shape1, out x);
        shapeTable.TryGetValue(shape2, out y);
        // lookup index of shape
        // use that number as the index to pull a string
        Debug.Log(outShapes[x, y]);
    }
}
