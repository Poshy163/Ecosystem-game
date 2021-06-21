using System;
using UnityEngine;

namespace Game
{
    public class StatsTracker : MonoBehaviour
    {
        private float _tickCounter;

        private void Update()
        {
            _tickCounter += Time.deltaTime;
            if (!(_tickCounter >= GlobalVar.CheckForStats)) return;
            _tickCounter = 0f;
            CheckForAnimal();
        }

        private static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        } // ReSharper disable Unity.PerformanceAnalysis
        private void CheckForAnimal()
        {
            var aliveAnimalsTier1 = GameObject.FindGameObjectsWithTag("Tier 1");
            var aliveAnimalsTier2 = GameObject.FindGameObjectsWithTag("Tier 2");
            var trees = GameObject.FindGameObjectsWithTag("Tree");
            var localTreeDeath = 0;

            if (trees.Length == 0)
            {
                localTreeDeath++;
                GlobalVar.StatsAdditionalInfo = $"You had 0 trees {localTreeDeath} times";
            }

            if (aliveAnimalsTier1.Length == 0) GlobalVar.StatsAdditionalInfo = "You Killed all of the apex predators";

            if (aliveAnimalsTier2.Length == 0) GlobalVar.StatsAdditionalInfo = "You Killed all of the tier 2 predators";
        }
    }
}