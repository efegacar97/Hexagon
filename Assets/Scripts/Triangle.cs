using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Triangle : MonoBehaviour
{
    public GameObject Hexagon;
    public bool isleft = false;
    int c1;
    int c2;
    int c3;
    int d1;
    int d2;
    int d3;
    static Transform temp1;
    static Transform temp2;
    static Transform temp3;
    static GameObject t1;
    static GameObject t2;
    static GameObject t3;
    public bool isselected = false;
    public bool ischecked;
    private Vector2 start;

    void Start()
    {
        ischecked = false;
        InvokeRepeating("explode", 100,100);
    }

    void explode()
    {
        Check();
        loop();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Swipe(Input.mousePosition);
        }
    }

    public void Check()
    {
        Vector2 right = new Vector2(1, 0);
        Vector2 left = new Vector2(-1, 0);
        Vector2 topright = new Vector2(1, 1);
        Vector2 topleft = new Vector2(-1, 1);
        Vector2 botright = new Vector2(1, -1);
        Vector2 botleft = new Vector2(-1, -1);

        RaycastHit2D []h1 = Physics2D.RaycastAll(transform.position, left, 0.8f);
        RaycastHit2D []h2 = Physics2D.RaycastAll(transform.position, topright, 0.5f);
        RaycastHit2D []h3 = Physics2D.RaycastAll(transform.position, botright, 0.5f);
        RaycastHit2D []k1 = Physics2D.RaycastAll(transform.position, right, 0.8f);
        RaycastHit2D []k2 = Physics2D.RaycastAll(transform.position, botleft, 0.5f);
        RaycastHit2D []k3 = Physics2D.RaycastAll(transform.position, topleft, 0.5f);

        if(isleft == true)
        {
            if (h1[1] && h2[1] && h3[1])
            {
                c1 = h1[1].collider.gameObject.GetComponent<Hexagon>().color;
                c2 = h2[1].collider.gameObject.GetComponent<Hexagon>().color;
                c3 = h3[1].collider.gameObject.GetComponent<Hexagon>().color;
            }
            if (c1 == c2 && c2 == c3)
            {

                ischecked = true;
            }
            else
            {
                ischecked = false;
            }
        }
        
        else
        {
            if (k1[1] && k2[1] && k3[1])
            {
                d1 = k1[1].collider.gameObject.GetComponent<Hexagon>().color;
                d2 = k2[1].collider.gameObject.GetComponent<Hexagon>().color;
                d3 = k3[1].collider.gameObject.GetComponent<Hexagon>().color;
            }

            if (d1 == d2 && d2 == d3)
            {

                ischecked = true;

            }
            else
            {
                ischecked = false;
            }
        }
        
    }

    public void makeChild()
    {
        Vector2 right = new Vector2(1, 0);
        Vector2 left = new Vector2(-1, 0);
        Vector2 topright = new Vector2(1, 1);
        Vector2 topleft = new Vector2(-1, 1);
        Vector2 botright = new Vector2(1, -1);
        Vector2 botleft = new Vector2(-1, -1);

        RaycastHit2D [] h1 = Physics2D.RaycastAll(transform.position, left, 0.8f);
        RaycastHit2D [] h2 = Physics2D.RaycastAll(transform.position, topright, 0.5f);
        RaycastHit2D [] h3 = Physics2D.RaycastAll(transform.position, botright, 0.5f);
        RaycastHit2D [] k1 = Physics2D.RaycastAll(transform.position, right, 0.8f);
        RaycastHit2D [] k2 = Physics2D.RaycastAll(transform.position, botleft, 0.5f);
        RaycastHit2D [] k3 = Physics2D.RaycastAll(transform.position, topleft, 0.5f);
        
        if(t1&& t2 && t3)
        {
            t1.transform.parent = temp1;
            t2.transform.parent = temp2;
            t3.transform.parent = temp3;
        }

        if (isleft == true)
        {
            t1 = h1[1].collider.gameObject;
            t2 = h2[1].collider.gameObject;
            t3 = h3[1].collider.gameObject;

            temp1 = h1[1].collider.gameObject.transform.parent;
            h1[1].collider.gameObject.transform.parent = gameObject.transform;

            temp2 = h2[1].collider.gameObject.transform.parent;
            h2[1].collider.gameObject.transform.parent = gameObject.transform;

            temp3 = h3[1].collider.gameObject.transform.parent;
            h3[1].collider.gameObject.transform.parent = gameObject.transform;
        }
        else
        {
            t1 = k1[1].collider.gameObject;
            t2 = k2[1].collider.gameObject;
            t3 = k3[1].collider.gameObject;

            temp1 = k1[1].collider.gameObject.transform.parent;
            k1[1].collider.gameObject.transform.parent = gameObject.transform;
            temp2 = k2[1].collider.gameObject.transform.parent;
            k2[1].collider.gameObject.transform.parent = gameObject.transform;
            temp3 = k3[1].collider.gameObject.transform.parent;
            k3[1].collider.gameObject.transform.parent = gameObject.transform; 
        }
    }
    public void Rotate()
    {
        if (isselected == true)
        {
            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);
            Vector2 topright = new Vector2(1, 1);
            Vector2 topleft = new Vector2(-1, 1);
            Vector2 botright = new Vector2(1, -1);
            Vector2 botleft = new Vector2(-1, -1);

            RaycastHit2D[] h1 = Physics2D.RaycastAll(transform.position, left, 0.8f);
            RaycastHit2D[] h2 = Physics2D.RaycastAll(transform.position, topright, 0.5f);
            RaycastHit2D[] h3 = Physics2D.RaycastAll(transform.position, botright, 0.5f);
            RaycastHit2D[] k1 = Physics2D.RaycastAll(transform.position, right, 0.8f);
            RaycastHit2D[] k2 = Physics2D.RaycastAll(transform.position, botleft, 0.5f);
            RaycastHit2D[] k3 = Physics2D.RaycastAll(transform.position, topleft, 0.5f);
            if (isleft)
            {
                Vector3 temp = h1[1].collider.gameObject.transform.localPosition;
                h1[1].collider.gameObject.transform.localPosition = h2[1].collider.gameObject.transform.localPosition;
                h2[1].collider.gameObject.transform.localPosition = h3[1].collider.gameObject.transform.localPosition;
                h3[1].collider.gameObject.transform.localPosition = temp;
            }
            else
            {
                Vector3 temp = k1[1].collider.gameObject.transform.localPosition;
                k1[1].collider.gameObject.transform.localPosition = k2[1].collider.gameObject.transform.localPosition;
                k2[1].collider.gameObject.transform.localPosition = k3[1].collider.gameObject.transform.localPosition;
                k3[1].collider.gameObject.transform.localPosition = temp;
            }
            
        }

    }
    public void Rotate2()
    {

        if (isselected == true)
        {
            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);
            Vector2 topright = new Vector2(1, 1);
            Vector2 topleft = new Vector2(-1, 1);
            Vector2 botright = new Vector2(1, -1);
            Vector2 botleft = new Vector2(-1, -1);

            RaycastHit2D[] h1 = Physics2D.RaycastAll(transform.position, left, 0.8f);
            RaycastHit2D[] h2 = Physics2D.RaycastAll(transform.position, topright, 0.5f);
            RaycastHit2D[] h3 = Physics2D.RaycastAll(transform.position, botright, 0.5f);
            RaycastHit2D[] k1 = Physics2D.RaycastAll(transform.position, right, 0.8f);
            RaycastHit2D[] k2 = Physics2D.RaycastAll(transform.position, botleft, 0.5f);
            RaycastHit2D[] k3 = Physics2D.RaycastAll(transform.position, topleft, 0.5f);

            if (isleft)
            {
                Vector3 temp = h1[1].collider.gameObject.transform.localPosition;
                h1[1].collider.gameObject.transform.localPosition = h3[1].collider.gameObject.transform.localPosition;
                h3[1].collider.gameObject.transform.localPosition = h2[1].collider.gameObject.transform.localPosition;
                h2[1].collider.gameObject.transform.localPosition = temp;
            }
            else
            {
                Vector3 temp = k1[1].collider.gameObject.transform.localPosition;
                k1[1].collider.gameObject.transform.localPosition = k3[1].collider.gameObject.transform.localPosition;
                k3[1].collider.gameObject.transform.localPosition = k2[1].collider.gameObject.transform.localPosition;
                k2[1].collider.gameObject.transform.localPosition = temp;
            }

        }
    }
    void Swipe(Vector3 final)
    {
        float disX = Mathf.Abs(start.x - final.x);
        float disY = Mathf.Abs(start.y - final.y);
        if (disX > 0 || disY > 0)
        {
            if (disX > disY)
            {
                if (start.x > final.x)
                {
                    Rotate2();
                    
                    
                }
                else
                {
                    
                    Rotate();
                    

                }
            }
        }
    }


    public void Blast1(RaycastHit2D[] h1, RaycastHit2D[] h2, RaycastHit2D[] h3)
    {
        int fixbugs = Random.Range(5, 100);
        Vector3 spawn = new Vector3(h1[1].collider.gameObject.transform.position.x, fixbugs, 0);
        fixbugs = Random.Range(5, 100);
        Vector3 spawn2 = new Vector3(h2[1].collider.gameObject.transform.position.x, fixbugs, 0);
        fixbugs = Random.Range(5, 100);
        Vector3 spawn3 = new Vector3(h3[1].collider.gameObject.transform.position.x, fixbugs, 0);



        Destroy(h1[1].collider.gameObject);
        Destroy(h2[1].collider.gameObject);
        Destroy(h3[1].collider.gameObject);

        GameObject a = Instantiate(Hexagon, spawn, Quaternion.Euler(0f, 0f, 90f));
        GameObject b = Instantiate(Hexagon, spawn2, Quaternion.Euler(0f, 0f, 90f));
        GameObject c = Instantiate(Hexagon, spawn3, Quaternion.Euler(0f, 0f, 90f));

        Score.score += 15;
    }
    public void Blast2(RaycastHit2D[] k1, RaycastHit2D[] k2, RaycastHit2D[] k3)
    {
        int fixbugs = Random.Range(100, 200);
        Vector3 spawn = new Vector3(k1[1].collider.gameObject.transform.position.x, fixbugs, 0);
        fixbugs = Random.Range(100, 200);
        Vector3 spawn2 = new Vector3(k2[1].collider.gameObject.transform.position.x, fixbugs, 0);
        fixbugs = Random.Range(100, 200);
        Vector3 spawn3 = new Vector3(k3[1].collider.gameObject.transform.position.x, fixbugs, 0);

        Destroy(k1[1].collider.gameObject);
        Destroy(k2[1].collider.gameObject);
        Destroy(k3[1].collider.gameObject);

        GameObject a = Instantiate(Hexagon, spawn, Quaternion.Euler(0f, 0f, 90f));
        GameObject b = Instantiate(Hexagon, spawn2, Quaternion.Euler(0f, 0f, 90f));
        GameObject c = Instantiate(Hexagon, spawn3, Quaternion.Euler(0f, 0f, 90f));
        Score.score += 15;
    }
    public void loop()
    {
            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);
            Vector2 topright = new Vector2(1, 1);
            Vector2 topleft = new Vector2(-1, 1);
            Vector2 botright = new Vector2(1, -1);
            Vector2 botleft = new Vector2(-1, -1);

            RaycastHit2D[] h1 = Physics2D.RaycastAll(transform.position, left, 0.8f);
            RaycastHit2D[] h2 = Physics2D.RaycastAll(transform.position, topright, 0.5f);
            RaycastHit2D[] h3 = Physics2D.RaycastAll(transform.position, botright, 0.5f);
            RaycastHit2D[] k1 = Physics2D.RaycastAll(transform.position, right, 0.8f);
            RaycastHit2D[] k2 = Physics2D.RaycastAll(transform.position, botleft, 0.5f);
            RaycastHit2D[] k3 = Physics2D.RaycastAll(transform.position, topleft, 0.5f);

            if (ischecked == true)
            {
                if (isleft == true)
                {
                    Blast1(h1, h2, h3);
                }
                else
                {
                    Blast2(k1, k2, k3);
                }
            }
    }







}
