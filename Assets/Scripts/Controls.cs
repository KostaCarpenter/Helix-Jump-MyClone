using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Level;
    public float Sensitiivity;

    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * Sensitiivity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
