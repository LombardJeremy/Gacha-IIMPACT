using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardRotation : MonoBehaviour
{

    public InputAction ClickUI;
    public InputActionMap ClickUIMap;
    public InputBinding ClickUIBinding;
    private Vector2 mousePos;

    private void Start()
    {
        ClickUI.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        
    }

    private string GetClickPosition()
    {
        return mousePos.ToString();
    }

    private void Update()
    {
        print(GetClickPosition());
    }
}
