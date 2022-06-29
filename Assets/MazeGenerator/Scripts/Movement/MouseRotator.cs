using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private Rigidbody _rotatable;
    [SerializeField] private float _speed = 50;

    private bool _drag;
    private Vector2 _rotation;

    private float Speed
    {
        get => _speed;
        set => _speed = Mathf.Abs(value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _drag = true;
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            _drag = false;
    }

    private void FixedUpdate()
    {
        if (_drag)
        {
            float rotationX = Input.GetAxis(MouseX) * Mathf.Deg2Rad * Speed;
            float rotationY = Input.GetAxis(MouseY) * Mathf.Deg2Rad * Speed;
            _rotation += new Vector2(rotationX, rotationY);
            _rotatable.MoveRotation(Quaternion.Euler(_rotation.y, 0, -_rotation.x));
        }
    }
}
