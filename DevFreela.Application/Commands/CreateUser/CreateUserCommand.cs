﻿using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
