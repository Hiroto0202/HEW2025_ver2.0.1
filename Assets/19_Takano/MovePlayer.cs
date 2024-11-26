using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5.0f;//プレイヤーの速度
    Vector2 playerMoveVec;//プレイヤーの進む向き
    Rigidbody2D player_rb;//プレイヤーの物理演算のコンポーネント


    void Start()
    {
        //RigitBodyを取得
        player_rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //スティックの読み込み
        playerMoveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //左スティックの動きを計算
        player_rb.velocity = playerMoveVec * speed;
    }
}
