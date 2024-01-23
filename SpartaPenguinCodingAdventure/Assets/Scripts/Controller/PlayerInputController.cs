using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController //�����Ѵ�
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        //Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        //��ֶ����� ����, �밢�� �������� �� �� ��ư 2���� ������ �Ǹ� ��Ÿ��� ������ ���� 1.4��� ������
        //��ֶ������ 1���� ū ���͸� 1�� �ڸ�
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();

        //��ũ���� ���̴� ��ǥ�� ���� ��ǥ�� �ٲ���� ��
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if(newAim.magnitude >= .9f)
            CallLookEvent(newAim);
    }
    public void OnFire(InputValue value)
    {
        //Debug.Log("OnFire" + value.ToString());
        IsAttacking = value.isPressed;
    }
}
