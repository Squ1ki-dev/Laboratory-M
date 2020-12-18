using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [Header("Loading Scenes")]
    public  int sceneID;
    [Header("Other Obeject")]
    [SerializeField] private Image loadingImg;
    [SerializeField] private Text progressText;

    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        while(!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            progressText.text = string.Format("{0:0}%", progress * 100);
            loadingImg.fillAmount = progress;
            yield return null;
        }
    }
}
