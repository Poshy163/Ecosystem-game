using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable InconsistentNaming

namespace Main_Menu
{
    public class NameCon : MonoBehaviour
    {
        public TMP_InputField InputField;
        public TMP_Text WelcomeText;

        public void AcceptName()
        {
            if (string.IsNullOrEmpty(InputField.text)) return;
            GlobalVar.Name = InputField.text;
            SceneManager.LoadScene("Settings");
        }
    }
}