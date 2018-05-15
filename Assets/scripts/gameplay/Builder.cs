using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

    public GameObject[] BuildPieces;
    public float frequencyRoad;

    public Economy economy;

    bool factoryBuild;
    bool collectorBuild;
    bool roadBuild;
    bool bulldozer;

    public int factoryCost;
    public int collectorCost;
    public int roadCost;

    GameObject sender;
    GameObject receiver;
    GameObject hitObject;

    private void Start()
    {
        economy = this.GetComponent<Economy>();
    }

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
                bulldozer = false;
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
                bulldozer = false;
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
                bulldozer = false;
            }
            else
            {
                receiver = null;
                receiver = null;
                roadBuild = false;
            }
        }
        //bulldozer
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!bulldozer)
            {
                factoryBuild = false;
                collectorBuild = false;
                roadBuild = false;
                bulldozer = true;
            }
            else
            {
                bulldozer = false;
            }
        }

        if (factoryBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildBuilding(0);
            }
        }
        else if (collectorBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildBuilding(1);
            }
        }
        else if (roadBuild)
        {

            if (Input.GetMouseButtonDown(0) && sender == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, -1));
                if (hit.transform == null || hit.transform.name == "City") return;
                if (hit.transform.CompareTag("conveyer"))
                {
                    hitObject = hit.transform.gameObject;
                    hitObject.AddComponent<HighLight>();
                    sender = hit.transform.gameObject;
                }

            }
            else if (Input.GetMouseButtonDown(0) && receiver == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, -1));
                if (hit.transform == null) return;
                if (hit.transform.CompareTag("conveyer"))
                {
                    Destroy(hitObject.GetComponent<HighLight>());
                    receiver = hit.transform.gameObject;

                }
                buildRoad(sender, receiver);
            }
        }
        else if (bulldozer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, -1));
                if (hit.transform == null) return;
                bulldoze(hit.transform.gameObject);
            }
        }
    }

    void bulldoze(GameObject g)
    {
        if (g.name == "City" || g.name == "Deposit") return;
        if(g.name == "RoadPiece")
        {
            g.transform.parent.GetComponent<Road>().removeRoad();
            economy.road(-g.transform.parent.GetComponent<Road>().roadPieces.Length-1);
        }else if(g.name == "Factory")
        {
            g.GetComponent<Conveyer>().receiver = null;
            Destroy(g.gameObject);
            economy.factory(-1);
        }else if(g.name == "Collector")
        {
            g.GetComponent<Conveyer>().receiver = null;
            Destroy(g.gameObject);
            economy.collector(-1);
        }
        bulldozer = false;
    }
    void buildBuilding(int index)
    {
        //0 or 1 || 0 = factory, 1 = collector
        if(index != 0 && index != 1)
        {
            return;
        }

        if (index == 1)
        {
            if (economy.treasure - collectorCost < 0) { print("not enough money"); return;}
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
            if (hit.transform == null) return;
            if (hit.transform.CompareTag("deposit"))
            {
                Vector3 buildPos = hit.transform.position;
                buildPos.z = 1;
                GameObject g = Instantiate(BuildPieces[index], buildPos, Quaternion.identity, this.transform);
                g.GetComponent<Collector>().deposit = hit.transform.gameObject.GetComponent<Deposit>();
                collectorBuild = false;
                economy.collector(1);
                economy.buildCosts += collectorCost;
            }
        }
        else
        {
            if(economy.treasure - factoryCost < 0) { print("not enough money"); return; }
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
            if (hit.transform == null)
            {
                Vector3 buildPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                buildPos.z = 1;
                Instantiate(BuildPieces[index], buildPos, Quaternion.identity, this.transform);
                factoryBuild = false;
                economy.factory(1);
                economy.buildCosts += factoryCost;
            }
        }
    }

    void buildRoad(GameObject pos1,GameObject pos2)
    {
        if (pos1 == null || pos2 == null) return;

        GameObject road = new GameObject();
        road.name = "road";
        road.AddComponent<Road>();
        road.AddComponent<Conveyer>();
        road.transform.parent = this.transform;
        this.sender.GetComponent<Conveyer>().receiver = road.GetComponent<Conveyer>();
        road.GetComponent<Conveyer>().receiver = this.receiver.GetComponent<Conveyer>();
        


        int size = Mathf.RoundToInt(Vector3.Distance(pos1.transform.position, pos2.transform.position)/ frequencyRoad);
        if (size <= 0) return;
        if (economy.treasure - roadCost * size < 0) { print("not enough money"); return; }
        float lerpValue = 0;
        float distance = 1;
        distance = 1f / size;
        GameObject[] roadPieces = new GameObject[size-1];
        for (int i = 0; i < size-1; i++)
        { 
            lerpValue += distance;
           
            Vector3 instantiatePosition = Vector3.Lerp(pos1.transform.position, pos2.transform.position, lerpValue);
            roadPieces[i] = Instantiate(BuildPieces[2], instantiatePosition, transform.rotation, road.transform);
            roadPieces[i].name = "RoadPiece";
            sender = null;
            receiver = null;
            roadBuild = false;
            
        }
        economy.road(size);
        economy.buildCosts += 2 * size;
        road.GetComponent<Road>().init(roadPieces);
    }
}
