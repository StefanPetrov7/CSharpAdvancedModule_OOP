﻿namespace CommandPattern.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
