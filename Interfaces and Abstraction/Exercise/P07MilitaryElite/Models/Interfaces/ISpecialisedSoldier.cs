using MilitaryElite.Enums;

namespace MilitaryElite.Models.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        // public string Corps { get; }
        Corps Corps { get; }
    }
}
