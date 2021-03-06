using System;
namespace Practice.Exceptions
{
    public class InvalidMissionStateMessage : Exception
    {
        private const string INVALID_MISSION_STATE = "InvalidMissionStateMessage";

        public InvalidMissionStateMessage() : base(INVALID_MISSION_STATE)
        {
        }

        public InvalidMissionStateMessage(string message) : base(message)
        {

        }
    }
}
