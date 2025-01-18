using System;
using System.Collections;
using UnityEngine;

public class CardController : MonoBehaviour, Iinteractable
{

    private Bounce _bounce;
    
    private bool _IsHolded = false;

    private Vector2 touchPosition;
    private Quaternion originalRotation;

    [SerializeField] private float rotationStrengh;
    private void Awake()
    {
        _bounce = GetComponent<Bounce>();
        originalRotation = transform.rotation;
    }

    public void OnTouch()
    {
        Debug.LogError("Card is being Touch");
        _bounce.StartBounce(1,0.05f, false);
    }

    public void OnHold()
    {
        Debug.LogError("Card is being held");
        _IsHolded = true;
        _bounce.StartBounce(2,0.1f, true);
    }

    public void OnRelease()
    {
        Debug.LogError("Card is being released");
        _IsHolded = false;
        _bounce.ResetBounce();
        transform.rotation = originalRotation;
    }

    public void UpdateVector(Vector2 touchedPosition)
    {
        Debug.LogError("Card is being ROTATED");

        touchPosition = touchedPosition;
    }

    private void Update()
    {
        if(_IsHolded)
        {
            Vector2 A = transform.position;
            Vector2 B = touchPosition;

            Vector2 AB = A - B;
            transform.rotation = Quaternion.Euler(AB * rotationStrengh);
            
        }
        else
        {
            
        }
    }


}
