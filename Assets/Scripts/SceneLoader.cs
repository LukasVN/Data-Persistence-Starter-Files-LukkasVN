using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string scene_Name;
    public void LoadScene(){
        SceneManager.LoadScene(scene_Name);
    }
}
