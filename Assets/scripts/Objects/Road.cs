using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public GameObject[] roadPieces;
    private float animationSpeed = 0;
    private int index = 0;
    //
    public void init(GameObject[] road)
    {
        roadPieces = road;
        this.gameObject.GetComponent<Conveyer>().length = this.roadPieces.Length;
        
    }

    private void animate()
    {
        if(this.roadPieces.Length / .5f > 0)
        {
            animationSpeed = this.roadPieces.Length / .2f;
        }
        else
        {
            animationSpeed = .5f;
        }
        //animate movement on the road
        if (index != 0)
        {
            roadPieces[index - 1].transform.localScale = new Vector3(1f, 1f, 1);
        }
        if(index == roadPieces.Length)
        {
            index = 0;
        }

        roadPieces[index].transform.localScale = new Vector3(1.5f, 1.5f, 1);
        index++;
    }

    private void Update () {
        
        if (animationSpeed < 0)
        { 
            animate();
            this.GetComponent<Conveyer>().send();
            animationSpeed = .2f;
        }
        animationSpeed -= Time.deltaTime;
    }
    public void removeRoad()
    {
        for(int i = roadPieces.Length-1;i > 0; i--)
        {
            Destroy(roadPieces[i]);
        }
        this.GetComponent<Conveyer>().receiver = null;
        Destroy(this.gameObject);
    }
}
