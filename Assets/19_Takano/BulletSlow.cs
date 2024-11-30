using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : MonoBehaviour
{
    public float m_deceleration = 0.98f; // 減速率（調整可能）
    private Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       

        // 弾の速度が一定以下になったら削除
        if (m_rb.velocity.sqrMagnitude < 0.1f)
        {
            Destroy(gameObject);
        }
        else
        {
            // 弾の速度を徐々に減速させる
            m_rb.velocity *= m_deceleration;
        }
    }
}
