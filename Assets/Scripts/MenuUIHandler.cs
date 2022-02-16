using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

//usings in editor
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_InputField userNameInput;


    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.Instance.LoadDataJson())
        {
            scoreText.text = $"Best Score: {ScoreManager.Instance.Name} {ScoreManager.Instance.Score}";
            userNameInput.text = ScoreManager.Instance.Name;
        }
    }



    //Start new game
    public void StartNew()
    {
        //Save the entered name
        ScoreManager.Instance.EnteredName = userNameInput.text;

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
