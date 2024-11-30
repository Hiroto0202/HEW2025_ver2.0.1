using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{

    public float m_fMoveSpeed = 20.0f;//弾のスピード
    public GameObject m_BulletObj;//弾のオブジェクト
    [SerializeField] private float m_time = 0;//速度
    public InputAction m_aim;//どのスティックの入力にするかの変数
    private Gamepad m_gamepad;//キー入力検知
    public float m_deceleration = 0.98f; // 弾の減速率（調整可能）

    void Start()
    {
        m_aim.Enable(); // InputAction を有効化
    }

    // Update is called once per frame
    void Update()
    {
        Key();//キー入力検知
        Vector2 m_moveInput = m_aim.ReadValue<Vector2>();// moveから右スティックの入力を取得
        Debug.Log("Right Stick Input: " + m_moveInput);

        if (m_gamepad.leftTrigger.wasPressedThisFrame)
        {
            Shoot(m_moveInput);
        }

    }
    //弾発射の関数
    private void Shoot(Vector2 aimDirection)
    {
        Debug.Log("弾発射");

        //if (time > 2.0f)
        {
            //****弾のインスタンス生成****
            GameObject m_cloneObj;                                                       //クローンの変数
            m_cloneObj = Instantiate(m_BulletObj, transform.position, Quaternion.identity);//複製
            Rigidbody2D rb;                                                            //RigidBody取得
            if (m_cloneObj != null)
            {
                Vector2 shootDirection = aimDirection.normalized;                          //弾の向きを計算して設定
                rb = m_cloneObj.GetComponent<Rigidbody2D>();                                 //座標を取得する
                rb.AddForce(shootDirection * m_fMoveSpeed, ForceMode2D.Impulse);             //力を加える
                                                                                           // 弾の速度を徐々に減速させる
            }
            m_time = 0.0f;
        }


    }

    void Key()
    {
        // 接続されたゲームパッドを取得
        m_gamepad = Gamepad.current;
        if (m_gamepad == null)
        {
            Debug.Log("ゲームパッドが接続されていません");
            return;
        }

        // ゲームパッドの各ボタンをチェックし、押されている場合にログ出力
        if (m_gamepad.buttonSouth.wasPressedThisFrame) Debug.Log("Aボタンが押されました");
        if (m_gamepad.buttonEast.wasPressedThisFrame) Debug.Log("Bボタンが押されました");
        if (m_gamepad.buttonWest.wasPressedThisFrame) Debug.Log("Xボタンが押されました");
        if (m_gamepad.buttonNorth.wasPressedThisFrame) Debug.Log("Yボタンが押されました");

        if (m_gamepad.leftShoulder.wasPressedThisFrame) Debug.Log("左肩ボタンが押されました");
        if (m_gamepad.rightShoulder.wasPressedThisFrame) Debug.Log("右肩ボタンが押されました");

        if (m_gamepad.leftTrigger.wasPressedThisFrame) Debug.Log("左トリガーが押されました");
        if (m_gamepad.rightTrigger.wasPressedThisFrame) Debug.Log("右トリガーが押されました");

        if (m_gamepad.startButton.wasPressedThisFrame) Debug.Log("スタートボタンが押されました");
        if (m_gamepad.selectButton.wasPressedThisFrame) Debug.Log("セレクトボタンが押されました");

        if (m_gamepad.dpad.up.wasPressedThisFrame) Debug.Log("D-Pad 上が押されました");
        if (m_gamepad.dpad.down.wasPressedThisFrame) Debug.Log("D-Pad 下が押されました");
        if (m_gamepad.dpad.left.wasPressedThisFrame) Debug.Log("D-Pad 左が押されました");
        if (m_gamepad.dpad.right.wasPressedThisFrame) Debug.Log("D-Pad 右が押されました");
    }
}
