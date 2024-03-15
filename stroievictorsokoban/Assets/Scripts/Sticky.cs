using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : Block
{

   
    Vector2Int playerPos;
    public GameObject player;

    public GameObject touching;


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

        if (currentPos.y == 1) base.canUp = false; else base.canUp = true;
        if (currentPos.y == 5) base.canDown = false; else base.canDown = true;
        if (currentPos.x == 1) base.canLeft = false; else base.canLeft = true;
        if (currentPos.x == 10) base.canRight = false; else base.canRight = true;


        playerPos = player.GetComponent<Player>().currentPos;

 

       //CheckIfTouched();
       // CheckIfMovable();
        
        /*

            if (Input.GetKeyDown(KeyCode.W))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantUp)
                        {
                            base.cantUp = true;
                        }
                        
                        if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1)
                        {
                            if (Manager.reference.touched[i]) touchedByPlayer = true;
                        }
                        

                     }
                }

                if (!base.cantUp && touchedByPlayer) base.currentPos.y--;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y + 1)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantDown) base.cantDown = true;
                     }


                    if (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1)
                    {
                        if (Manager.reference.touched[i]) touchedByPlayer = true;
                    }
            }

                if (!base.cantDown && touchedByPlayer) base.currentPos.y++;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                for (int i = 0; i < 5; i++)
                {
                         if (Manager.reference.pos[i].x == base.currentPos.x - 1 && Manager.reference.pos[i].y == base.currentPos.y)
                        {
                              if (Manager.reference.blocks[i].GetComponent<Block>().cantLeft) base.cantLeft = true;
                        }
                        if (Manager.reference.pos[i].x == base.currentPos.x + 1 && Manager.reference.pos[i].y == base.currentPos.y)
                        {
                              if (Manager.reference.touched[i]) touchedByPlayer = true;
                        }
            }


                if (!base.cantLeft && touchedByPlayer) base.currentPos.x--;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Manager.reference.pos[i].x == base.currentPos.x - 1 && Manager.reference.pos[i].y == base.currentPos.y)
                    {
                        if (Manager.reference.touched[i]) touchedByPlayer = true;
                    }

                    if (Manager.reference.pos[i].x == base.currentPos.x + 1 && Manager.reference.pos[i].y == base.currentPos.y)
                    {
                        if (Manager.reference.blocks[i].GetComponent<Block>().cantRight) base.cantRight = true;
                    }
                }

                if (!base.cantRight && touchedByPlayer) base.currentPos.x++;
            }
        */

        this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;


    }


    private void CheckIfMovable()
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            if (((Manager.reference.pos[i].x == base.currentPos.x + 1 && Manager.reference.pos[i].y == base.currentPos.y)
            || (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y + 1)
            || (Manager.reference.pos[i].x == base.currentPos.x - 1 && Manager.reference.pos[i].y == base.currentPos.y)
            || (Manager.reference.pos[i].x == base.currentPos.x && Manager.reference.pos[i].y == base.currentPos.y - 1))
            && Manager.reference.touched[i])
            {
                base.touchedByPlayer = true;
                count++;
                Debug.Log("touched!");
            }
        }

        if (count == 0)
        {
            base.touchedByPlayer = false;
        }

    }

    private void CheckIfTouched()
    {
        if (((playerPos.x == base.currentPos.x + 1 && playerPos.y == base.currentPos.y)
           || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y + 1)
           || (playerPos.x == base.currentPos.x - 1 && playerPos.y == base.currentPos.y)
           || (playerPos.x == base.currentPos.x && playerPos.y == base.currentPos.y - 1)))
        {

            touchedByPlayer = true;

        } else
        {
            touchedByPlayer = false;
        }
    }


}
