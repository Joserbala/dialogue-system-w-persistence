namespace Data
{

    [System.Serializable]
    public class CharacterStats
    {
        public int Strength;
        public int Dexterity;
        public int Wisdom;

        public CharacterStats() { }

        public CharacterStats(int str, int dex, int wis)
        {
            this.Strength = str;
            this.Dexterity = dex;
            this.Wisdom = wis;
        }
    }
}