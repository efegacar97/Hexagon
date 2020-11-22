using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public GameObject hexagon;
    public int color;
    private int number;
    public Material blue;
    public Material red;
    public Material yellow;
    public Material green;
    public Material purple;
    public static int i = 0;
    public static int j = 0;
    float pos;

    

    void Start()
    {
        pos = gameObject.transform.position.x;

        int number = Random.Range(1, 6);
        if (number == 1)
        {
            GetComponent<SpriteRenderer>().material = red;
        }
        else if (number == 2)
        {
            GetComponent<SpriteRenderer>().material = yellow;
        }
        else if (number == 3)
        {
            GetComponent<SpriteRenderer>().material = green;
        }
        else if (number == 4)
        {
            GetComponent<SpriteRenderer>().material = blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().material = purple;
        }
        color = number;
    }


    



}
