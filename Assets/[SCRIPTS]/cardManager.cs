using UnityEngine;

public class cardManager : MonoBehaviour
{
    
}

public interface Iinteractable
{
    public void OnTouch();
    public void OnHold();
    public void OnRelease();
    public void UpdateVector(Vector3 touchedPosition);
}