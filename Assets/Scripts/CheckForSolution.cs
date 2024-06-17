using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSolution : MonoBehaviour
{
    int noOfSolutions = 3;
    List<bool> success = new List<bool>();

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
        }
    }
}
