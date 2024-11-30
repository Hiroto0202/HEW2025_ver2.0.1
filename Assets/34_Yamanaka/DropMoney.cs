using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropMoney : MonoBehaviour
{
    GameObject m_obj;
    public GameObject m_dropMoney;

    // Start is called before the first frame update
    public void Start()
    {
        m_obj = Instantiate(m_dropMoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
