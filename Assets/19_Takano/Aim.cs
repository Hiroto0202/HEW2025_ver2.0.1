using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public InputAction m_aim;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        // InputActionの有効化
        m_aim.Enable();
    }

    private void OnDisable()
    {
        // InputActionの無効化
        m_aim.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        // moveから右スティックの入力を取得
        Vector2 m_moveInput = m_aim.ReadValue<Vector2>();
        Debug.Log("Right Stick Input: " +  m_moveInput);
        float m_angle = Mathf.Atan2(m_moveInput.y, m_moveInput.x) * Mathf.Rad2Deg; ;

        transform.rotation = Quaternion.Euler(0, 0, m_angle);
    }
}
