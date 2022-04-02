using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class UISelectBuildings : MonoBehaviour{

    private Dictionary<GridPlacedObjectSO, Transform> gridPlacedObjectTransformDic;

    private void Awake() {
        gridPlacedObjectTransformDic = new Dictionary<GridPlacedObjectSO, Transform>();

        gridPlacedObjectTransformDic[GridBuildingSystemAssets.Instance.house] = transform.Find("HouseBTN");
        gridPlacedObjectTransformDic[GridBuildingSystemAssets.Instance.mansion] = transform.Find("MansionBTN");

        foreach (GridPlacedObjectSO gridPlacedObjectSO in gridPlacedObjectTransformDic.Keys) {
            gridPlacedObjectTransformDic[gridPlacedObjectSO].GetComponent<Button_UI>().ClickFunc = () => {
                GridBuildingSystem.Instance.SelectPlacedObjectSO(gridPlacedObjectSO);
            };
        }
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
}


