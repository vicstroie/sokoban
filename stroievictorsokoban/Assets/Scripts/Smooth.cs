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
                    //return downblock.GetComponent<Sticky>().CheckUp();
                    return downblock.GetComponent<Sticky>().CheckUp();
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
                    return false;
                }
                else if (upblock.CompareTag("sticky"))
                {

                    if(downblock == null) return upblock.GetComponent<Sticky>().CheckUp();
                    if (downblock.CompareTag("player"))
                    {
                        return upblock.GetComponent<Sticky>().CheckUp() && downblock.GetComponent<Player>().CheckUp();
                    }
                    else if (downblock.CompareTag("smooth"))
                    {
                        return upblock.GetComponent<Sticky>().CheckUp() && downblock.GetComponent<Smooth>().CheckUp();
                    }
                    else if (downblock.CompareTag("sticky"))
                    {
                        return upblock.GetComponent<Sticky>().CheckUp() && downblock.GetComponent<Sticky>().CheckUp();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (upblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    if (downblock.CompareTag("player"))
                    {
                        return upblock.GetComponent<Smooth>().CheckUp() && downblock.GetComponent<Player>().CheckUp();
                    }
                    else if (downblock.CompareTag("smooth"))
                    {
                        return upblock.GetComponent<Smooth>().CheckUp() && downblock.GetComponent<Smooth>().CheckUp();
                    }
                    else if (downblock.CompareTag("sticky"))
                    {
                        return upblock.GetComponent<Smooth>().CheckUp() && downblock.GetComponent<Sticky>().CheckUp();
                    }
                    else
                    {
                        return false;
                    }
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
                    return upblock.GetComponent<Sticky>().CheckDown();
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
            {   if(downblock == null)
                {
                    return false;
                }
                else if (downblock.CompareTag("clingy"))
                {
                    return false;
                }
                else if (downblock.CompareTag("player"))
                {
                    return false;
                }
                else if (downblock.CompareTag("sticky"))
                {
                    if(upblock == null)
                    {
                        return downblock.GetComponent<Sticky>().CheckDown();
                    }
                    if (upblock.CompareTag("player"))
                    {
                        return downblock.GetComponent<Sticky>().CheckDown() && upblock.GetComponent<Player>().CheckDown();
                    }
                    else if (downblock.CompareTag("smooth"))
                    {
                        return downblock.GetComponent<Sticky>().CheckDown() && upblock.GetComponent<Smooth>().CheckDown();
                    }
                    else if (downblock.CompareTag("sticky"))
                    {
                        return downblock.GetComponent<Sticky>().CheckDown() && upblock.GetComponent<Sticky>().CheckDown();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (downblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    if (upblock.CompareTag("player"))
                    {
                        return downblock.GetComponent<Smooth>().CheckDown() && upblock.GetComponent<Player>().CheckDown();
                    }
                    else if (downblock.CompareTag("smooth"))
                    {
                        return downblock.GetComponent<Smooth>().CheckDown() && upblock.GetComponent<Smooth>().CheckDown();
                    }
                    else if (downblock.CompareTag("sticky"))
                    {
                        return downblock.GetComponent<Smooth>().CheckDown() && upblock.GetComponent<Sticky>().CheckDown();
                    }
                    else
                    {
                        return false;
                    }
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
                    return rightblock.GetComponent<Sticky>().CheckLeft();
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
                if(rightblock == null)
                {
                    return false;
                }
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

                    if(rightblock == null) return leftblock.GetComponent<Sticky>().CheckLeft();
                    if (rightblock.CompareTag("player"))
                    {
                        return leftblock.GetComponent<Sticky>().CheckLeft() && rightblock.GetComponent<Player>().CheckLeft();
                    }
                    else if (rightblock.CompareTag("smooth"))
                    {
                        return leftblock.GetComponent<Sticky>().CheckLeft() && rightblock.GetComponent<Smooth>().CheckLeft();
                    }
                    else if (rightblock.CompareTag("sticky"))
                    {
                        return leftblock.GetComponent<Sticky>().CheckLeft() && rightblock.GetComponent<Sticky>().CheckLeft();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (leftblock.CompareTag("wall"))
                {
                    return false;
                }
                else //smooth
                {
                    if (rightblock.CompareTag("player"))
                    {
                        return leftblock.GetComponent<Smooth>().CheckLeft() && rightblock.GetComponent<Player>().CheckLeft();
                    }
                    else if (rightblock.CompareTag("smooth"))
                    {
                        return leftblock.GetComponent<Smooth>().CheckLeft() && rightblock.GetComponent<Smooth>().CheckLeft();
                    }
                    else if (rightblock.CompareTag("sticky"))
                    {
                        return leftblock.GetComponent<Smooth>().CheckLeft() && rightblock.GetComponent<Sticky>().CheckLeft();
                    }
                    else
                    {
                        return false;
                    }
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
                        return leftblock.GetComponent<Sticky>().CheckRight();
                        //return rightblock.GetComponent<Sticky>().CheckRight();
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
                    if(leftblock == null)
                    {
                        return false;
                    }
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

                        //need to check for all lefts
                        if(leftblock == null) return rightblock.GetComponent<Sticky>().CheckRight();
                        if (leftblock.CompareTag("player"))
                        {
                            return rightblock.GetComponent<Sticky>().CheckRight() && leftblock.GetComponent<Player>().CheckRight();
                        } else if(leftblock.CompareTag("smooth"))
                        {
                            return rightblock.GetComponent<Sticky>().CheckRight() && leftblock.GetComponent<Smooth>().CheckRight();
                        } else if(leftblock.CompareTag("sticky")){

                            return rightblock.GetComponent<Sticky>().CheckRight() && leftblock.GetComponent<Sticky>().CheckRight();
                        } else
                        {
                            return false;
                        }
                    
               
                        //return rightblock.GetComponent<Sticky>().CheckRight();
                    }
                    else if (rightblock.CompareTag("wall"))
                    {
                        return false;
                    }
                    else //smooth
                    {
                        if (leftblock.CompareTag("player"))
                        {
                            return rightblock.GetComponent<Smooth>().CheckRight() && leftblock.GetComponent<Player>().CheckRight();
                        }
                        else if (leftblock.CompareTag("smooth"))
                        {
                            return rightblock.GetComponent<Smooth>().CheckRight() && leftblock.GetComponent<Smooth>().CheckRight();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return rightblock.GetComponent<Smooth>().CheckRight() && leftblock.GetComponent<Sticky>().CheckRight();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

        }
    }
}
