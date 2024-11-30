using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : MonoBehaviour
{
    //public float m_deleteTime = 1.0f;    // �폜����b��
    //public float m_sleepTime = 0;        // �o�ߎ���
    public float m_deceleration = 0.98f; // �������i�����\�j
    private Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       

        // �e�̑��x�����ȉ��ɂȂ�����폜
        if (m_rb.velocity.sqrMagnitude < 0.1f)
        {
            //m_sleepTime += Time.deltaTime;
            //if(m_sleepTime > m_deleteTime)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // �e�̑��x�����X�Ɍ���������
            m_rb.velocity *= m_deceleration;
        }
    }
}
