using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amount : MonoBehaviour
{
    public int min = 100;
    public int max = 500;

    public int amount = 0;

    // Start is called before the first frame update
    void Start()
    {
        amount = Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
