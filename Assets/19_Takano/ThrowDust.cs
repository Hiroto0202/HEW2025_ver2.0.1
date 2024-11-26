using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowDust : MonoBehaviour
{
    public float fMoveSpeed = 20.0f;//弾のスピード
    public GameObject BulletObj;//弾のオブジェクト
    [SerializeField] private float time = 0;//速度
    public InputAction m_aim;//どのスティックの入力にするかの変数
    private Gamepad gamepad;//キー入力検知

    void Start()
    {
        m_aim.Enable(); // InputAction を有効化
    }

    // Update is called once per frame
    void Update()
    {
        Key();//キー入力検知
        Vector2 moveInput = m_aim.ReadValue<Vector2>();// moveから右スティックの入力を取得
        Debug.Log("Right Stick Input: " + moveInput);

        if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            Shoot(moveInput);
        }

    }
    //弾発射の関数
    private void Shoot(Vector2 aimDirection)
    {
        Debug.Log("弾発射");

        //if (time > 2.0f)
        {
            //****弾のインスタンス生成****
            GameObject cloneObj;                                                       //クローンの変数
            cloneObj = Instantiate(BulletObj, transform.position, Quaternion.identity);//複製
            Rigidbody2D rb;                                                            //RigidBody取得
            Vector2 shootDirection = aimDirection.normalized;                          //弾の向きを計算して設定
            rb = cloneObj.GetComponent<Rigidbody2D>();                                 //座標を取得する
            rb.AddForce(shootDirection * fMoveSpeed, ForceMode2D.Impulse);             //力を加える
            time = 0.0f;
        }


    }

    void Key()
    {
        // 接続されたゲームパッドを取得
        gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("ゲームパッドが接続されていません");
            return;
        }

        // ゲームパッドの各ボタンをチェックし、押されている場合にログ出力
        if (gamepad.buttonSouth.wasPressedThisFrame) Debug.Log("Aボタンが押されました");
        if (gamepad.buttonEast.wasPressedThisFrame) Debug.Log("Bボタンが押されました");
        if (gamepad.buttonWest.wasPressedThisFrame) Debug.Log("Xボタンが押されました");
        if (gamepad.buttonNorth.wasPressedThisFrame) Debug.Log("Yボタンが押されました");

        if (gamepad.leftShoulder.wasPressedThisFrame) Debug.Log("左肩ボタンが押されました");
        if (gamepad.rightShoulder.wasPressedThisFrame) Debug.Log("右肩ボタンが押されました");

        if (gamepad.leftTrigger.wasPressedThisFrame) Debug.Log("左トリガーが押されました");
        if (gamepad.rightTrigger.wasPressedThisFrame) Debug.Log("右トリガーが押されました");

        if (gamepad.startButton.wasPressedThisFrame) Debug.Log("スタートボタンが押されました");
        if (gamepad.selectButton.wasPressedThisFrame) Debug.Log("セレクトボタンが押されました");

        if (gamepad.dpad.up.wasPressedThisFrame) Debug.Log("D-Pad 上が押されました");
        if (gamepad.dpad.down.wasPressedThisFrame) Debug.Log("D-Pad 下が押されました");
        if (gamepad.dpad.left.wasPressedThisFrame) Debug.Log("D-Pad 左が押されました");
        if (gamepad.dpad.right.wasPressedThisFrame) Debug.Log("D-Pad 右が押されました");
    }
}
