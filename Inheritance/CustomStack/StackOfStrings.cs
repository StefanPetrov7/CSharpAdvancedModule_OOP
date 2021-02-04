using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public StackOfStrings()
        {
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(Stack<string> stack)
        {
            while (stack.Count > 0)
            {
                this.Push(stack.Pop());
            }

            return this;
        }
    }
}
