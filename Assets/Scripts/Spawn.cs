using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public GameObject hexagon;
    public GameObject triangle;
    public GameObject[] SpawnPoints;
    public GameObject left;
    public GameObject right;
    static GameObject selected = null;

    int count = 0;

    Vector3 point = new Vector3(-1.78883004f, -3.91468f, 0);
    Vector3 point2 = new Vector3(-1.59200001f, -4.275186f, 0);
    Vector3 point3 = new Vector3(-1.16680002f, -4.27529001f, 0);
    Vector3 point4 = new Vector3(-0.962849975f, -3.9138701f, 0);
    Vector3 point5 = new Vector3(-0.549929976f, -3.91420007f, 0);
    Vector3 point6 = new Vector3(-0.348100007f, -4.27476978f, 0);
    Vector3 point7 = new Vector3(0.0702899992f, -4.27509022f, 0);
    Vector3 point8 = new Vector3(0.271389991f, -3.91360998f, 0);
    Vector3 point9 = new Vector3(0.688549995f, -3.91428995f, 0);
    Vector3 point10 = new Vector3(0.890250027f, -4.27504015f, 0);
    Vector3 point11 = new Vector3(1.31077003f, -4.27544022f, 0);
    Vector3 point12 = new Vector3(1.51139998f, -3.91400003f, 0);
    Vector3 point13 = new Vector3(1.92988002f, -3.91422009f, 0);
    Vector3 point14 = new Vector3(2.13039994f, -4.27489996f, 0);

    void Start()
    {
        Time.timeScale = 100;
        GameObject SP1 = GameObject.Find("SP1");
        GameObject SP2 = GameObject.Find("SP2");
        GameObject SP3 = GameObject.Find("SP3");
        GameObject SP4 = GameObject.Find("SP4");
        GameObject SP5 = GameObject.Find("SP5");
        GameObject SP6 = GameObject.Find("SP6");
        GameObject SP7 = GameObject.Find("SP7");
        GameObject SP8 = GameObject.Find("SP8");
        SpawnPoints = new GameObject[] { SP1, SP2, SP3, SP4, SP5, SP6, SP7, SP8 };
        SpawnTriangles();
        SpawnHexagons();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name == "Triangle(Clone)")
            {
                GameObject remove = GameObject.Find("Left(Clone)");
                GameObject remove2 = GameObject.Find("Right(Clone)");
                Destroy(remove);
                Destroy(remove2);
                Transform temp1;
                Transform temp2;
                if (selected)
                {
                    selected.GetComponent<Triangle>().isselected = false;
                }
                
                Vector3 temp = new Vector3(hit.collider.gameObject.transform.position.x -0.75f,hit.collider.gameObject.transform.position.y +0.04f, -15);
                if (hit.collider.gameObject.GetComponent<Triangle>().isleft == true)
                {
                   GameObject tempLeft = Instantiate(left, temp, Quaternion.identity);
                   temp1 = tempLeft.transform.parent;
                   tempLeft.transform.parent = hit.collider.gameObject.transform;
                   hit.collider.gameObject.GetComponent<Triangle>().makeChild();
                   hit.collider.gameObject.GetComponent<Triangle>().isselected = true;
                   selected = hit.collider.gameObject;
                }
                else
                {
                   GameObject tempRight = Instantiate(right, temp, Quaternion.identity);
                   temp2 = tempRight.transform.parent;
                   tempRight.transform.parent = hit.collider.gameObject.transform;
                   hit.collider.gameObject.GetComponent<Triangle>().makeChild();
                   hit.collider.gameObject.GetComponent<Triangle>().isselected = true;
                   selected = hit.collider.gameObject;
                }
            }
        }
    }

    public void SpawnHexagons()
    {
        foreach (GameObject SP in SpawnPoints)
        {
            Instantiate(hexagon, SP.transform.position, Quaternion.Euler(0f, 0f, 90f));
        }
        StartCoroutine(waitforspawn()); 
    }

    public void SpawnTriangles()
    {
        for(int i=0; i < 8; i++)
        {
            Instantiate(triangle, point, Quaternion.identity);
            GameObject a = Instantiate(triangle, point2, Quaternion.identity);
            a.GetComponent<Triangle>().isleft = true;
            Instantiate(triangle, point3, Quaternion.identity);
            GameObject b = Instantiate(triangle, point4, Quaternion.identity);
            b.GetComponent<Triangle>().isleft = true;
            Instantiate(triangle, point5, Quaternion.identity);
            GameObject c = Instantiate(triangle, point6, Quaternion.identity);
            c.GetComponent<Triangle>().isleft = true;
            Instantiate(triangle, point7, Quaternion.identity);
            GameObject d = Instantiate(triangle, point8, Quaternion.identity);
            d.GetComponent<Triangle>().isleft = true;
            Instantiate(triangle, point9, Quaternion.identity);
            GameObject e = Instantiate(triangle, point10, Quaternion.identity);
            e.GetComponent<Triangle>().isleft = true;
            Instantiate(triangle, point11, Quaternion.identity);
            GameObject f = Instantiate(triangle, point12, Quaternion.identity);
            f.GetComponent<Triangle>().isleft = true;
            Instantiate(triangle, point13, Quaternion.identity);
            GameObject g = Instantiate(triangle, point14, Quaternion.identity);
            g.GetComponent<Triangle>().isleft = true;
            point.y  += 0.720f+0.003f;
            point2.y += 0.720f + 0.003f;
            point3.y += 0.720f + 0.003f;
            point4.y += 0.720f + 0.003f;
            point5.y += 0.720f + 0.003f;
            point6.y += 0.720f + 0.003f;
            point7.y += 0.720f + 0.003f;
            point8.y += 0.720f + 0.003f;
            point9.y += 0.720f + 0.003f;
            point10.y += 0.720f + 0.003f;
            point11.y += 0.720f + 0.003f;
            point12.y += 0.720f + 0.003f;
            point13.y += 0.720f + 0.003f;
            point14.y += 0.720f + 0.003f;
        }
    }

    IEnumerator waitforspawn()
    {
        yield return new WaitForSeconds(0.2f);
        if (count < 8)
        {
            SpawnHexagons();
            count++;
        }
    }
}
