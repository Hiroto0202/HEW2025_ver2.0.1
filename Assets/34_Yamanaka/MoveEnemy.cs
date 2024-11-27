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

    GameObject m_dust;            // 目標入力用インスタンス
    Transform m_dustTrans;        // 目標の情報

    GameObject m_money;            // 目標入力用インスタンス
    Transform m_moneyTrans;        // 目標の情報

    KeyCode m_space = KeyCode.Space;
    public bool m_throwFlg = false;

    bool m_discoverPlayer;
    bool m_discoverMoney;

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

        // ゴミを探す
        m_player = GameObject.Find("Dust");
        m_playerTrans = m_player.transform;

        // お金を探す
        m_player = GameObject.Find("");
        m_playerTrans = m_player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(m_space))
        {
            m_throwFlg = !m_throwFlg;
        }

        m_discoverPlayer = this.GetComponent<Vision>().m_discoverPlayer;
        m_discoverMoney = this.GetComponent<Vision>().m_discoverMoney;


        if (m_discoverMoney)
        {
            Move(this.transform.position,m_player.transform.position);
        }
        else if(m_discoverPlayer)
        {
            Move(this.transform.position, m_player.transform.position);
        }
    }

    private void FixedUpdate()
    {

    }

    // 目標を見つけた時の処理
    void Move(Vector2 _current, Vector2 _target)
    {
        Vector2 _enePos = this.transform.position;
        m_player = GameObject.Find("Player");
        Vector2 _targetPos = m_player.transform.position;
        float _maxDistanceDelta = m_speed * Time.deltaTime;


        float num1 = _targetPos.x - _enePos.x;
        float num2 = _targetPos.y - _enePos.y;
        float num3 = num1 * num1 + num2 * num2;
        if (num3 == 0f || (_maxDistanceDelta >= 0f && num3 <= _maxDistanceDelta * _maxDistanceDelta))
        {
            transform.position = _targetPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, m_playerTrans.position, m_speed * Time.deltaTime);
        float num4 = (float)Mathf.Sqrt(num3);
        transform.position = new Vector2(_enePos.x + num1 / num4 * _maxDistanceDelta, _enePos.y + num2 / num4 * _maxDistanceDelta);

    }

}
