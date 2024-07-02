using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForSolution : MonoBehaviour
{
    public UIManager UIRef;
    public int noOfSolutions = 3;
    public List<bool> success = new List<bool>();

    public void AddSuccess()
    {
        success.Add(true);
        CheckSuccess();

    }
    private void CheckSuccess()
    {
        if (success.Count == noOfSolutions)
        {
            Debug.Log("Finish");
            UIRef.PuzzleFinished();

        }
    }
}
