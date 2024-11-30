using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float m_speed = 0.5f;    

    GameObject m_player;            
    Transform m_playerTrans;        

    GameObject m_dust;            
    Transform m_dustTrans;        

    GameObject m_money;           
    Transform m_moneyTrans;        

    KeyCode m_space = KeyCode.Space;
    public bool m_throwFlg = false;

    bool m_discoverPlayer;
    bool m_discoverMoney;
    bool m_discoverDust;

    // Start is called before the first frame update
    void Start()
    {
        
        m_player = GameObject.Find("Player");
        m_playerTrans = m_player.transform;

        
        m_dust = GameObject.Find("Dust");
        m_dustTrans = m_dust.transform;

        
        m_money = GameObject.Find("ThrowMoney");
        m_moneyTrans = m_money.transform;
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
        m_discoverDust = this.GetComponent<Vision>().m_discoverDust;


        if (m_discoverMoney)
        {
            Move(this.transform.position, m_money.transform.position, m_speed * Time.deltaTime);
        }
        else if (m_discoverPlayer)
        {
            Move(this.transform.position, m_playerTrans.position, m_speed * Time.deltaTime);
        }
        else if (m_discoverDust)
        {
            Move(this.transform.position, m_dustTrans.position, m_speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {

    }

    
    void Move(Vector2 _current, Vector2 _target, float _maxDistanceDelta)
    {

        float num1 = _target.x - _current.x;
        float num2 = _target.y - _current.y;
        float num3 = num1 * num1 + num2 * num2;
        if (num3 == 0f || (_maxDistanceDelta >= 0f && num3 <= _maxDistanceDelta * _maxDistanceDelta))
        {
            transform.position = _target;
        }

        float num4 = (float)Mathf.Sqrt(num3);
        transform.position = new Vector2(_current.x + num1 / num4 * _maxDistanceDelta, _current.y + num2 / num4 * _maxDistanceDelta);

    }
}
