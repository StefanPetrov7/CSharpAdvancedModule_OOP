namespace P04.Recharge
{
    public abstract class Worker 
    {
        protected string id;
        protected int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}