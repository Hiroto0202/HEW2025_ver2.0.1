using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

public class MoveEnemy : MonoBehaviour
{
    Rigidbody2D m_rb;               // Rigidbody2D取得
    public Vector2 m_moveForward;   // 移動度
    public float m_speed = 0.5f;    // 移動速度

    GameObject m_player;            // 目標入力用インスタンス
    Transform m_playerTrans;        // 目標の情報

    KeyCode m_space = KeyCode.Space;
    public static bool m_throwFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D取得
        m_rb = GetComponent<Rigidbody2D>();


        // 移動度初期化
        m_moveForward.x = 1.0f;

        // プレイヤーを探す
        m_player = GameObject.Find("Player");
        m_playerTrans = m_player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(m_space))
        {
            m_throwFlg = !m_throwFlg;
        }

        if (Vision.m_discoverPlayer)
        {
            Move();
        }

    }

    private void FixedUpdate()
    {

    }

    // 目標を見つけた時の処理
    void Move()
    {


        transform.position = Vector3.MoveTowards(transform.position, m_playerTrans.position, m_speed * Time.deltaTime);

    }

}
