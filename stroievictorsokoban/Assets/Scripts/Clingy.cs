using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clingy : Block
{
   
    Vector2Int playerPos;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        base.touchedByPlayer = false;
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        //player = Manager.reference.player;
    }

    // Update is called once per frame
    void Update()
    {

        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;

        if (currentPos.y == 1) base.cantUp = true; else base.cantUp = false;
        if (currentPos.y == 5) base.cantDown = true; else base.cantDown = false;
        if (currentPos.x == 1) base.cantLeft = true; else base.cantLeft = false;
        if (currentPos.x == 10) base.cantRight = true; else base.cantRight = false;


        playerPos = player.GetComponent<Player>().currentPos;
        if ((playerPos.x == base.currentPos.x + 1 && playerPos.y == base.currentPos.y)
            || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y + 1)
            || (playerPos.x == base.currentPos.x - 1 && playerPos.y == base.currentPos.y)
            || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y - 1))


        {
            base.touchedByPlayer = true;
        }
        else
        {
            base.touchedByPlayer = false;
        }



        if ((playerPos.y == base.currentPos.y - 1 && playerPos.x == base.currentPos.x))
        {
            base.cantDown = true;
            if (!base.cantUp && Input.GetKeyDown(KeyCode.W)) base.currentPos.y--;
        }

        if ((playerPos.y == base.currentPos.y + 1 && playerPos.x == base.currentPos.x))
        {
            base.cantUp = true;
            if (!base.cantDown && Input.GetKeyDown(KeyCode.S)) base.currentPos.y++;
        }

        if ((playerPos.y == base.currentPos.y && playerPos.x == base.currentPos.x - 1))
        {
            base.cantRight = true;
            //Debug.Log("PRIGHT");
            if (!base.cantLeft && Input.GetKeyDown(KeyCode.A)) base.currentPos.x--;
        }

        if ((playerPos.y == base.currentPos.y && playerPos.x == base.currentPos.x + 1))
        {
            base.cantLeft = true;
            if (!base.cantRight && Input.GetKeyDown(KeyCode.D)) base.currentPos.x++;
            //Debug.Log("PLEFT");
        }




        this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;


    }
}
