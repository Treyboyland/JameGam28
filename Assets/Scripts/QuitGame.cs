using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    public void Quit(InputAction.CallbackContext context)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#elif !UNITY_WEBGL
        Application.Quit();
#endif
    }
}
