using System;
namespace P07.MilitaryElite.Exceptions
{
    public class MissionStatusFinishedException : Exception
    {
        private const string MISSION_FINISHED = "Mission statuse is finished";
        public MissionStatusFinishedException() : base(MISSION_FINISHED)
        {
        }

        public MissionStatusFinishedException(string message) : base(message)
        {

        }
    }
}
