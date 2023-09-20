using MilitaryElite.Enums;

namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        //public State State => State.inProgress;
        State State { get; }

        public void CompleteMission();

    }
}
