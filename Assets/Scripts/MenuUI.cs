using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private GameManager GameManager;

    public static MenuUI Instance;

    [SerializeField]
    private InputField Input;

    public Text BestScoreText;
    private string Name;
    private int Score;
    private string CurrentName;


    private void Awake()
    {
        Name = GameManager.LoadBestName();
        Score = GameManager.LoadBestScore();
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = "Best score: " + Name + " " + Score;
        Input.onEndEdit.AddListener(SubmitName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ResetBestResult()
    {
        GameManager.ResetBestResult();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SubmitName(string input)
    {
        CurrentName = input;
        Debug.Log(input);
    }

    public string GetCurrentName()
    {
        return CurrentName;
    }






}
