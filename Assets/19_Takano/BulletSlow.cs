using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : MonoBehaviour
{
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
            Destroy(gameObject);
        }
        else
        {
            // �e�̑��x�����X�Ɍ���������
            m_rb.velocity *= m_deceleration;
        }
    }
}
