using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Block
{



    // Start is called before the first frame update
    void Start()
    {
        base.currentPos = this.gameObject.GetComponent<GridObject>().gridPosition;
        base.touchedByPlayer = true;
    }


    // Update is called once per frame
    void LateUpdate()
    {

        if (currentPos.y == 1) base.cantUp = true; else base.cantUp = false;
        if (currentPos.y == 5) base.cantDown = true; else base.cantDown = false;
        if (currentPos.x == 1) base.cantLeft = true; else base.cantLeft = false;
        if (currentPos.x == 10) base.cantRight = true; else base.cantRight = false;



        if (Input.GetKeyDown(KeyCode.W))
        {
            //&& (Manager.reference.pos[3].y != currentPos.y - 1 && Manager.reference.pos[3].x != currentPos.x)

            for(int i = 0; i < 4; i++) {
               if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1)
                {
                    if (Manager.reference.blocks[i].GetComponent<Block>().cantUp) base.cantUp = true;
                }
            }

            if (!base.cantUp)  base.currentPos.y--;
            //prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.S) )
        {
            for (int i = 0; i < 4; i++)
            {
                if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y + 1)
                {
                    if (Manager.reference.blocks[i].GetComponent<Block>().cantDown) base.cantDown = true;
                }
            }
            //&& (Manager.reference.pos[3].y != currentPos.y + 1 && Manager.reference.pos[3].x != currentPos.x)
            if (!base.cantDown) base.currentPos.y++;
            //prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.A) )
        {
            //&& (Manager.reference.pos[3].y != currentPos.y && Manager.reference.pos[3].x != currentPos.x - 1)
            for (int i = 0; i < 4; i++)
            {
                if (Manager.reference.pos[i].x == base.currentPos.x - 1 && Manager.reference.pos[i].y == base.currentPos.y)
                {
                    if (Manager.reference.blocks[i].GetComponent<Block>().cantLeft) base.cantLeft = true;
                }
            }


            if (!base.cantLeft) base.currentPos.x--;
            //prevPos = currentPos;
        }

        if (Input.GetKeyDown(KeyCode.D) )
        {
            //&& (Manager.reference.pos[3].y != currentPos.y && Manager.reference.pos[3].x != currentPos.x + 1)
            for (int i = 0; i < 4; i++)
            {
                if (Manager.reference.pos[i].x == base.currentPos.x + 1 && Manager.reference.pos[i].y == base.currentPos.y)
                {
                    if (Manager.reference.blocks[i].GetComponent<Block>().cantRight) base.cantRight = true;
                }
            }

            if (!base.cantRight) base.currentPos.x++;
            //prevPos = currentPos;
        }

        this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;
    }
}
