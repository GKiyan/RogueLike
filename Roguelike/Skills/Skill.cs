using Roguelike.Core;
using Roguelike.Characters;
using Roguelike.Effects;

namespace Roguelike.Skills
{
    public abstract class Skill
    {
        public string Name { get; set; }
        public int SpCost { get; set; }
        public List<Effect> Effects { get; set; } = new List<Effect>();
        public TargetType TargetType { get; set; }
        public CharacterType CasterType { get; set; } 
        public ICharacter Caster { get; set; }
        public List<ITargetable> Targets { get; set; }

        public Skill(string name, int spCost, TargetType targetType, CharacterType casterType, ICharacter caster, List<ITargetable> targets)
        {
            Name = name;
            SpCost = spCost;
            TargetType = targetType;
            CasterType = casterType;
            Caster = caster;
            Targets = targets;
        }

        public List<ITargetable> GetValidTargets(Team team, List<ITargetable> potentialEnemyTargets)
        {
            if (TargetType == TargetType.Self)
            {
                for (int i = 0; i < 3; i++)
                {
                    CharacterDuo duo = team.GetDuoByPosition(i);
                    if (duo != null && duo.GetCharacterByType(CasterType).Equals(Caster))
                    {
                        return [duo];
                    }
                }
                throw new Exception("Character not found");
            }
            else if (TargetType == TargetType.SingleAlly || TargetType == TargetType.AllAllies)
            {
                return [.. new List<ITargetable> { team.GetDuoByPosition(2), team.GetDuoByPosition(1), team.GetDuoByPosition(0) }.Where(duo => duo != null).ToList()];
            }
            else if (TargetType == TargetType.AllEnemies || TargetType == TargetType.SingleEnemy)
            {
                return potentialEnemyTargets;
            }
            else
            {
                throw new ArgumentException("Invalid target type");
            }
        }

        public void AddEffect(Effect effect)
        {
            Effects.Add(effect);
        }

        public abstract void Execute(List<ITargetable> Targets);
    }
}