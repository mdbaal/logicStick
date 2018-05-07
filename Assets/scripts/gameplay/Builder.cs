using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

    public GameObject[] objects;
    public float frequencyRoad;
    //public for testing
    public bool factoryBuild;
    public bool collectorBuild;
    public bool roadBuild;

    Vector3 p1 = new Vector3(0, 0, 0);
    Vector3 p2 = new Vector3(0, 0, 0);
    GameObject hitObject;

    private void Update()
    {
        //factoryBuild
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!factoryBuild)
            {
                factoryBuild = true;
                collectorBuild = false;
                roadBuild = false;
            }
            else
            {
                factoryBuild = false;
            }
        }
        //Collector
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!collectorBuild)
            {
                factoryBuild = false;
                collectorBuild = true;
                roadBuild = false;
            }
            else
            {
                collectorBuild = false;
            }
        }
        //roadBuild
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!roadBuild)
            {
                factoryBuild = false;
                collectorBuild = false;
                roadBuild = true;
            }
            else
            {
                roadBuild = false;
            }
        }

        if (factoryBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildBuilding(0);
            }
        }else if (collectorBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildBuilding(1);
            }
        }else if (roadBuild)
        {
            
            if(Input.GetMouseButtonDown(0) && p1.z != 1)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
                if (hit.transform.CompareTag("conveyer"))
                {
                    hitObject = hit.transform.gameObject;
                    hitObject.AddComponent<HighLight>();
                    p1 = hit.transform.position;
                    p1.z = 1;
                }
                
            }
            else if(Input.GetMouseButtonDown(0) && p2.z != 1)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
                if (hit.transform.CompareTag("conveyer"))
                {
                    Destroy(hitObject.GetComponent<HighLight>());
                    p2  = hit.transform.position;
                    p2.z = 1;
                }
                buildRoad(p1, p2);
            }
        }

    }
    void buildBuilding(int index)
    {
        //0 or 1, 0 = factoryBuild, 1 = collectorBuild
        if(index != 0 && index != 1)
        {
            return;
        }

        Vector3 buildPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        buildPos.z = 1;
       
        Instantiate(objects[index], buildPos, Quaternion.identity,this.transform);
    }

    void buildRoad(Vector3 pos1,Vector3 pos2)
    {
        GameObject road = new GameObject();
        road.name = "road";
        road.AddComponent<Road>();

       

        int size = Mathf.RoundToInt(Vector3.Distance(pos1, pos2)/ frequencyRoad);
        float lerpValue = 0;
        float distance = 1;
        distance = 1f / size;
        GameObject[] roadPieces = new GameObject[size-1];
        for (int i = 0; i < size-1; i++)
        { 
            lerpValue += distance;
           
            Vector3 instantiatePosition = Vector3.Lerp(pos1, pos2, lerpValue);
            roadPieces[i] = Instantiate(objects[2], instantiatePosition, transform.rotation, road.transform);
            p1 = new Vector3(0, 0, 0);
            p2 = new Vector3(0, 0, 0);
            roadBuild = false;
            
        }
        road.GetComponent<Road>().init(roadPieces);
    }
}
