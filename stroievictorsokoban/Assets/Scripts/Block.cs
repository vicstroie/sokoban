using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool touchedByPlayer;
    public bool movable;
    public Vector2Int currentPos;
    public bool cantLeft;
    public bool cantRight;
    public bool cantUp;
    public bool cantDown;

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
