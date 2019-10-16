using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour
{
    public GameObject quitScreen;

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CloseGame()
    {
        quitScreen.SetActive(true);
        StartCoroutine(QuitWaiter());
    }

    IEnumerator QuitWaiter()
    {
        yield return new WaitForSeconds(2.5f);
        Application.Quit();
    }
}
