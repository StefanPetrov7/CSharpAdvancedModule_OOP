using System;
namespace Military_Elite.Exeptions
{
    public class InvalidMissionState : Exception
    {
        private const string INVALID_MISSION = "Invalid Mission State";

        public InvalidMissionState() : base(INVALID_MISSION)
        { }

        public InvalidMissionState(string message) : base(message)
        { }
    }
}

