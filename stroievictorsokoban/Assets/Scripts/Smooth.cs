using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Smooth : Block
{
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



        if (Input.GetKeyDown(KeyCode.W))
        {

            canUp = CheckUp();

            prevPos = base.currentPos;
            if (base.canUp) base.currentPos.y--;
            move = true;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {


            canDown = CheckDown();

            prevPos = base.currentPos;
            if (base.canDown) base.currentPos.y++;
            move = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            canLeft = CheckLeft();

            prevPos = base.currentPos;
            if (base.canLeft) base.currentPos.x--;
            move = true;

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            canRight = CheckRight();

            prevPos = base.currentPos;
            if (base.canRight) base.currentPos.x++;
            move = true;
           
          
        }


    }

    private void LateUpdate()
    {
        if (move)
        {
            Manager.reference.blockArray[prevPos.x, prevPos.y] = null;
            this.gameObject.GetComponent<GridObject>().gridPosition = base.currentPos;
            move = false;
        }
    }


    public bool CheckUp()
    {
        if (currentPos.y == 1 || currentPos.y == 5)
        {
            return false;
        }
        else
        {
            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];


            if (upblock == null)
            {
                if(downblock == null)
                {
                    return false;
                }
                else if (downblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (downblock.CompareTag("player"))
                {
                    return true;
                }
                else if (downblock.CompareTag("sticky"))
                {   //come back, unless sticky can't moove for some other reason
                    return downblock.GetComponent<Block>().canUp;
                }
                else if (downblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    return true;
                }

            }
            else
            {
                if (upblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (upblock.CompareTag("player"))
                {
                    return false;
                }
                else if (upblock.CompareTag("sticky"))
                {
                    return upblock.GetComponent<Block>().canUp;
                }
                else if (upblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    return upblock.GetComponent<Smooth>().CheckUp();
                }
            }

        }
    }


   


    public bool CheckDown()
    {
        if (currentPos.y == 5 || currentPos.y == 1)
        {
            return false;
        }
        else
        {
            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];


            if (downblock == null)
            {
                if(upblock == null)
                {
                    return false;
                }
                else if (upblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (upblock.CompareTag("player"))
                {
                    return true;
                }
                else if (upblock.CompareTag("sticky"))
                {   //come back, unless sticky can't moove for some other reason
                    return upblock.GetComponent<Block>().canDown;
                }
                else if (upblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    return true;
                }

            }
            else
            {
                if (downblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (downblock.CompareTag("player"))
                {
                    return false;
                }
                else if (downblock.CompareTag("sticky"))
                {
                    /*
                    if(downblock.CompareTag("player"))
                    {

                    } else
                    {

                    }
                    */
                    return downblock.GetComponent<Block>().canDown;
                }
                else if (downblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    return downblock.GetComponent<Smooth>().CheckDown();
                }
            }

        }
    }




    public bool CheckLeft()
    {
        if (currentPos.x == 1 || currentPos.x == 10)
        {
            return false;
        }
        else
        {

            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];   


            if (leftblock == null)
            {
                if(rightblock == null)
                {
                    return false;
                } else if (rightblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (rightblock.CompareTag("player"))
                {
                    return true;
                }
                else if (rightblock.CompareTag("sticky"))
                {   //come back, unless sticky can't moove for some other reason
                    return rightblock.GetComponent<Block>().canLeft;
                }
                else if (rightblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    return true;
                }

            }
            else
            {
                if (leftblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (leftblock.CompareTag("player"))
                {
                    return false;
                }
                else if (leftblock.CompareTag("sticky"))
                {
                    return leftblock.GetComponent<Block>().canLeft;
                }
                else if (leftblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    return false;
                }
            }

        }
    }


    public bool CheckRight()
    {
        if (currentPos.x == 10 || currentPos.x == 1)
        {
            return false;
        }
            else
            {
                GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];
                GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];



            
                if (rightblock == null)
                {
                    if(leftblock == null)
                    {
                        return false;
                    }
                    else if(leftblock.CompareTag("clingy"))
                    {
                        return false;
                    }
                    else if (leftblock.CompareTag("player"))
                    {
                        return true;
                    }
                    else if (leftblock.CompareTag("sticky"))
                    {   //come back, unless sticky can't moove for some other reason
                        return rightblock.GetComponent<Block>().canRight;
                    }
                    else if (leftblock.CompareTag("wall"))
                    {
                        return false;
                    }
                    else //smooth
                    {
                        return false;
                    }

                }
                else
                {
                    if (rightblock.CompareTag("clingy"))
                    {
                        return false;
                    }
                    else if (rightblock.CompareTag("player"))
                    {
                        return false;
                    }
                    else if (rightblock.CompareTag("sticky"))
                    {
                        return rightblock.GetComponent<Block>().canRight;
                    }
                    else if (rightblock.CompareTag("wall"))
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }

        }
    }
}
