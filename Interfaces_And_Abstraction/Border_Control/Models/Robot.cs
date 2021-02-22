using Border_Control.Contracts;

namespace Border_Control.Models
{
    public class Robot : IIdNumerable
    {
        public Robot(string model, long iD)
        {
            this.Model = model;
            this.ID = iD;
        }

        public string Model { get; set; }
        public long ID { get; set; }
    }
}
