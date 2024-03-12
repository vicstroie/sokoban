using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject sticky;
    public GameObject smooth;
    public GameObject clingy;
    public GameObject wall;

    public GameObject[] blocks;

    public Vector2Int[] pos;

    public static Manager reference;




    // Start is called before the first frame update
    void Start()
    {
        reference = this;

        blocks = new GameObject[5];
        blocks[0] = player;
        blocks[1] = sticky;
        blocks[2] = smooth;
        blocks[3] = clingy;
        blocks[4] = wall;

        pos = new Vector2Int[5];




        /*
        GameObject.Instantiate(player);
        player.GetComponent<GridObject>().gridPosition = new Vector2Int(1, 1);

        GameObject.Instantiate(wall);
        wall.GetComponent<GridObject>().gridPosition = new Vector2Int(2, 1);

        GameObject.Instantiate(sticky);
        sticky.GetComponent<GridObject>().gridPosition = new Vector2Int(3, 1);

        GameObject.Instantiate(smooth);
        smooth.GetComponent<GridObject>().gridPosition = new Vector2Int(4, 1);

        GameObject.Instantiate(clingy);
        clingy.GetComponent<GridObject>().gridPosition = new Vector2Int(5, 1);
        */
    }

    // Update is called once per frame
    void Update()
    {
        pos[0] = new Vector2Int(blocks[0].GetComponent<Player>().currentPos.x, GetComponent<Player>().currentPos.y);
    }






}
