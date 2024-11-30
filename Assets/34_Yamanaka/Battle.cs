using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    DropMoney m_drop;

    // Start is called before the first frame update
    public void Start()
    {
        m_drop = GetComponent<DropMoney>();
        m_drop.Start();
    }

    // Update is called once per frame
    public void Update()
    {

    }
}
