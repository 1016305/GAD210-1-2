using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorCombiner : MonoBehaviour
{
    [SerializeField] GameObject[] coloursToCombine = new GameObject[2];
    [SerializeField] UnityEngine.Object shapePrefab;
    Material material;
    Material orangeMaterial;
    Material purpleMaterial;
    Material greenMaterial;

    GameObject newShape;

    private void OnTriggerEnter(Collider other)
    {
        if (coloursToCombine[0] == null)
        {
            coloursToCombine[0] = other.gameObject;
            coloursToCombine[1] = null;
        }
        else if (coloursToCombine[0] != null)
        {
            coloursToCombine[1] = other.gameObject;
        }

        if (coloursToCombine[0] != null && coloursToCombine[1] != null)
        {
            char firstInt = coloursToCombine[0].GetComponent<Renderer>().material.name[0];
            string firstinter = firstInt.ToString();
            char secondInt = coloursToCombine[1].GetComponent<Renderer>().material.name[0];
            string secondinter = secondInt.ToString();
            Debug.Log(Convert.ToInt32(firstinter));
            Debug.Log(Convert.ToInt32(secondinter));
            Debug.Log(Convert.ToInt32(firstinter) + "" + Convert.ToInt32(secondinter));

            newShape = Instantiate(shapePrefab, Vector3.zero, Quaternion.identity) as GameObject;
            //Debug.Log("Assets/Materials/" + Convert.ToInt32(firstinter) + Convert.ToInt32(secondinter) + ".mat");
            string fileToLoad = "Assets/Materials/" + Convert.ToInt32(firstinter) + Convert.ToInt32(secondinter) + ".mat";
            Debug.Log(fileToLoad);
            material = Resources.Load<Material>(fileToLoad);
            //newShape.AddComponent<Material>();
            newShape.GetComponent<Renderer>().material = material;

            Destroy(coloursToCombine[0]);
            Destroy(coloursToCombine[1]);
        }
    }
}
