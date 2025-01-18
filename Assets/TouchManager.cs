using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    private InputAction _touchPosition;
    private InputAction _touchPress;
    private InputAction _holdPress;

    private Vector2 _actualTouchedPosition;
    
    private float _holdTime = 0.4f;
    private float _actualholdTime =0f;
    
    private Collider2D actualCollider;
    private Iinteractable actualIinteractable;
    
    private bool _IsHolding = false;
    

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPosition = _playerInput.actions["TouchPosition"];
        _touchPress = _playerInput.actions["SinglePress"];
        _holdPress = _playerInput.actions["HoldPress"];
    }

    private void OnEnable()
    {
        _touchPress.performed += OnTouched;
        _touchPress.performed += GetTouchPositon;
        _holdPress.performed += OnHolding;
        _holdPress.canceled += PressReleased;
        Debug.Log("Touch Action Enabled");
    }

    private void OnDisable()
    {
        _touchPress.performed -= OnTouched;
        Debug.Log("Touch Action Disabled");
    }

    private void Update()
    {
        Vector2 touchedPosition = _touchPosition.ReadValue<Vector2>();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchedPosition.x, touchedPosition.y, Camera.main.nearClipPlane));
        _actualTouchedPosition = worldPosition;
        if (_IsHolding)
        {

            actualIinteractable.UpdateVector(_actualTouchedPosition);

        }
        else
        {
            _actualholdTime = 0;

        }
    }

    private void PressReleased( InputAction.CallbackContext context)
    {
        if (!_IsHolding){return; }
        if (actualCollider != null)
        {
            actualCollider.GetComponent<Iinteractable>().OnRelease();
        }
        _IsHolding = false;
    }

    private void OnHolding(InputAction.CallbackContext context)
    {
        _IsHolding = true;
        if (actualCollider != null)
        {
            actualCollider.GetComponent<Iinteractable>().OnHold();
        }
    }

    private void GetTouchPositon(InputAction.CallbackContext context)
    {

    }
    
    private void OnTouched(InputAction.CallbackContext context)
    {
        actualCollider = GetCollider();
        if (actualCollider != null)
        {
            if (actualCollider.TryGetComponent(out Iinteractable interactable))
            {
                actualIinteractable = interactable;
                interactable.OnTouch();
            }
        }
    }
    
    private Collider2D GetCollider()
    {
        RaycastHit2D hit = Physics2D.Raycast(_actualTouchedPosition, Vector2.zero);
        if(hit.collider == null) return null;
        return hit.collider;
    }
}