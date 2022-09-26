using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClickButton : MonoBehaviour
{
    public Button restartButton;
    public string sceneName;

    void Start() {
        restartButton.onClick.AddListener(Restart);
    }

    void Restart()
    {
        Time.timeScale = 1;
        GameObject.Find("SummaryWindowCanvas").GetComponent<Canvas>().enabled = false;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

}
