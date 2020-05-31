using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour {

    public bool lockCursor, m_cursorIsLocked;

    private void Start() {
        lockCursor = true;
    }

    public void SetCursorLock(bool value) {
        lockCursor = value;
        if (!lockCursor) {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock() {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate() {

        if (Input.GetKeyUp(KeyCode.Escape) && m_cursorIsLocked) {
            m_cursorIsLocked = false;
        //} else if (Input.GetMouseButtonUp(0)) {
        } else if (Input.GetKeyUp(KeyCode.Escape) && !m_cursorIsLocked) {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else if (!m_cursorIsLocked) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
