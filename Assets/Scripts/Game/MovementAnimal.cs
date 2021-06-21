using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable IdentifierTypo
// ReSharper disable Unity.PreferNonAllocApi

namespace Game
{
    public sealed class MovementAnimal : MonoBehaviour
    {
        [SerializeField] private Animal _localAnimal;

        private float _nowTime;

        private void Start()
        {
            _localAnimal = new Animal(Random.Range(75, 100), 0, gameObject);
        }

        private void Update()
        {
            if (_localAnimal.hunger <= 0) KillObject(_localAnimal.LocalObj);

            _localAnimal.hunger -= Time.deltaTime + Random.Range(0.001f, 0.004f);
            _localAnimal.SexualDesire += 0.005;
            _nowTime += Time.deltaTime;
            if (!(_nowTime >= GlobalVar.TimePerDay)) return;
            _nowTime = 0;
            Movement();
        }

        private void Movement()
        {
            if (_localAnimal.hunger <= Random.Range(45, 55))
                StartCoroutine(_localAnimal.Move(FoodPos()));
            else
                StartCoroutine(_localAnimal.Move(new Vector3(
                    Random.Range(-GlobalVar.CameraBoundsX, GlobalVar.CameraBoundsX),
                    Random.Range(-GlobalVar.CameraBoundsY, GlobalVar.CameraBoundsY), 0)));
        }

        private Vector3 FoodPos()
        {
            var position = _localAnimal.LocalObj.transform.position;
            var place = new Vector2(position.x, position.y);
            var colarray = Physics2D.OverlapCircleAll(place, GlobalVar.DetectionRadiusFood);
            foreach (var col in colarray)
            {
                if (!col.gameObject.CompareTag("Tree")) continue;
                _localAnimal.hunger += GlobalVar.FoodEaten;
                var vector = col.transform.position;
                Destroy(col.gameObject);
                return vector;
            }

            var results = Physics2D.OverlapCircleAll(place, GlobalVar.OtherAnimalDetectionRadius);
            foreach (var col in results)
            {
                if (_localAnimal.LocalObj.name != "Tier 1" || col.gameObject.name != "Tier 2") continue;
                var targetAnimal = col.gameObject;
                var localhost = targetAnimal.transform.position;
                KillObject(targetAnimal);
                _localAnimal.hunger += GlobalVar.FoodEaten;
                return localhost;
            }

            return new Vector3(Random.Range(-GlobalVar.CameraBoundsX, GlobalVar.CameraBoundsX),
                Random.Range(-GlobalVar.CameraBoundsY, GlobalVar.CameraBoundsY), 0);
        }


        private void KillObject(GameObject obj)
        {
            GlobalVar.AnimalsKilled++;
            Destroy(obj);
        }

        [Serializable]
        private class Animal
        {
            public double hunger;
            public double SexualDesire;
            private readonly float _moveSpeed;
            public readonly GameObject LocalObj;

            public Animal(double hungerMax, double sexualdesire, GameObject localobj)
            {
                LocalObj = localobj;
                hunger = hungerMax - Random.Range(0, 35);
                SexualDesire = sexualdesire;
                _moveSpeed = GlobalVar.AnimalMoveSpeed;
            }

            public IEnumerator Move(Vector3 destination)
            {
                var timeSinceStarted = 0f;
                while (true)
                {
                    timeSinceStarted += Time.deltaTime;
                    LocalObj.transform.position = Vector3.Lerp(LocalObj.transform.position, destination,
                        timeSinceStarted / 9 * _moveSpeed);
                    if (LocalObj.transform.position == destination) yield break;
                    yield return null;
                }
            }
        }
    }
}