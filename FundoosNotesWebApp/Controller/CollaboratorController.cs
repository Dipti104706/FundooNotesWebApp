﻿using FundooManager.Interface;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesWebApp.Controller
{
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager manager;
        public CollaboratorController(ICollaboratorManager manager)
        {
            this.manager = manager;
        }

        //Api for adding collaborator to notes
        [HttpPost]
        [Route("api/collaborator")]//API-Application programming interface
        public async Task<IActionResult> Collaborator([FromBody] CollaboratorModel collaborator)
        {
            try
            {
                string result = await this.manager.Collaborator(collaborator);

                if (result.Equals("Collaborator Added"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        //Api for delete collator for notes
        [HttpDelete]
        [Route("api/deletecollaborator")]
        public async Task<IActionResult> DeleteCollaborator(int noteId, string collabMail)
        {
            try
            {
                string result = await this.manager.DeleteCollab(noteId, collabMail);

                if (result.Equals("Removed Collaborator"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}