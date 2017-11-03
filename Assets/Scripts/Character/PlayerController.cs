using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float lookSensitivity = 3.0f;
    
    [SerializeField]
    private float jumpSpeed = 20f;

    public bool grounded;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.collider.tag == "Untagged")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Untagged")
        {
            grounded = false;
        }
    }

    void Update()
    {
        //calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Final Movement Vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply Movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply Rotation
        motor.Rotate(_rotation);

        //Calculate Camera rotation as a 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        //Apply Camera Rotation
        motor.RotateCamera(_cameraRotationX);

        //calculate thruster force
        Vector3 _jumpSpeed = Vector3.zero;
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            _jumpSpeed = Vector3.up * jumpSpeed;
        }

        //Apply the thruster force
        motor.ApplyJump(_jumpSpeed);
    }
}
