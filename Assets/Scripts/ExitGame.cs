using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameMenu(){
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
        Application.Quit();
    }
}
