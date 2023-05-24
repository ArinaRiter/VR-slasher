using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    [SerializeField] private AudioSource audio;

    //public void LoadScene(int sceneId)
    //{
    //    StartCoroutine(LoadSceneAsync(sceneId));
    //}

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
    public void StartBtn(int sceneId)
    {
        //SceneManager.LoadScene("Grey Box");
        audio.Play();
        StartCoroutine(LoadSceneAsync(sceneId));//
    }

    public void ExitBtn()
    {
        audio.Play();
        Application.Quit();
    }
}
