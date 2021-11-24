﻿using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class NoteRepository : INoteRepository
    {
        //Creating object for Usercontext
        private readonly UserContext userContext;

        //Declaring parameterized constructor
        public NoteRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        public IConfiguration Configuration { get; }

        //Method for adding notes in the fundoo note application
        public async Task<string> CreateNote(NoteModel note)
        {
            try
            {
                if (note != null)
                {
                    // Add the data to the database
                    this.userContext.Notes.Add(note);
                    //Save changes to database
                    await this.userContext.SaveChangesAsync();
                    return "Note is Added";
                }
                else
                {
                    return "Adding note unsuccessful";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
