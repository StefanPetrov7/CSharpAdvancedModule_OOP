using System;
namespace Practice_Polymorphism
{
    public abstract class Game  // Game is the abstracton upon all the games => Tennis, Footbal, Chess.
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public abstract string GetDiscription(); // Abstract implementation in the iherited classes.

        public virtual void Start() // virtual method require implementattion, abstract doesn't.
        {
            this.StartDate = DateTime.Now;
        }

        public virtual void Stop()
        {
            this.EndDate = DateTime.Now;
        }
    }
}

