using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{

    private void Start()
    {
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
    private void OnDestroy()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }
}
