using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHole : MonoBehaviour
{
    [SerializeField] private int solutionID;
    [SerializeField] private int solutionMaterialID;
    bool isHit = false;
    [SerializeField] bool isBothColourAndShape;
    Camera cam;
    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!isHit && !isBothColourAndShape)
        {
            if (collision.gameObject.GetComponent<PuzzleObject>().GetShapeID() == solutionID && collision.gameObject.GetComponent<PuzzleObject>().GetComplexShape())
            {
                collision.gameObject.GetComponent<PuzzleObject>().SetGrabbale(false);
                cam.GetComponent<CheckForSolution>().AddSuccess();
                isHit = true;
                Debug.Log("Correct");
            }
        }
        else if (!isHit && isBothColourAndShape)
        {
            if (collision.gameObject.GetComponent<PuzzleObject>().GetShapeID() == solutionID && collision.gameObject.GetComponent<PuzzleObject>().GetComplexShape() && collision.gameObject.GetComponent<PuzzleObject>().GetMaterialID() == solutionMaterialID)
            {
                collision.gameObject.GetComponent<PuzzleObject>().SetGrabbale(false);
                cam.GetComponent<CheckForSolution>().AddSuccess();
                isHit = true;
                Debug.Log("Correct");
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 255);
            }
        }
    }
}
