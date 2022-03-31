using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridBuildingSystem : MonoBehaviour{
    [SerializeField] private GridPlacedObjectSO gridPlacedObject;
    private GridXZ<GridObject> grid;

    private void Awake() {
        // Set default grid sizes and create new grid instance
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
    }

    public class GridObject {
        // Object populating the grid, eg. building, tree. One per grid cell.
        private GridXZ<GridObject> grid;
        private int x;
        private int z;
        private Transform transform;

        public GridObject(GridXZ<GridObject> grid, int x, int z){
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public override string ToString()
        {
            return x + ", " + z + "\n" + transform;
        }

        
        public void SetTransform(Transform transform){
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, z);
        }

        public void ClearTransform(){
            this.transform = null;
            grid.TriggerGridObjectChanged(x, z);
        }

        public bool CanBuild(){
            return transform == null;
        }
    }


    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            grid.GetXZ(Mouse3D.GetMouseWorldPosition(), out int x, out int z);

            List<Vector2Int> gridPosList = gridPlacedObject.GetGridPositionList(new Vector2Int(x, z));
            GridObject gridObject = grid.GetGridObject(x, z);

            bool canBuild = true;
            foreach(Vector2Int gridPos in gridPosList){ // Check if whole area that object occupies is buildable
                if(!grid.GetGridObject(gridPos.x, gridPos.y).CanBuild()){
                    canBuild = false;
                    break;
                }
            }

            if(canBuild){ // If subgrid is buildable, instantiate every single one with scriptable object transform
                Transform buildTransform = Instantiate(gridPlacedObject.prefab, grid.GetWorldPosition(x,z), Quaternion.identity);

                foreach(Vector2Int gridPos in gridPosList){
                    grid.GetGridObject(gridPos.x, gridPos.y).SetTransform(buildTransform);
                } 

            } else {
                UtilsClass.CreateWorldTextPopup("Miejsce zajęte", Mouse3D.GetMouseWorldPosition());
            }
        }
    }
}
