using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Block
{
    
    // Start is called before the first frame update
    void Start()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        base.cantUp = true;
        base.cantDown = true;
        base.cantLeft = true;
        base.cantRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
    }
}
