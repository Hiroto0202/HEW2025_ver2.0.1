using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_target; // プレイヤーを指定
    public float m_smoothSpeed = 0.125f; // カメラの追従速度
    public Vector3 m_offset; // カメラの位置調整用

    void LateUpdate()//フレームの最後に処理
    {
        if (m_target != null)
        {
            //プレイヤーの座標から見やすい位置に変更
            Vector3 m_desiredPosition = m_target.position + m_offset;
            //滑らかにカメラを移動
            Vector3 m_smoothedPosition = Vector3.Lerp(transform.position, m_desiredPosition, m_smoothSpeed);
            //カメラ位置を移動
            transform.position = m_smoothedPosition;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_target.position);

    }
}
