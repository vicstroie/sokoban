using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool touchedByPlayer;
    public bool movable;
    public Vector2Int currentPos;
    public Vector2Int nextPos;

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


    public void PosDebug()
    {
        Debug.Log(this.gameObject.tag + ": " + currentPos.x + ", " + currentPos.y);
    }
}
