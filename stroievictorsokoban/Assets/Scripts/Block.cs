using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool touchedByPlayer;
    public bool movable;
    public Vector2Int currentPos;
    public bool canLeft;
    public bool canRight;
    public bool canUp;
    public bool canDown;

    // Start is called before the first frame update
    void Start()
    {
        touchedByPlayer = false;
        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
