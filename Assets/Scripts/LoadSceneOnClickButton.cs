using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClickButton : MonoBehaviour
{
    public Button button;
    public string sceneName;

    void Start() {
        button.onClick.AddListener(Load);
    }

    void Load()
    {
        if (SceneManager.GetActiveScene().name == "FightScene"){
            Time.timeScale = 1;
            GameObject.Find("SummaryWindowCanvas").GetComponent<Canvas>().enabled = false;
        }
        
        Debug.Log(transform.name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

}
