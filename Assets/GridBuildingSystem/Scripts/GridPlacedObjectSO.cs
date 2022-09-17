using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GridPlacedObjectSO : ScriptableObject{
    // Creates eg. building that we can place on grid.
    public string nameString;
    public Transform prefab;
    public int width;
    public int height;

    public List<Vector2Int> GetGridPositionList(Vector2Int offset){
        // Method used for calculating nearby tiles that building occupies
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                gridPositionList.Add(offset + new Vector2Int(x, y));
            }
        }

        return gridPositionList;
    }
}
