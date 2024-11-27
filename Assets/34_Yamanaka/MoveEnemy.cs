using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;
using static UnityEngine.GraphicsBuffer;

public class MoveEnemy : MonoBehaviour
{
    Rigidbody2D m_rb;               // Rigidbody2D�擾
    public Vector2 m_moveForward;   // �ړ��x
    public float m_speed = 0.5f;    // �ړ����x

    GameObject m_player;            // �ڕW���͗p�C���X�^���X
    Transform m_playerTrans;        // �ڕW�̏��

    KeyCode m_space = KeyCode.Space;
    public bool m_throwFlg = false;

    bool m_discoverThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D�擾
        m_rb = GetComponent<Rigidbody2D>();


        // �ړ��x������
        m_moveForward.x = 1.0f;

        // �v���C���[��T��
        m_player = GameObject.Find("Player");
        m_playerTrans = m_player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(m_space))
        {
<<<<<<< Updated upstream
            m_throwFlg = true;
        }

        if (m_throwFlg)
        {
<<<<<<< Updated upstream
            m_throwFlg = false;
=======
            m_throwFlg = !m_throwFlg;
        }

        m_discoverThrow = this.GetComponent<Vision>().m_discoverPlayer;

        if (m_discoverThrow)
        {
            Move();
>>>>>>> Stashed changes
=======
            Move();
>>>>>>> Stashed changes
        }

    }

    private void FixedUpdate()
    {

    }

    // �ڕW�����������̏���
    void Move()
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

        float num4 = (float)Mathf.Sqrt(num3);
        transform.position = new Vector2(_enePos.x + num1 / num4 * _maxDistanceDelta, _enePos.y + num2 / num4 * _maxDistanceDelta);

    }

}
