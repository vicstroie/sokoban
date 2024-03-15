using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Block
{
    
    // Start is called before the first frame update
    void Start()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        base.canUp = false;
        base.canDown = false;
        base.canLeft = false;
        base.canRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
    }
}
