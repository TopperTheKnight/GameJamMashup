using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionAttribute : MonoBehaviour {

    public int layerNum = 0;
    public List<int> layersToIgnore = new List<int>();

    private string layer;

    void Start () {

        foreach (var item in layersToIgnore)
        {
            Physics2D.IgnoreLayerCollision(layerNum, item, true);
        }

    }
}
