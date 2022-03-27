using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Testing : MonoBehaviour{   
    [SerializeField] private HeatMapVisual heatMapVisual;
    private Grid grid;

    // Start is called before the first frame update
    void Start(){
        grid = new Grid(150, 100, 6f, Vector3.zero);

        heatMapVisual.SetGrid(grid);
    }


    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
            
            grid.AddValue(mousePos, 100, 2, 25);
        }
    }
}
