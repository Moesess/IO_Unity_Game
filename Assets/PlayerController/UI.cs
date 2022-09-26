using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class UI : MonoBehaviour {
    private Text myText;
 
    int test = 0;
 
    void Update () {
        myText.text = "hehe";
 
        test++;
    }
}