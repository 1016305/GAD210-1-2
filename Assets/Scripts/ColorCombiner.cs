using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorCombiner : MonoBehaviour
{
    Material[,] intArray = new Material[3, 3];
    [SerializeField] GameObject[] CubesIn = new GameObject[2];
    [SerializeField] UnityEngine.Object CubeShape;
    [SerializeField] Material[] materialArray = new Material[6];
    private void Start()
    {
        InitializeArray();
    }

    private void OnTriggerEnter(Collider other)
    {
        ReturnMaterial(other.gameObject);
    }
    void ReturnMaterial(GameObject cube)
    {
        if (CubesIn[0] == null)
        {
            CubesIn[0] = cube;
            Debug.Log("Cube 1 is in");
        }
        else if (CubesIn[1] == null)
        {
            CubesIn[1] = cube;
            Debug.Log("Cube 2 is in");
            if (CubesIn[1] != null && CubesIn[0] != null)
            {
                int x = CubesIn[0].GetComponent<PuzzleObject>().GetShapeID();
                int y = CubesIn[1].GetComponent<PuzzleObject>().GetShapeID();
                Debug.Log(intArray[x, y].name);
                Debug.Log(x + "" + y);
                CreateObjectWithMaterial(intArray[x, y]);
                ResetObject();
            }
        }
    }
    void InitializeArray()
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

        //ArrayGuide
        // 0 = Red
        // 1 = Blue
        // 2 = Yellow
        // 3 = Green
        // 4 = Purple
        // 5 = Orange
    }
    void CreateObjectWithMaterial(Material newMat)
    {
        GameObject newCube;
        newCube = Instantiate(CubeShape) as GameObject;
        newCube.GetComponent<Renderer>().material = newMat;
        Debug.Log(newMat);
        newCube.GetComponent<PuzzleObject>().SetShapeID(Array.IndexOf(materialArray, newMat));
    }
    void ResetObject()
    {

        CubesIn[0].gameObject.GetComponent<PuzzleObject>().ReturnToStart();
        CubesIn[1].gameObject.GetComponent<PuzzleObject>().ReturnToStart();

        CubesIn[0] = null;
        CubesIn[1] = null;
    }
}
