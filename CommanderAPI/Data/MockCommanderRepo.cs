using CommanderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        private List<Command> command;
        public MockCommanderRepo()
        {
            command = new List<Command>()
            {
                new Command{Id=1,HowTo="EF Migration",Line="dotnet ef migrations add <name>",App="EF"},
                new Command{Id=2,HowTo="EF Migration",Line="dotnet ef migrations remove <name>",App="EF"},
                new Command{Id=3,HowTo="EF Migration",Line="dotnet ef migrations list",App="EF"},
                new Command{Id=4,HowTo="EF Migration",Line="dotnet ef migrations script",App="EF"}
            };
        }
        public IEnumerable<Command> GetCommands()
        {
            return command.ToList();
        }
        public Command GetCommandById(int Id)
        {
            return command.FirstOrDefault(cmd => cmd.Id == Id);
        }
        public Command CreateCommand(Command newcommand)
        {
            newcommand.Id = this.command.Max(maxId => maxId.Id) + 1;
            command.Add(newcommand);
            return newcommand;
        }
        public Command UpdateCommand(Command updateCommand)
        {
            var commandItem = command.FirstOrDefault(cmd => cmd.Id == updateCommand.Id);
            if(commandItem !=null)
            {
                commandItem.HowTo = updateCommand.HowTo;
                commandItem.Line = updateCommand.Line;
                commandItem.App = updateCommand.App;
            }
            return commandItem;
        }
        public Command DeleteCommand(int Id)
        {
            var commandItem = command.FirstOrDefault(cmd => cmd.Id == Id);
            if(commandItem !=null)
            {
                command.Remove(commandItem);
            }
            return commandItem;
        }

        bool ICommanderRepo.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
