using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool touchedByPlayer;
    public Vector2Int currentPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
    }
}
