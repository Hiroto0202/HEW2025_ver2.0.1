using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoney : MonoBehaviour
{
    GameObject m_obj;
    public GameObject m_dropMoney;

    // Start is called before the first frame update
    public void Start()
    {
        m_obj = Instantiate(m_dropMoney);
        m_obj.transform.position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
