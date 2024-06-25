using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHole : MonoBehaviour
{
    [SerializeField] private int solutionID;
    bool isHit = false;
    Camera cam;
    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!isHit)
        {
            if (collision.gameObject.GetComponent<PuzzleObject>().GetShapeID() == solutionID)
            {
                collision.gameObject.GetComponent<PuzzleObject>().SetGrabbale(false);
                cam.GetComponent<CheckForSolution>().AddSuccess();
                isHit = true;

            }
        }
    }
}
