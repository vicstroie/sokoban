using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : Block
{

   
    Vector2Int playerPos;
    public GameObject player;

    public GameObject touching;


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
            PosDebug();
            move = false;
        }
    }



    public bool CheckLeft()
    {
        if(currentPos.x == 1)
        {
            return false;
        } else
        {

            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];
            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];

                if(leftblock == null)
                {
                   if (rightblock == null || rightblock.CompareTag("clingy") || rightblock.CompareTag("wall") || rightblock.CompareTag("sticky"))
                   {
                            if(upblock == null)
                            {
                                        if (downblock == null)
                                        {
                                            return false;
                                        }  
                                        if(downblock.CompareTag("player"))
                                        {
                                            return downblock.GetComponent<Player>().CheckLeft();
                                        }
                                        if (downblock.CompareTag("smooth"))
                                        {
                                            return downblock.GetComponent<Smooth>().CheckLeft();
                                        }
                                        else if (downblock.CompareTag("sticky"))
                                        {
                                            return downblock.GetComponent<Sticky>().CheckLeft();
                                        }
                                        else if (downblock.CompareTag("clingy"))
                                        {
                                            return downblock.GetComponent<Clingy>().CheckLeft();
                                        }
                                        else
                                        {
                                            return false;
                                        }
                            }
                            if(upblock.CompareTag("clingy"))
                            {
                                bool temp = upblock.GetComponent<Clingy>().CheckLeft();
                                if(downblock == null)
                                {
                                    return temp;
                                }
                                if(downblock.CompareTag("smooth"))
                                {
                                   return temp || downblock.GetComponent<Smooth>().CheckLeft();
                                } else if(downblock.CompareTag("sticky"))
                                {
                                    return temp || downblock.GetComponent<Sticky>().CheckLeft();
                                } else if(downblock.CompareTag("clingy"))
                                {
                                    return temp || downblock.GetComponent<Clingy>().CheckLeft();
                                } else
                                {
                                    return temp;
                                }
                            }
                            else if(upblock.CompareTag("player"))
                            {
                                return upblock.GetComponent<Player>().CheckLeft();
                            }
                            else if (downblock.CompareTag("player"))
                            {
                                return downblock.GetComponent<Player>().CheckLeft();
                            }
                            else if (upblock.CompareTag("smooth"))
                            {
                                bool temp = upblock.GetComponent<Smooth>().CheckLeft();

                                if(downblock == null)
                                 {
                                     return temp;
                                 }
                                if (downblock.CompareTag("smooth"))
                                {
                                    return temp || downblock.GetComponent<Smooth>().CheckLeft();
                                }
                                else if (downblock.CompareTag("sticky"))
                                {
                                    return temp || downblock.GetComponent<Sticky>().CheckLeft();
                                }
                                else if (downblock.CompareTag("clingy"))
                                {
                                    return temp || downblock.GetComponent<Clingy>().CheckLeft();
                                }
                                else
                                {
                                    return temp;
                                }
                            }
                            else
                            {
                                return false;
                            }
                   }
                   else if (rightblock.CompareTag("player"))
                   {
                    //return rightblock.GetComponent<Player>().CheckLeft();
                      return true;
                   }
                   else if (rightblock.CompareTag("smooth"))
                   {
                      return rightblock.GetComponent<Smooth>().CheckLeft();
                   }
                   else
                   {
                      return false;
                   }
                    
                }
            else if(leftblock.CompareTag("smooth"))
            {
                return leftblock.GetComponent<Smooth>().CheckLeft();    
            }
            else if (leftblock.CompareTag("player"))
            {
                return leftblock.GetComponent<Player>().CheckLeft();
            }
            else if(leftblock.CompareTag("clingy"))
                {
                    return false;
                } else if(leftblock.CompareTag("wall"))
                {
                    return false;
                } else //sticky
                {
                    return leftblock.GetComponent<Sticky>().CheckLeft();
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

            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];
            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];

            if (rightblock == null)
            {
                if (leftblock == null || leftblock.CompareTag("clingy") || leftblock.CompareTag("wall") || leftblock.CompareTag("sticky"))
                {
                    if (upblock == null)
                    {
                        if (downblock == null)
                        {
                            return false;
                        }
                        if (downblock.CompareTag("player"))
                        {
                            return downblock.GetComponent<Player>().CheckRight();
                        }
                        if (downblock.CompareTag("smooth"))
                        {
                            return downblock.GetComponent<Smooth>().CheckRight();
                        }
                        else if (downblock.CompareTag("sticky"))
                        {
                            return downblock.GetComponent<Sticky>().CheckRight();
                        }
                        else if (downblock.CompareTag("clingy"))
                        {
                            return downblock.GetComponent<Clingy>().CheckRight();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (upblock.CompareTag("clingy"))
                    {
                        bool temp = upblock.GetComponent<Clingy>().CheckRight();
                        if (downblock == null)
                        {
                            return temp;
                        }
                        if (downblock.CompareTag("smooth"))
                        {
                            return temp || downblock.GetComponent<Smooth>().CheckRight();
                        }
                        else if (downblock.CompareTag("sticky"))
                        {
                            return temp || downblock.GetComponent<Sticky>().CheckRight();
                        }
                        else if (downblock.CompareTag("clingy"))
                        {
                            return temp || downblock.GetComponent<Clingy>().CheckRight();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else if (upblock.CompareTag("player"))
                    {
                        return upblock.GetComponent<Player>().CheckRight();
                    }
                    else if (downblock.CompareTag("player"))
                    {
                        return downblock.GetComponent<Player>().CheckRight();
                    }
                    else if (upblock.CompareTag("smooth"))
                    {
                        bool temp = upblock.GetComponent<Smooth>().CheckRight();

                        if (downblock == null)
                        {
                            return temp;
                        }
                        if (downblock.CompareTag("smooth"))
                        {
                            return temp || downblock.GetComponent<Smooth>().CheckRight();
                        }
                        else if (downblock.CompareTag("sticky"))
                        {
                            return temp || downblock.GetComponent<Sticky>().CheckRight();
                        }
                        else if (downblock.CompareTag("clingy"))
                        {
                            return temp || downblock.GetComponent<Clingy>().CheckRight();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (leftblock.CompareTag("player"))
                {
                    //return leftblock.GetComponent<Player>().CheckRight();
                    return true;
                }
                else if (leftblock.CompareTag("smooth"))
                {
                    return leftblock.GetComponent<Smooth>().CheckRight();
                }
                else
                {
                    return false;
                }

            }
            else if (rightblock.CompareTag("smooth"))
            {
                return rightblock.GetComponent<Smooth>().CheckRight();
            }
            else if (rightblock.CompareTag("player"))
            {
                return leftblock.GetComponent<Player>().CheckRight();
            }
            else if (rightblock.CompareTag("clingy"))
            {
                return false;
            }
            else if (rightblock.CompareTag("wall"))
            {
                return false;
            }
            else //sticky
            {
                return rightblock.GetComponent<Sticky>().CheckRight();
            }

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
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];
            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];

            if (upblock == null)
            {
                if (downblock == null || downblock.CompareTag("clingy") || downblock.CompareTag("wall") || downblock.CompareTag("sticky"))
                {
                    if (rightblock == null)
                    {
                        if (leftblock == null)
                        {
                            return false;
                        }
                        if (leftblock.CompareTag("player"))
                        {
                            return leftblock.GetComponent<Player>().CheckUp();
                        }
                        if (leftblock.CompareTag("smooth"))
                        {
                            return leftblock.GetComponent<Smooth>().CheckUp();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return leftblock.GetComponent<Sticky>().CheckUp();
                        }
                        else if (leftblock.CompareTag("clingy"))
                        {
                            return leftblock.GetComponent<Clingy>().CheckUp();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (rightblock.CompareTag("clingy"))
                    {
                        bool temp = rightblock.GetComponent<Clingy>().CheckUp();
                        if (leftblock == null)
                        {
                            return temp;
                        }
                        if (leftblock.CompareTag("smooth"))
                        {
                            return temp || leftblock.GetComponent<Smooth>().CheckUp();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return temp || leftblock.GetComponent<Sticky>().CheckUp();
                        }
                        else if (leftblock.CompareTag("clingy"))
                        {
                            return temp || leftblock.GetComponent<Clingy>().CheckUp();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else if (rightblock.CompareTag("player"))
                    {
                        return rightblock.GetComponent<Player>().CheckUp();
                    }
                    else if (leftblock.CompareTag("player"))
                    {
                        return leftblock.GetComponent<Player>().CheckUp();
                    }
                    else if (rightblock.CompareTag("smooth"))
                    {
                        bool temp = rightblock.GetComponent<Smooth>().CheckUp();

                        if (leftblock == null)
                        {
                            return temp;
                        }
                        if (leftblock.CompareTag("smooth"))
                        {
                            return temp || leftblock.GetComponent<Smooth>().CheckUp();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return temp || leftblock.GetComponent<Sticky>().CheckUp();
                        }
                        else if (leftblock.CompareTag("clingy"))
                        {
                            return temp || leftblock.GetComponent<Clingy>().CheckUp();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (downblock.CompareTag("player"))
                {
                    //return downblock.GetComponent<Player>().CheckUp();
                    return true;
                }
                else if (downblock.CompareTag("smooth"))
                {
                    return downblock.GetComponent<Smooth>().CheckUp();
                }
                else
                {
                    return false;
                }

            }
            else if (upblock.CompareTag("smooth"))
            {
                return upblock.GetComponent<Smooth>().CheckUp();
            }
            else if (upblock.CompareTag("player"))
            {
                return upblock.GetComponent<Player>().CheckUp();
            }
            else if (upblock.CompareTag("clingy"))
            {
                return false;
            }
            else if (upblock.CompareTag("wall"))
            {
                return false;
            }
            else //sticky
            {
                return upblock.GetComponent<Sticky>().CheckUp();
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

            GameObject upblock = Manager.reference.blockArray[currentPos.x, currentPos.y - 1];
            GameObject downblock = Manager.reference.blockArray[currentPos.x, currentPos.y + 1];
            GameObject rightblock = Manager.reference.blockArray[currentPos.x + 1, currentPos.y];
            GameObject leftblock = Manager.reference.blockArray[currentPos.x - 1, currentPos.y];

            if (downblock == null)
            {
                if (upblock == null || upblock.CompareTag("clingy") || upblock.CompareTag("wall") || upblock.CompareTag("sticky"))
                {
                    if (rightblock == null)
                    {
                        if (leftblock == null)
                        {
                            return false;
                        }
                        if (leftblock.CompareTag("player"))
                        {
                            return leftblock.GetComponent<Player>().CheckDown();
                        }
                        if (leftblock.CompareTag("smooth"))
                        {
                            return leftblock.GetComponent<Smooth>().CheckDown();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return leftblock.GetComponent<Sticky>().CheckDown();
                        }
                        else if (leftblock.CompareTag("clingy"))
                        {
                            return leftblock.GetComponent<Clingy>().CheckDown();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (rightblock.CompareTag("clingy"))
                    {
                        bool temp = rightblock.GetComponent<Clingy>().CheckDown();
                        if (leftblock == null)
                        {
                            return temp;
                        }
                        if (leftblock.CompareTag("smooth"))
                        {
                            return temp || leftblock.GetComponent<Smooth>().CheckDown();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return temp || leftblock.GetComponent<Sticky>().CheckDown();
                        }
                        else if (leftblock.CompareTag("clingy"))
                        {
                            return temp || leftblock.GetComponent<Clingy>().CheckDown();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else if (rightblock.CompareTag("player"))
                    {
                        return rightblock.GetComponent<Player>().CheckDown();
                    }
                    else if (leftblock.CompareTag("player"))
                    {
                        return leftblock.GetComponent<Player>().CheckDown();
                    }
                    else if (rightblock.CompareTag("smooth"))
                    {
                        bool temp = rightblock.GetComponent<Smooth>().CheckDown();

                        if (leftblock == null)
                        {
                            return temp;
                        }
                        if (leftblock.CompareTag("smooth"))
                        {
                            return temp || leftblock.GetComponent<Smooth>().CheckDown();
                        }
                        else if (leftblock.CompareTag("sticky"))
                        {
                            return temp || leftblock.GetComponent<Sticky>().CheckDown();
                        }
                        else if (leftblock.CompareTag("clingy"))
                        {
                            return temp || leftblock.GetComponent<Clingy>().CheckDown();
                        }
                        else
                        {
                            return temp;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (upblock.CompareTag("player"))
                {
                    //return upblock.GetComponent<Player>().CheckDown();
                    return true;
                }
                else if (upblock.CompareTag("smooth"))
                {
                    return upblock.GetComponent<Smooth>().CheckDown();
                }
                else
                {
                    return false;
                }

            }
            else if (downblock.CompareTag("smooth"))
            {
                return downblock.GetComponent<Smooth>().CheckDown();
            }
            else if (downblock.CompareTag("player"))
            {
                return downblock.GetComponent<Player>().CheckDown();
            }
            else if (downblock.CompareTag("clingy"))
            {
                return false;
            }
            else if (downblock.CompareTag("wall"))
            {
                return false;
            }
            else //sticky
            {
                return downblock.GetComponent<Sticky>().CheckDown();
            }

        }
    }


    private void PosDebug()
    {
        Debug.Log(this.gameObject.tag + ": " + currentPos.x + ", " + currentPos.y);
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
