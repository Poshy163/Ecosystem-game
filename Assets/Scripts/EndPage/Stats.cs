using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Game.GlobalVar;


namespace EndPage
{
    public class Stats : MonoBehaviour
    {
        private void Awake()
        {
            DisplayStats();
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void DisplayStats()
        {
            var txt = GameObject.Find("StatsTxt").GetComponent<TextMeshProUGUI>();
            txt.text = $"{StatsAdditionalInfo}\n{AnimalsKilled} Animals died! \nYou lasted {DaysLasted} days \n" +
                       "";
        }
    }
}