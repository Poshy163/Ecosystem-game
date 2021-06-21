using UnityEngine;

namespace Game
{
    public class GlobalVar : MonoBehaviour
    {
        public const float CameraBoundsY = 7;
        public const float CameraBoundsX = 12;

        public const int MaxAmountOfChar = 50;

        public const float AnimalMoveSpeed = 1f;
        public const float DetectionRadiusFood = 2;
        public const float OtherAnimalDetectionRadius = 1;


        public const float CheckForStats = 5f;

        public const float FoodEaten = 10f;
        public static GameObject TreePref;
        public static Transform TreeParent;

        public static int AmountOfTrees;
        public static int AmountOfTier1;
        public static int AmountOfTier2;

        public static GameObject AnimalPref;
        public static Transform AnimalParent;
        public static int TimePerDay;

        public static int CurrentDay = 1;
        public static string Name;
        public static int FpsMax;

        private void Awake()
        {
            AssignToStatic();
        }

        #region TempObjs

        public GameObject tTreePref;
        public Transform tTreeParent;
        public GameObject tAnimalPref;
        public Transform tAnimalParent;

        private void AssignToStatic()
        {
            TreePref = tTreePref;
            TreeParent = tTreeParent;
            AnimalPref = tAnimalPref;
            AnimalParent = tAnimalParent;
        }

        #endregion

        #region GameStats

        public static int DaysLasted;
        public static int AnimalsKilled;
        public static string StatsAdditionalInfo;
        public static int WeeksLasted;

        #endregion
    }
}