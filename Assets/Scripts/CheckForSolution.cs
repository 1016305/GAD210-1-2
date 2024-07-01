using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForSolution : MonoBehaviour
{
<<<<<<< Updated upstream
    public UIManager UIRef;
    public int noOfSolutions = 3;
    public List<bool> success = new List<bool>();
=======
    int noOfSolutions = 3;
    List<bool> success = new List<bool>();
    SceneManager sceneManager;
    public int nextSceneNum;
>>>>>>> Stashed changes

    public void AddSuccess()
    {
        success.Add(true);
        CheckSuccess();

    }
    private void CheckSuccess()
    {
        if (success.Count == noOfSolutions)
        {
<<<<<<< Updated upstream
            Debug.Log("Finish");
            UIRef.PuzzleFinished();
=======
            SceneManager.LoadScene(nextSceneNum);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
>>>>>>> Stashed changes
        }
    }
}
