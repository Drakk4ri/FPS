using UnityEngine;
using static Models;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    
    private DefaultInput defaultInput;
    public Vector2 input_Movement;
    public Vector2 input_View;

    private Vector3 newCameraRotation;
    private Vector3 newPlayerRotation;

    [Header("References")]
    public Transform cameraHolder;
    [SerializeField] private WeaponController weaponController;

    [Header("Settings")]
    public PlayerSettingsModel playerSettings;
    public float viewClampYmin = -70;
    public float viewClampYmax = 90;


    private void Awake()
    {
        defaultInput = new DefaultInput();
        defaultInput.Player.Movement.performed += e => input_Movement = e.ReadValue<Vector2>();
        defaultInput.Player.View.performed += e => input_View = e.ReadValue<Vector2>();

        defaultInput.Weapon.fire.performed += e => Shooting();

        defaultInput.ChangeWeapon.changeToNext.performed += e => ChangeToNextWeapon();

        defaultInput.Enable();

        newCameraRotation = cameraHolder.localRotation.eulerAngles;
        newPlayerRotation = transform.localRotation.eulerAngles;

        characterController = GetComponent<CharacterController>();

        Cursor.visible = false;
    }

   
    private void Update()
    {
        CalculateView();
        CalculateMovement();
    }

    private void OnEnable()
    {
        ObjectToDestroy.OnObjectDestroyed += EventTest;
    }

    private void OnDisable()
    {
        ObjectToDestroy.OnObjectDestroyed -= EventTest;
    }

    private void Shooting()
    {
        weaponController.CalculateShoooting();
    }


    public void ChangeToNextWeapon()
    {
        weaponController.switchWeapons((weaponController.weaponIndicator < 2) ? weaponController.weaponIndicator + 1 : 0);
    }


    private void CalculateView()
    {
        newPlayerRotation.y += playerSettings.ViewXSensitivity * (playerSettings.ViewXInverted ? -input_View.x : input_View.x) * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(newPlayerRotation);


        newCameraRotation.x += playerSettings.ViewYSensitivity * (playerSettings.ViewYInverted ? input_View.y : -input_View.y) * Time.deltaTime;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, viewClampYmin , viewClampYmax);
        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);
    }

    private void CalculateMovement()
    {
        var verticalSpeed = playerSettings.walkingForawrdSpeed * input_Movement.y * Time.deltaTime;
        var horizontalSpeed = playerSettings.walskingStrafeSpreed * input_Movement.x * Time.deltaTime;


        var newMovementSpeed = new  Vector3(horizontalSpeed, 0 , verticalSpeed);
        newMovementSpeed = transform.TransformDirection(newMovementSpeed);

        characterController.Move(newMovementSpeed);
    }

    private void EventTest()
    {
        Debug.Log("EventTest");
    }
}
