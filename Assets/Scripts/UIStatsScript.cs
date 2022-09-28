using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatsScript : MonoBehaviour
{
    private bool active;

    private void Awake() {
        this.active = false;    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleStatsMenu(){
        this.active = !this.active;

        if(this.active)
            transform.GetComponent<Animation>().Play("SlideIn");
        else 
            transform.GetComponent<Animation>().Play("SlideOut");
    }
}
