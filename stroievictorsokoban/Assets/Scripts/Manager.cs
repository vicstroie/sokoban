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
    public bool[] touched;

    public static Manager reference;




    // Start is called before the first frame update
    void Start()
    {
        reference = this;

        blocks = new GameObject[4];
        //blocks[0] = player;
        blocks[0] = sticky;
        blocks[1] = smooth;
        blocks[2] = clingy;
        blocks[3] = wall;

        pos = new Vector2Int[4];
        touched = new bool[4];




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
        
        pos[0] = new Vector2Int(blocks[0].GetComponent<Block>().currentPos.x, blocks[0].GetComponent<Block>().currentPos.y);
        pos[1] = new Vector2Int(blocks[1].GetComponent<Block>().currentPos.x, blocks[1].GetComponent<Block>().currentPos.y);
        pos[2] = new Vector2Int(blocks[2].GetComponent<Block>().currentPos.x, blocks[2].GetComponent<Block>().currentPos.y);
        pos[3] = new Vector2Int(blocks[3].GetComponent<Block>().currentPos.x, blocks[3].GetComponent<Block>().currentPos.y);
        
        
        touched[0] = blocks[0].GetComponent<Block>().touchedByPlayer;
        touched[1] = blocks[1].GetComponent<Block>().touchedByPlayer;
        touched[2] = blocks[2].GetComponent<Block>().touchedByPlayer;
        touched[3] = blocks[3].GetComponent<Block>().touchedByPlayer;
        
    }






}
