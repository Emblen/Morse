using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichScene : MonoBehaviour
{

    public string NextScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }

    public void OverlapScene()
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Additive);
    }
}
