using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSCodeEditor;

public class MoveEnemy : MonoBehaviour
{
    Rigidbody2D m_rb;               // Rigidbody2D�擾
    public Vector2 m_moveForward;   // �ړ��x
    public float m_speed = 0.5f;    // �ړ����x

    GameObject m_player;            // �ڕW���͗p�C���X�^���X
    Transform m_playerTrans;        // �ڕW�̏��

    KeyCode m_space = KeyCode.Space;
    public static bool m_throwFlg = false;

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

    // �ڕW�����������̏���
    void Move()
    {


        transform.position = Vector3.MoveTowards(transform.position, m_playerTrans.position, m_speed * Time.deltaTime);

    }

}
