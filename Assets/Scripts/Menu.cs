using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Menu : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField _nameField;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Player_Name"))
        {
             _nameField.text = PlayerPrefs.GetString("Player_Name");
        }
        else
        {
            _nameField.text = "RandomName";
        }
        
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnEndEditName()
    {
         PlayerPrefs.SetString("Player_Name", _nameField.text);
    }

}
