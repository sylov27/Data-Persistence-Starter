using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField userNameInput;
    [SerializeField] private TextMeshProUGUI bestScoreText;


    // Start is called before the first frame update
    void Start()
    {
        string userName = PersistManager.persistentManager.bestUserName;
        int bestScore = PersistManager.persistentManager.bestScore;

        if(userName != null)
        {
            bestScoreText.text = "Best Score : " + userName + " : " + bestScore;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        string userName = userNameInput.text;

        PersistManager.persistentManager.userName = userName;

        SceneManager.LoadScene(1);
    }

    public void InitData()
    {
        PersistManager.persistentManager.InitTheData();

        bestScoreText.text = "Best Score";
    }


    public void QuitGame()
    {
        PersistManager.persistentManager.SaveTheData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    
}
