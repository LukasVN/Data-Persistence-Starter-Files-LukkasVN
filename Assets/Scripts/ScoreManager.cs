using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private GameObject bestScoreGameObject;
    private TextMeshProUGUI bestScoreText;
    public string currentPlayerName;
    public static ScoreManager Instance;

    class SaveData{
        public string playername;
        public int bestScore;
    }

    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start() {
        CheckBestScoreMenu();
    }
    
    public void CheckBestScoreMenu(){
        bestScoreGameObject = GameObject.Find("Best_Score");
        bestScoreText = bestScoreGameObject.GetComponent<TextMeshProUGUI>();
        if(bestScoreGameObject == null){
            Debug.Log("Data Error");
            return;
        }
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData playerData = JsonUtility.FromJson<SaveData>(json);
            bestScoreText.text = "Best Score: "+ playerData.playername+" : "+playerData.bestScore;
        }
        else{
            Debug.Log("No best scores found");
        }
    }


    public void SaveBestScore(String name, int score){
        SaveData playerData = new SaveData();
        playerData.playername = name;
        playerData.bestScore = score;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath +"/savefile.json",json);
    }


    public void CheckLastScore(String name, int score){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData playerData = JsonUtility.FromJson<SaveData>(json);
            if(score > playerData.bestScore){
                SaveBestScore(name,score);
                bestScoreText.text = "Best Score: "+ playerData.playername+" - "+playerData.bestScore;
            }
            return;
        }
        else{
            SaveData playerData = new SaveData();
            playerData.playername = name;
            playerData.bestScore = score;

            string json = JsonUtility.ToJson(playerData);

            File.WriteAllText(Application.persistentDataPath +"/savefile.json",json);
        }
        
    }

    
    
}
