using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Game.GlobalVar;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        private static Sprite _privateApexSprite;
        private static Sprite _privateT2Sprite;

        public Sprite apexSprite;
        public Sprite t2Sprite;

        [Header("GameData")] public TMP_Text currentDayTxt;

        public TMP_Text hourtxt;
        public Image timerBox;
        private int _hour;

        private float _movetimer;

        public void Start()
        {
            _privateT2Sprite = t2Sprite;
            _privateApexSprite = apexSprite;
            SpawnShit();
        }

        private void Update()
        {
            _movetimer += Time.deltaTime;
            timerBox.fillAmount = _movetimer / TimePerDay;
            if (!(_movetimer >= TimePerDay)) return;
            _movetimer = 0;
            if (_hour < 24)
            {
                NewTreeChance();
                _hour++;
                hourtxt.text = $"{_hour}:00";
            }
            else
            {
                NewDay();
            }
        }


        private static void SpawnShit()
        {
            for (var i = 1; i <= AmountOfTrees; i++)
            {
                var localTree = Instantiate(TreePref, TreeParent);
                localTree.tag = "Tree";
                localTree.transform.position = new Vector2(Random.Range(-CameraBoundsX, CameraBoundsX),
                    Random.Range(-CameraBoundsY, CameraBoundsY));
            }

            for (var i = 1; i <= AmountOfTier1; i++)
            {
                var localTier1 = Instantiate(AnimalPref, AnimalParent);
                localTier1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                localTier1.name = "Tier 1";
                localTier1.tag = "Tier 1";
                localTier1.GetComponent<SpriteRenderer>().sprite = _privateApexSprite;
                localTier1.transform.position = new Vector2(Random.Range(-CameraBoundsX, CameraBoundsX),
                    Random.Range(-CameraBoundsY, CameraBoundsY));
            }

            for (var i = 1; i <= AmountOfTier2; i++)
            {
                var localTier2 = Instantiate(AnimalPref, AnimalParent);
                localTier2.name = "Tier 2";
                localTier2.tag = "Tier 2";
                localTier2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                localTier2.GetComponent<SpriteRenderer>().sprite = _privateT2Sprite;
                localTier2.transform.position = new Vector2(Random.Range(-CameraBoundsX, CameraBoundsX),
                    Random.Range(-CameraBoundsY, CameraBoundsY));
            }
        }

        private void NewDay()
        {
            CurrentDay++;
            DaysLasted++;
            _hour = 0;
            hourtxt.text = $"{_hour}:00";
            if (CurrentDay == 2) SceneManager.LoadScene("End Scene");
            currentDayTxt.text = $"Day: {CurrentDay}";
        }

        private void NewTreeChance()
        {
            if (Random.Range(1, 4) != 3) return;
            var localTree = Instantiate(TreePref, TreeParent);
            localTree.transform.position = new Vector2(Random.Range(-CameraBoundsX, CameraBoundsX),
                Random.Range(-CameraBoundsY, CameraBoundsY));
        }
    }
}