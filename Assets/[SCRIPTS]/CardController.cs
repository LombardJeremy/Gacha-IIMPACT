using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Bounce))]
public class CardController : MonoBehaviour, Iinteractable
{

    private Bounce _bounce;
    
    private bool _IsHolded = false;

    private Vector2 touchPosition;
    private Vector3 _originalRotation;

    [SerializeField] private float maxMagnitudeLenght  = 5;

    [SerializeField] private float rotationStrengh = 13.5f;
    private void Awake()
    {
        _bounce = GetComponent<Bounce>();
    }

    private void Start()
    {
        _originalRotation = transform.rotation.eulerAngles;
    }

    public void OnTouch()
    {
       // Debug.LogError("Card is being Touch");
        _bounce.StartBounce(2,0.05f, false);
    }

    public void OnHold()
    {
      //  Debug.LogError("Card is being held");
        _IsHolded = true;
        _bounce.StartBounce(3,0.1f, true);
    }

    public void OnRelease()
    {
      //  Debug.LogError("Card is being released");
        _IsHolded = false;
        _bounce.ResetTransform();
        print( "_originalRotation"+ _originalRotation);
        transform.rotation = Quaternion.Euler(_originalRotation);
    }

    public void UpdateVector(Vector3 touchedPosition)
    {
        touchPosition = touchedPosition;
    }

    private void Update()
    {
        if(_IsHolded)
        {
            Vector3 A = transform.position;
            Vector3 B = touchPosition;
            Vector3 AB = A - B;
            Vector3 afterClamped = Vector3.ClampMagnitude(AB, maxMagnitudeLenght);
            Vector3 finalVector = new Vector3(afterClamped.x * rotationStrengh, afterClamped.y * rotationStrengh, _originalRotation.z);
            transform.rotation = Quaternion.Euler(finalVector);

        }
        else
        {
        }
    }


}
