using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Testing : MonoBehaviour{   
    // [SerializeField] private HeatMapGenericVisual heatMapGenericVisual;
    private Grid<HeatMapGridObject> grid;

    // Start is called before the first frame update
    void Start(){
        // grid = new Grid<HeatMapGridObject>(
        //     20, 10, 10f, Vector3.zero,
        //     (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));

        //heatMapVisual.SetGrid(grid);
        // heatMapBoolVisual.SetGrid(grid);
        // heatMapGenericVisual.SetGrid(grid);
    }


    private void Update() {
        // if(Input.GetMouseButtonDown(0)){
        //     Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
        //     HeatMapGridObject heatMapGridObject = grid.GetGridObject(mousePos);

        //     if(heatMapGenericVisual != null)
        //         heatMapGridObject.AddValue(5);
        // }
    }
}

public class HeatMapGridObject{
    private const int MIN = 0;
    private const int MAX = 100;

    private Grid<HeatMapGridObject> grid;
    private int x;
    private int y;
    private int value;
    
    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue){
        value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalized(){
        return (float)value / MAX;
    }

    public override string ToString(){
        return value.ToString();
    }
}
