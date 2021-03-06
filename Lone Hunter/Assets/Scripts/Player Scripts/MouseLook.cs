using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;
    [SerializeField]
    private bool invert_Mouse;    
    [SerializeField]
    private float mouse_sensitivity = 5.0f;  

    [SerializeField]
    private Vector2 default_look_limit = new Vector2(-70f, 80f);

    private Vector2 look_Angles;
    private Vector2 current_Mouse_Look;

   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LockAndUnLockCursor();
        if (Cursor.lockState == CursorLockMode.Locked)
            LookAround();
    }

    private void LockAndUnLockCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.GameIsPaused)   
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                GameManager.Instance.PauseGame();
                Cursor.visible = true;
            } 
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                GameManager.Instance.ResumeGame();
            }
        }
    }

    private void LookAround()
    {
        current_Mouse_Look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_Angles.x += current_Mouse_Look.x * mouse_sensitivity * (invert_Mouse ? 1f : -1f);
        look_Angles.y += current_Mouse_Look.y * mouse_sensitivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_look_limit.x, default_look_limit.y);

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);
    }
}
