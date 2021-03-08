using System.IO;
using Joserbala.Data;
using Joserbala.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    [SerializeField] private int currentState = 0;
    [SerializeField] private UnityEvent checkStartJson;
    [SerializeField] private UnityEvent checkDeleteJson;
    [SerializeField] private UnityEvent checkDeletedAIFiles;
    [SerializeField] private UnityEvent checkFinal;
    [SerializeField]
    private string firstREADME = "User! I need you to stop doing what that AI tells you, it's gonna end badly for you, it's like a virus!\nYou need to paste the Delete.json as it is in the Commands folder, I've done the necessary changes";
    [SerializeField]
    private string secondREADME = "Great job! Now I need you to delete all the files in the ArtificialIntelligenceFiles, this will deactivate it!";
    [SerializeField]
    private string thirdREADME = "I've exposed the final file you need to delete! Delete it and we can be free!";


    private const string DELETE_JSON = "Delete.json";
    private const string START_JSON = "Start.json";
    private const string README_TXT = "README.txt";
    private const string README2_TXT = "README2.txt";

    public void StateHandler()
    {
        switch (currentState)
        {
            case 1:
                CheckStartJson();
                break;

            case 2:
                CheckDeleteJson();
                break;

            case 3:
                CheckDeletedAIFiles();
                break;

            case 4:
                CheckFinal();
                break;

            case 5:
                Application.Quit();
                break;

            default:
                Debug.LogWarning("Case not taken into account.");
                break;
        }
    }

    private void CheckStartJson()
    {
        DummyData startData = SerializerManager.Instance.DeserializeJSON(Path.Combine(FileManager.CommandsPath, START_JSON));
        if (startData != null)
        {
            if (startData.value == 1)
            {
                // Write the README.txt, preparing the game for state 2.
                FileManager.Instance.Write(Path.Combine(FileManager.ArchivePath, README_TXT), firstREADME);
                // Create the Delete.json, preparing the game for state 2.
                DummyData deleteData = new DummyData(0);
                SerializerManager.Instance.SerializeJSON(Path.Combine(FileManager.ArchivePath, DELETE_JSON), deleteData);

                checkStartJson?.Invoke();
            }
        }
    }

    private void CheckDeleteJson()
    {
        DummyData deleteData = SerializerManager.Instance.DeserializeJSON(Path.Combine(FileManager.CommandsPath, DELETE_JSON));
        if (deleteData != null)
        {
            // Write the README2.txt, preparing the game for state 3.
            FileManager.Instance.Write(Path.Combine(FileManager.ArchivePath, README2_TXT), secondREADME);

            checkDeleteJson?.Invoke();
        }
    }

    private void CheckDeletedAIFiles()
    {
        int counter = FileManager.Instance.CountFilesInDirectory(FileManager.AIFilesPath);

        if (counter == 0)
        {
            // Preparing the game for state 4.
            FileManager.Instance.Write(Path.Combine(FileManager.AIFilesPath, README_TXT), thirdREADME);
            FileManager.Instance.CreateRandomFiles(1, FileManager.AIFilesPath);

            checkDeletedAIFiles?.Invoke();
        }
    }

    private void CheckFinal()
    {
        int counter = FileManager.Instance.CountFilesInDirectory(FileManager.AIFilesPath);

        if (counter < 2)
        {
            checkFinal?.Invoke();
        }
    }

    public void DoGameStart()
    {
        DummyData jData = new DummyData(0);
        SerializerManager.Instance.SerializeJSON(Path.Combine(FileManager.CommandsPath, START_JSON), jData);
    }

    public void UpdateCurrentState()
    {
        currentState++;
    }
}
