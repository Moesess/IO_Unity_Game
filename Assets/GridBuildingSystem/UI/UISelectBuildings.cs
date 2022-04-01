using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class UISelectBuildings : MonoBehaviour{
    private void Awake() {
       transform.Find("House").GetComponent<Button_UI>().ClickFunc = () => {
        //    GridBuildingSystem.
       };
        
    }
}
