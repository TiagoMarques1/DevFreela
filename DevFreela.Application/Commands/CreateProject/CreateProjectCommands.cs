﻿using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommands : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
