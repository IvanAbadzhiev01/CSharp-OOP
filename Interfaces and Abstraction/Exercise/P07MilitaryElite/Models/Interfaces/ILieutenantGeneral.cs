namespace MilitaryElite.Models.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        //public HashSet<IPrivate> Privates { get;  }
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
