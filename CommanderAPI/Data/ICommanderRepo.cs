using CommanderAPI.Models;
using System;
using System.Collections.Generic;

namespace CommanderAPI.Data
{
    //Interface Commander Repository
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetCommands();
        Command GetCommandById(int Id);
        Command CreateCommand(Command command);
        Command UpdateCommand(Command command);
        Command DeleteCommand(int Id);
        bool SaveChanges();
    }
}
