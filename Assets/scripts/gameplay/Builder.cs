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
        checkBuildMode();
        checkBuildClick();
    }
    //check if anything from construction menu is selected
    bool checkBuildMode()
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
                return true;
            }
            else
            {
                factoryBuild = false;
                return false;
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
                return true;
            }
            else
            {
                collectorBuild = false;
                return false;
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
                return true;
            }
            else
            {
                receiver = null;
                receiver = null;
                roadBuild = false;
                return false;
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
                return true;
            }
            else
            {
                bulldozer = false;
                return false;
            }
        }
        return false;
    }
    //if checkBuildMode returns true, check if anything is being build
    void checkBuildClick()
    {
        //if factory is selected
        if (factoryBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildBuilding(0);
            }
        }//if collector is selected
        else if (collectorBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildBuilding(1);
            }
        }//if road is selected
        else if (roadBuild)
        {
            //first select point
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

            }//second select point
            else if (Input.GetMouseButtonDown(0) && receiver == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0, 0, -1));
                if (hit.transform == null || hit.transform.gameObject == sender) return;
                if (hit.transform.CompareTag("conveyer"))
                {
                    Destroy(hitObject.GetComponent<HighLight>());
                    receiver = hit.transform.gameObject;

                }
                buildRoad(sender, receiver);
            }
        }//if bulldozer is selected
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

    //bulldozer remove function
    void bulldoze(GameObject g)
    {
        //cannot remove cities and deposits
        if (g.name == "City" || g.name == "Deposit") return;
        //if its a road,call the remove function of the road
        if(g.name == "RoadPiece")
        {
            g.transform.parent.GetComponent<Road>().removeRoad();
            economy.road(-g.transform.parent.GetComponent<Road>().roadPieces.Length-1);
        }else if(g.name == "Factory") // if it's a factory, remove it and set the receiver to null
        {
            g.GetComponent<Conveyer>().receiver = null;
            Destroy(g.gameObject);
            economy.factory(-1);
        }else if(g.name == "Collector")//if it's a collector remove it and set the receiver to null
        {
            g.GetComponent<Conveyer>().receiver = null;
            Destroy(g.gameObject);
            economy.collector(-1);
        }
        //at end set bulldozer to false
        bulldozer = false;
    }
    //build factory or collector
    void buildBuilding(int index)
    {
        //0 or 1 || 0 = factory, 1 = collector
        if(index != 0 && index != 1)
        {
            return;
        }
        //if its 1 build collector
        if (index == 1)
        {
            if (economy.treasure - collectorCost < 0) { print("not enough money"); return;}
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
            if (hit.transform == null) return;
            //check if the hit is a deposit
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
        else //else it is a factory
        {
            if(economy.treasure - factoryCost < 0) { print("not enough money"); return; }
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down);
            if (hit.transform == null)//can only be placed on empty spots
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
    //build a road between two points
    void buildRoad(GameObject pos1,GameObject pos2)
    {
        //if one of the points is null stop
        if (pos1 == null || pos2 == null) return;
        //create parent road object where all roadpieces will be children of
        GameObject road = new GameObject();
        road.name = "road";
        road.AddComponent<Road>();
        road.AddComponent<Conveyer>();
        road.transform.parent = this.transform;
        this.sender.GetComponent<Conveyer>().receiver = road.GetComponent<Conveyer>();
        road.GetComponent<Conveyer>().receiver = this.receiver.GetComponent<Conveyer>();
        

        //calculate the size and cost of the road
        int size = Mathf.RoundToInt(Vector3.Distance(pos1.transform.position, pos2.transform.position)/ frequencyRoad);
        if (size <= 0) return;
        if (economy.treasure - roadCost * size < 0) { print("not enough money"); return; }
        float lerpValue = 0;
        float distance = 1;
        distance = 1f / size;
        GameObject[] roadPieces = new GameObject[size-1];
        //create the road
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
