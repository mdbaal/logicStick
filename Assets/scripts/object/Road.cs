using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    GameObject[] roadPieces;
    public float animationSpeed = 0;
    int index = 0;

    public void init(GameObject[] road)
    {
        roadPieces = road;
        animationSpeed = .5f;
        this.gameObject.GetComponent<Conveyer>().length = this.roadPieces.Length;
    }

    void animate()
    {
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

	void Update () {
        
        if (animationSpeed < 0)
        { 
            animate();
            this.GetComponent<Conveyer>().send();
            animationSpeed = .2f;
        }
        animationSpeed -= Time.deltaTime;
    }
}
