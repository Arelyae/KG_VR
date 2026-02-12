using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_UI : MonoBehaviour
{
    //[Header("Settings")]
    //[Header("References")]
    //[Header("Input")]
    //[Header("Output")]

    private bool isLoading = false;

    public void RestartFight()
    {

    }

    public void NextFight()
    {

    }

    public void ResetGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        LoadLevel(currentScene.name);
    }

    private void LoadLevel(string sceneName)
    {
        if (isLoading) return;

        isLoading = true;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        StartCoroutine(Transition(operation));
    }

    private IEnumerator Transition(AsyncOperation operation)
    {
        yield return new WaitUntil(() => operation.isDone);

        isLoading = false;
    }
}