using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5.0f;//�v���C���[�̑��x
    Vector2 playerMoveVec;//�v���C���[�̐i�ތ���
    Rigidbody2D player_rb;//�v���C���[�̕������Z�̃R���|�[�l���g
    public InputAction m_aim;


    void Start()
    {
        //RigitBody���擾
        player_rb=GetComponent<Rigidbody2D>();
        m_aim.Enable(); // InputAction ��L����
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�B�b�N�̓ǂݍ���
        //playerMoveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 playerMoveVec = m_aim.ReadValue<Vector2>();
        //���X�e�B�b�N�̓������v�Z
        player_rb.velocity = playerMoveVec * speed;
    }
}
