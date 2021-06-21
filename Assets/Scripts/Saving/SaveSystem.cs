using System;
using System.Security.Cryptography;
using System.Text;
using Game;
using UnityEngine;


// ReSharper disable InconsistentNaming
#pragma warning disable 169

namespace Saving
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField] private string UserName = "APIUSER";
        [SerializeField] private string Password = "Poshy";
        private string SaveLink;

        private void Awake()
        {
            SaveLink = $"mongodb+srv://{UserName}:{Password}@userdata.1xmw5.mongodb.net/test";
            var LocalSave = new saveInfo("Poshy");
            Debug.Log(LocalSave.UniqueID);
        }


        private struct saveInfo
        {
            private string Name;
            public readonly string UniqueID;
            private int DaysLasted;
            private int WeeksCompleted;

            public saveInfo(string tName) : this()
            {
                Name = tName;
                UniqueID = GenerateSHA256(tName);
                DaysLasted = GlobalVar.DaysLasted;
                WeeksCompleted = GlobalVar.WeeksLasted;
            }


            private bool AssignData()
            {
                try
                {
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            private static string GenerateSHA256(string rawData)
            {
                var crypt = new SHA256Managed();
                var hash = string.Empty;
                var crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(rawData));
                foreach (var theByte in crypto) hash += theByte.ToString("x2");

                return hash;
            }
        }
    }
}

#pragma warning restore 169