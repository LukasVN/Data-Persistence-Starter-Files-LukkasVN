using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameSetter : MonoBehaviour
{
    public TMP_InputField currentName;

    public void OnChangeName(){
        Debug.Log(currentName.text);
        ScoreManager.Instance.currentPlayerName = currentName.text;
    }
}
