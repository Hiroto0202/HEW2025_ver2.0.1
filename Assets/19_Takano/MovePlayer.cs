using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float m_speed = 5.0f;//�v���C���[�̑��x
    Vector2 m_playerMoveVec;//�v���C���[�̐i�ތ���
    Rigidbody2D m_player_rb;//�v���C���[�̕������Z�̃R���|�[�l���g
    public InputAction m_aim;


    void Start()
    {
        //RigitBody���擾
        m_player_rb=GetComponent<Rigidbody2D>();
        m_aim.Enable(); // InputAction ��L����
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�B�b�N�̓ǂݍ���
        //playerMoveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 playerMoveVec = m_aim.ReadValue<Vector2>();
        //���X�e�B�b�N�̓������v�Z
        m_player_rb.velocity = playerMoveVec * m_speed;
    }
}
