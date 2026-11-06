using Roguelike.Core;
using Roguelike.Skills;

namespace Roguelike.Characters
{
    public class MainCharacter : ICharacter
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CharacterComponent Component { get; set; }
        public Skill BaseSkill { get; set; }
        public Skill Skill { get; set; }
        public Ultimate Ultimate { get; set; }
        public int ComboId { get; set; }

        public MainCharacter(string id, string name, int maxHP, int atk, int def, int speed, Skill baseSkill, Skill skill, Ultimate ultimate)
        {
            Id = id;
            Name = name;
            Component = new CharacterComponent(id, name, maxHP, atk, def, speed);
            BaseSkill = baseSkill;
            Skill = skill;
            Ultimate = ultimate;
        }

        public int GetStat(StatType statType)
        {
            return Component.GetStat(statType);
        }
    }
}