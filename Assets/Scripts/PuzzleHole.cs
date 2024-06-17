using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHole : MonoBehaviour
{
    [SerializeField] private int solutionID;
    Camera cam;
    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PuzzleObject>().GetShapeID() == solutionID)
        {
            collision.gameObject.GetComponent<PuzzleObject>().SetGrabbale();
            cam.GetComponent<CheckForSolution>().AddSuccess();
        }
    }
}
