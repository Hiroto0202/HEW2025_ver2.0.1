using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float m_speed = 5.0f;//プレイヤーの速度
    Vector2 m_playerMoveVec;//プレイヤーの進む向き
    Rigidbody2D m_player_rb;//プレイヤーの物理演算のコンポーネント
    public InputAction m_aim;


    void Start()
    {
        //RigitBodyを取得
        m_player_rb=GetComponent<Rigidbody2D>();
        m_aim.Enable(); // InputAction を有効化
    }

    // Update is called once per frame
    void Update()
    {
        //スティックの読み込み
        //playerMoveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 playerMoveVec = m_aim.ReadValue<Vector2>();
        //左スティックの動きを計算
        m_player_rb.velocity = playerMoveVec * m_speed;
    }
}
