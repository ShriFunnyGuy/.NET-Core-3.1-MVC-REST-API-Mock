using System;
using System.Collections.Generic;
using System.Linq;
using CommanderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderAPI.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderDBContext commanderDBContext;
        public SQLCommanderRepo(CommanderDBContext commanderDBContext)
        {
            this.commanderDBContext = commanderDBContext;
        }

        public Command CreateCommand(Command command)
        {
            if(command != null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            commanderDBContext.Add(command);
            SaveChanges();
            return command;
        }

        public Command DeleteCommand(int Id)
        {
            if(Id ==0)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            var commandItem = commanderDBContext.Commands.FirstOrDefault(cmd => cmd.Id == Id);
            if(commandItem !=null)
            {
                var changesCommand = commanderDBContext.Commands.Remove(commandItem);
                changesCommand.State = EntityState.Modified;
                SaveChanges();
            }
            return commandItem;
        }

        public Command GetCommandById(int Id)
        {
            if(Id ==0)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            return commanderDBContext.Commands.FirstOrDefault(cmd => cmd.Id == Id);
        }

        public IEnumerable<Command> GetCommands()
        {
            return commanderDBContext.Commands.ToList();
        }

        public Command UpdateCommand(Command command)
        {
            if(command != null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            var commandItem = commanderDBContext.Commands.FirstOrDefault(cmd => cmd.Id == command.Id);
            if(commandItem !=null)
            {
                var changesCommand = commanderDBContext.Commands.Attach(command);
                changesCommand.State = EntityState.Modified;
                SaveChanges();
            }
            return commandItem;
        }

        public bool SaveChanges()
        {
            return (commanderDBContext.SaveChanges() >= 0);
        }
    }
}