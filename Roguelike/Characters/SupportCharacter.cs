using Roguelike.Core;
using Roguelike.Skills;

namespace Roguelike.Characters
{
    public class SupportCharacter : ICharacter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CharacterComponent Component { get; set; }
        public Skill Skill { get; set; }
        public ComboSkill ComboSkill { get; set;}
        public List<int> ComboIds;

        public SupportCharacter(string id, string name, int maxHP, int atk, int def, int speed, Skill skill, ComboSkill comboSkill)
        {
            Id = id;
            Name = name;
            Component = new CharacterComponent(id, name, maxHP, atk, def, speed);
            Skill = skill;
            ComboSkill = comboSkill;
            ComboIds = []; 
        }

        public int GetStat(StatType statType)
        {
            return Component.GetStat(statType);
        }
    }
}