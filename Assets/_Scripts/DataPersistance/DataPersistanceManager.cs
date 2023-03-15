using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    public static DataPersistanceManager manager;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private FileHandler dataHandler;
    private GameData gameData;

    private void Awake() {
        if(manager == null)
        {
            manager = this;
        }
        else
        {
            Debug.Log("Found more than one Data Persistance Manager in the scene");
        }
    }

    private void Start() {
        this.dataHandler = new FileHandler(Application.persistentDataPath, fileName);
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No data was found! Initializing data to defaults.");
            NewGame();
        }

        Debug.Log("Loaded score = " + gameData.score);
    }

    public void SaveGame()
    {
        dataHandler.Save(gameData);

        Debug.Log("Saved score = " + gameData.score);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }
}
