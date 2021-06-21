using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Game.GlobalVar;

namespace Game
{
    public class SettingsSetter : MonoBehaviour
    {
        public TMP_Text debug;

        public void SetInfo()
        {
            try
            {
                FpsMax = int.Parse(GameObject.Find("FPS").GetComponent<TMP_InputField>().text);
            }
            catch
            {
                // ignored
            }

            if (FpsMax > 0)
            {
                Application.targetFrameRate = FpsMax;
                QualitySettings.vSyncCount = 0;
            }

            try
            {
                AmountOfTier1 = int.Parse(GameObject.Find("Tier 1").GetComponent<TMP_InputField>().text);
                AmountOfTier2 = int.Parse(GameObject.Find("Tier 2").GetComponent<TMP_InputField>().text);
                AmountOfTrees = int.Parse(GameObject.Find("Tree").GetComponent<TMP_InputField>().text);
                TimePerDay = int.Parse(GameObject.Find("Time per day").GetComponent<TMP_InputField>().text);
                if (AmountOfTier1 <= 0 && AmountOfTier2 <= 0 && AmountOfTrees <= 0)
                {
                    debug.text = "You need more than 0 of each type";
                    return;
                }

                if (AmountOfTier1 > MaxAmountOfChar ||
                    AmountOfTier2 > MaxAmountOfChar ||
                    AmountOfTrees > MaxAmountOfChar)
                    debug.text = $"Nice try, No more than {MaxAmountOfChar} things per box";
                else if (TimePerDay < 2 || TimePerDay > 60)
                    debug.text = "Time must be above 1 and below 60!";
                else
                    SceneManager.LoadScene("GameScene");
            }
            catch
            {
                debug.text = "Error, All values must be a whole number";
            }
        }
    }
}