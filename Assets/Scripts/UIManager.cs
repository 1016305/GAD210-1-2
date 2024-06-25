using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button nextButton;
    public int sceneIndex;
    //SceneSearch 
    // Start is called before the first frame update
    void Start()
    {
        nextButton.enabled = true;
        nextButton.gameObject.SetActive(false);
    }
    public void PuzzleFinished()
        
    {
        nextButton.gameObject.SetActive(true);
        Debug.Log(nextButton.isActiveAndEnabled);
    }
    public void GoToNextScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(sceneIndex);
        
    }

}
