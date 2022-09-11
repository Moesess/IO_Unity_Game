using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class UISelectBuildings : MonoBehaviour{

    private Dictionary<GridPlacedObjectSO, Transform> gridPlacedObjectTransformDic;
    private bool active;
    Transform buttonsTransform;

    private void Awake() {
        gridPlacedObjectTransformDic = new Dictionary<GridPlacedObjectSO, Transform>();
        buttonsTransform = transform.Find("BuildingButtons");

        gridPlacedObjectTransformDic[GridBuildingSystemAssets.Instance.house] = buttonsTransform.Find("HouseBTN");
        gridPlacedObjectTransformDic[GridBuildingSystemAssets.Instance.mansion] = buttonsTransform.Find("MansionBTN");
        
        this.active = false;

        foreach (GridPlacedObjectSO gridPlacedObjectSO in gridPlacedObjectTransformDic.Keys) {
            gridPlacedObjectTransformDic[gridPlacedObjectSO].GetComponent<Button_UI>().ClickFunc = () => {
                GridBuildingSystem.Instance.SelectPlacedObjectSO(gridPlacedObjectSO);
            };

            // gridPlacedObjectTransformDic[gridPlacedObjectSO].gameObject.SetActive(active);
        }

        // transform.Find("BuildPanel").gameObject.SetActive(active);
    }

    private void Start() {
        GridBuildingSystem.Instance.OnSelectedChanged += GridBuildingSystem_OnSelectedChanged;

        RefreshSelectedVisual();
    }

    private void GridBuildingSystem_OnSelectedChanged(object sender, System.EventArgs e){
        RefreshSelectedVisual();
    }

    private void RefreshSelectedVisual(){
        foreach (GridPlacedObjectSO gridPlacedObjectSO in gridPlacedObjectTransformDic.Keys) {
            gridPlacedObjectTransformDic[gridPlacedObjectSO].Find("Background").gameObject.SetActive(
                GridBuildingSystem.Instance.GetGridPlacedObjectSO() == gridPlacedObjectSO
            );
        }
    }

    public void ToggleBuildingMenu(){
        active = !active;
        
        if(active)
            transform.GetComponent<Animation>().Play("Rise");
        else 
            transform.GetComponent<Animation>().Play("Down");

        // backgroundPanel.SetActive(active);
    }
}


