using Roguelike.Core;

namespace Roguelike.Characters
{
    public class CharacterComponent
    {
        public string CharacterId { get; set; }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int Speed { get; set; }// Default speed value, can be adjusted as needed


        public CharacterComponent(string characterId, string name, int maxHP, int atk, int def, int speed)
        {
            CharacterId = characterId;
            Name = name;
            MaxHP = maxHP;
            Atk = atk;
            Def = def;
            Speed = speed;
        }

        public int GetStat(StatType statType)
        {
            return statType switch
            {
                StatType.MaxHP => MaxHP,
                StatType.ATK => Atk,
                StatType.DEF => Def,
                StatType.Speed => Speed,
                _ => throw new ArgumentOutOfRangeException(nameof(statType), statType, null)
            };
        }

        public void GainExperience(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Experience amount cannot be negative.", nameof(amount));
            Experience += amount;
            CheckLevelUp();
        }

        private void CheckLevelUp()
        {
            int requiredExperience = Level * 100; // Example leveling formula
            while (Experience >= requiredExperience)
            {
                Experience -= requiredExperience;
                Level++;
                MaxHP += 10; // Example stat increase on level up
                Atk += 2;
                Def += 2;
                requiredExperience = Level * 100; // Update required experience for next level
            }
        }


        
    }
}