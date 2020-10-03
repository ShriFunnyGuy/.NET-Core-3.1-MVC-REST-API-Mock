using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderAPI.Data;
using CommanderAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommanderAPI.Controllers
{
    [Route("api/[controller]")]
    //       Or
    //[Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private ICommanderRepo _commanderRepo;
        //Constructor dependency Injection
        public CommandsController(ICommanderRepo commanderRepo)
        {
            this._commanderRepo = commanderRepo;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            try
            {
                var commondItems= _commanderRepo.GetCommands();
                if(commondItems != null)
                {
                    return Ok(commondItems);
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }

        //GET api/commands/5
        [HttpGet("{Id}")]
        public ActionResult <Command> GetCommondById(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            try
            {
                var commondItem = _commanderRepo.GetCommandById(Id);
                if(commondItem != null)
                {
                    return Ok(commondItem);
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <Command> CreateCommand(Command createCommand)
        {
            if(createCommand ==null)
            {
                return BadRequest();
            }
            try
            {
                var createCommandItem = _commanderRepo.CreateCommand(createCommand);
                if(createCommandItem ==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(createCommandItem);
                }
                    
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        //PUT api/commands
        [HttpPut]
        public ActionResult <Command> UpdateCommand(Command updateCommand)
        {
            if(updateCommand ==null)
            {
                return BadRequest();
            }
            try
            {
                var updateCommandItem = _commanderRepo.UpdateCommand(updateCommand);
                if(updateCommandItem ==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updateCommandItem);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        //DELETE api/commands
        [HttpDelete("{Id}")]
        public ActionResult <Command> DeleteCommand(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            try
            {
                var deleteCommandItem = _commanderRepo.DeleteCommand(Id);
                if(deleteCommandItem ==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(deleteCommandItem);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        //PATCH api/commands/{id}
        [HttpPatch("{Id}")]
        public ActionResult PartialCommandUpdate(int Id,JsonPatchDocument<Command> jsonPatchDocument)
        {
            if (Id == 0)
            {
                return BadRequest();
            }

            
            try
            {
               var commandToPatch = _commanderRepo.GetCommandById(Id);
                if(commandToPatch ==null)
                {
                    return NotFound();
                }
                
                jsonPatchDocument.ApplyTo(commandToPatch,ModelState);

                if(!TryValidateModel(commandToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    var updateCommandItem = _commanderRepo.UpdateCommand(commandToPatch);
                    if(updateCommandItem ==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(updateCommandItem);
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
        }
    }
}
