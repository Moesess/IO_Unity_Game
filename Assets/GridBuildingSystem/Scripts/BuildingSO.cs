using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuildingSO : ScriptableObject{
    int level;
    int currentBuildCost;

    public int getLevel(){
        return level;
    }
}
