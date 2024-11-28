using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropMoney : MonoBehaviour
{
    GameObject m_obj;
    public GameObject m_dropMoney;

    Amount m_amount;

    int m_drop = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_obj=Instantiate(m_dropMoney);
        m_amount = GetComponent<Amount>();
        m_drop = m_amount.amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
