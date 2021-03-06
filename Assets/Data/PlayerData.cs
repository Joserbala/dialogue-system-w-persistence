using System;
using System.Xml.Serialization;
//using System.Runtime.Serialization;
using UnityEngine;

namespace Data
{

    [Serializable]
    public class PlayerData /*: IDeserializationCallback*/ : ISerializationCallbackReceiver
    {
        public string ID;

        public int Health;
        public int Armor;

        public CharacterClass PlayerClass;
        public CharacterStats PlayerStats;

        [NonSerialized]
        public int PhysicalDPS;

        private string playerToken = "DefaultToken";

        public PlayerData() { }

        public PlayerData(string id, CharacterClass characterClass)
        {
            this.ID = id;
            this.Health = 100;
            this.Armor = 10;
            this.PlayerClass = characterClass;
            this.PlayerStats = InitPlayerStats(characterClass);
            this.PhysicalDPS = CalculatePhysicalDPS();
            this.playerToken = GenerateToken();
        }

        private string GenerateToken()
        {
            return PlayerClass.ToString() + PhysicalDPS;
        }

        private int CalculatePhysicalDPS()
        {
            return (PlayerStats.Strength * 5 + PlayerStats.Dexterity * 2 + PlayerStats.Wisdom);
        }

        private CharacterStats InitPlayerStats(CharacterClass characterClass)
        {
            CharacterStats stats;

            switch (characterClass)
            {
                case CharacterClass.Warrior:
                    stats = new CharacterStats(5, 3, 1);
                    break;

                case CharacterClass.Archer:
                    stats = new CharacterStats(2, 5, 1);
                    break;

                case CharacterClass.Mage:
                    stats = new CharacterStats(1, 3, 5);
                    break;

                default:
                    stats = new CharacterStats(1, 1, 1);
                    break;
            }

            return stats;
        }

        // <summary>
        // Esto se llama cada vez que se deserializa en binario el objeto.
        // </summary>
        // <param name="sender"></param>
        // public void OnDeserialization(object sender)
        // {
        //     Debug.Log("Objeto deserializado.");
        //     GenerateInternalData();
        // }

        public void GenerateInternalData()
        {
            PhysicalDPS = CalculatePhysicalDPS();
            playerToken = GenerateToken();
        }

        public void ShowInternalData()
        {
            Debug.Log("Physical DPS: " + PhysicalDPS);
            Debug.Log("Player Token: " + playerToken);
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            GenerateInternalData();
        }
    }
}