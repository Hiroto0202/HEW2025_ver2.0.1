using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActMoney : MonoBehaviour
{
//    public int m_money = 0;
    public int m_pocket = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O�� "Target" ���m�F
        if (collision.gameObject.tag == "money")
        {
            Debug.Log("money�ƏՓ˂��܂����I");
            Destroy(collision.gameObject);
            m_pocket++;
        }
    }
}
