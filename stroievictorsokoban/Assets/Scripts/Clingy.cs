using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clingy : Block
{
   
    Vector2Int playerPos;
    public GameObject player;

    Vector2Int prevPos;
    bool move;


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


        if (Input.GetKeyDown(KeyCode.W))
        {


            if (CheckUp())
            {
                nextPos.y = currentPos.y - 1;
                nextPos.x = currentPos.x;
                move = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            if (CheckDown())
            {

                nextPos.y = currentPos.y + 1;
                nextPos.x = currentPos.x;
                move = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CheckLeft())
            {

                nextPos.x = currentPos.x - 1;
                nextPos.y = currentPos.y;
                move = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CheckRight())
            {
                nextPos.x = currentPos.x + 1;
                nextPos.y = currentPos.y;
                move = true;
            }

        }


    }

    private void LateUpdate()
    {
        //Maybe put this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos; here

        if (move)
        {
            Manager.reference.blockArray[currentPos.x, currentPos.y] = null;
            currentPos = nextPos;
            this.gameObject.GetComponent<GridObject>().gridPosition = currentPos;
            nextPos = Vector2Int.zero;
            move = false;
        }

    }


    public bool CheckUp()
    {
        if (currentPos.y == 1)
        {
            return false;
        }
        else
        {
            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];


            if (upblock == null)
            {
                return false;

            }
            
            
            if (upblock.CompareTag("smooth"))
            {
                return false;
            }
            else if (upblock.CompareTag("player"))
            {
                Debug.Log("HERE");
                return upblock.GetComponent<Player>().CheckUp();
            }
            else if (upblock.CompareTag("sticky"))
            {
                return upblock.GetComponent<Sticky>().CheckUp();
            }
            else if (upblock.CompareTag("wall"))
            {
                return false;
            }
            else //clingy
            {
                return upblock.GetComponent<Clingy>().CheckUp();
            }
            

        }
    }





    public bool CheckDown()
    {
        
        if (currentPos.y == 5)
        {
            return false;
        }
        else
        {
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];


            if (downblock == null)
            {
                return false;

            }
            else
            {
                if (downblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (downblock.CompareTag("player"))
                {
                    return downblock.GetComponent<Player>().CheckDown();
                }
                else if (downblock.CompareTag("sticky"))
                {
                    return downblock.GetComponent<Sticky>().CheckDown();
                }
                else if (downblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return downblock.GetComponent<Clingy>().CheckDown();
                }
            }

        }
    }




    public bool CheckLeft()
    {
        if (currentPos.x == 1)
        {
            return false;
        }
        else
        {

            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];


            if (leftblock == null)
            {
                return false;
            }
            else
            {
                if (leftblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (leftblock.CompareTag("player"))
                {
                    return leftblock.GetComponent<Player>().CheckLeft();
                }
                else if (leftblock.CompareTag("sticky"))
                {
                    return leftblock.GetComponent<Sticky>().CheckLeft();
                }
                else if (leftblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return leftblock.GetComponent<Clingy>().CheckLeft();
                }
            }

        }
    }


    public bool CheckRight()
    {
        if (currentPos.x == 10)
        {
            return false;
        }
        else
        {
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];


            if (rightblock == null)
            {
                return false;
            }
            else
            {
                if (rightblock.CompareTag("smooth"))
                {
                    return false;
                }
                else if (rightblock.CompareTag("player"))
                {
                    return rightblock.GetComponent<Player>().CheckRight();
                }
                else if (rightblock.CompareTag("sticky"))
                {
                    return rightblock.GetComponent<Sticky>().CheckRight();
                }
                else if (rightblock.CompareTag("wall"))
                {
                    return false;
                }
                else //clingy
                {
                    return rightblock.GetComponent<Clingy>().CheckRight();
                }
            }

        }
    }

}
