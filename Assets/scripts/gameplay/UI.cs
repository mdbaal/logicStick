using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {
   public Text controls;

    private void Start()
    {
        controls.text = " Camera: \n w = up\n s = down \n a = left\n d = right\n mouseWheel = zoom\n\n Building: \n c = collector\n f = factory\n r = road\n";
    }

}
