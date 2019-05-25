namespace TheTankGame.Entities.Miscellaneous
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Parts.Contracts;

    public class VehicleAssembler : IAssembler
    {
        private readonly IList<IAttackModifyingPart> arsenalParts;
        private readonly IList<IDefenseModifyingPart> shellParts;
        private readonly IList<IHitPointsModifyingPart> enduranceParts;

        public VehicleAssembler()
        {
            this.arsenalParts = new List<IAttackModifyingPart>();
            this.shellParts = new List<IDefenseModifyingPart>();
            this.enduranceParts = new List<IHitPointsModifyingPart>();
        }

        public IReadOnlyCollection<IAttackModifyingPart> ArsenalParts
                                => this.arsenalParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IDefenseModifyingPart> ShellParts
                                => this.shellParts.ToList().AsReadOnly();

        public IReadOnlyCollection<IHitPointsModifyingPart> EnduranceParts
                                => this.enduranceParts.ToList().AsReadOnly();


        //TODO: .Max or .Sum ???
        public double TotalWeight
        {
            get
            {
                double result = 0;

                if (this.ArsenalParts.Count>0)
                {
                    result += ArsenalParts.Sum(w => w.Weight);
                }
                if (this.ShellParts.Count > 0)
                {
                    result += ShellParts.Sum(w => w.Weight);
                }
                if (this.EnduranceParts.Count > 0)
                {
                    result += EnduranceParts.Sum(w => w.Weight);
                }

                return result;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                decimal result = 0;

                if (this.ArsenalParts.Count > 0)
                {
                    result += ArsenalParts.Sum(p => p.Price);
                }
                if (this.ShellParts.Count > 0)
                {
                    result += ShellParts.Sum(p => p.Price);
                }
                if (this.EnduranceParts.Count > 0)
                {
                    result += EnduranceParts.Sum(p => p.Price);
                }

                return result;
            }
        }

        public long TotalAttackModification
             => this.ArsenalParts.Sum(p => p.AttackModifier);

        public long TotalDefenseModification
             => this.ShellParts.Sum(p => p.DefenseModifier);

        public long TotalHitPointModification
             => this.EnduranceParts.Sum(p => p.HitPointsModifier);

        public void AddArsenalPart(IPart arsenalPart)
        {
            this.arsenalParts.Add((IAttackModifyingPart)arsenalPart);
        }

        public void AddShellPart(IPart shellPart)
        {
            this.shellParts.Add((IDefenseModifyingPart)shellPart);
        }

        public void AddEndurancePart(IPart endurancePart)
        {
            this.enduranceParts.Add((IHitPointsModifyingPart)endurancePart);
        }
    }
}