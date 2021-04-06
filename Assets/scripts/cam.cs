using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject sasuge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sasuge.transform)
        {
            transform.position = new Vector3(sasuge.transform.position.x + 3, sasuge.transform.position.y + 8, 12f);
        }
    }
}
