using P07.MilitaryElite.Enumerations;

namespace P07.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        MissionStatus Status { get; }

        public void CompleteMission();
    }
}
