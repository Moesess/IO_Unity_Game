using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid<TGridObject> {
    public const int HEAT_MAP_MAX_VALUE = 100;
    public const int HEAT_MAP_MIN_VALUE = 0;


    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs{
        public int x;
        public int y;
    }


    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;


    public Grid(
        int width, int height, float cellSize, Vector3 originPosition,
        Func<Grid<TGridObject>, int, int, TGridObject> createGridObject // Function creates grid object with its grid reference, x and y position, and the type of object
    ) {
        // Map grid constructor
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        
        for(int x = 0; x < gridArray.GetLength(0); x++){
            for(int y = 0; y < gridArray.GetLength(1); y++){
                gridArray[x, y] = createGridObject(this, x, y);
            }
        }

        bool showDebug = true;
        if(showDebug){
            TextMesh[,] debugTextArray = new TextMesh[width, height];

            for(int x = 0; x < gridArray.GetLength(0); x++){
                for(int y = 0; y < gridArray.GetLength(1); y++){
                    debugTextArray[x, y] = UtilsClass.CreateWorldText(
                        gridArray[x, y]?.ToString(),
                        null,
                        GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f,
                        30,
                        Color.white,
                        TextAnchor.MiddleCenter
                    );

                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

            OnGridObjectChanged += (object sender, OnGridObjectChangedEventArgs eventArgs) => {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }
    }

    public int GetWidth() {
        return this.width;
    }


    public int GetHeight() {
        return this.height;
    }


    public float GetCellSize() {
        return cellSize;
    }


    public Vector3 GetWorldPosition(int x, int y) {
        // Getter of single cell position in a grid
        return new Vector3(x, y) * cellSize + originPosition;
    }


    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        // Getter of world coordinates within a grid
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }


    public void SetGridObject(int x, int y, TGridObject value) {
        // Set Value of a Tile based on x and y coords within grid
        if(x >= 0 && y >= 0 && x < width && y < height){
            gridArray[x, y] = value;
            if(OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }
    }


    public void TriggerGridObjectChanged(int x, int y){
        if(OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
    }


    public void SetGridObject(Vector3 worldPosition, TGridObject value) {
        // Set Value of a Tile based on world position coords
        int x, y;
        GetXY(worldPosition, out x, out y);

        SetGridObject(x, y, value);
    }


    public TGridObject GetGridObject(int x, int y) {
        // Get Value of a Tile based on x and y coords within grid
        if(x >= 0 && y >= 0 && x < width && y < height){
            return gridArray[x, y];
        }else{
            return default(TGridObject);
        }
    }


    public TGridObject GetGridObject(Vector3 worldPosition) {
        // Get Value of a Tile based on world position coords
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }
}
