﻿using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task RemoveAsync(Project project);
        Task StartAsync(Project project);
        Task FinishAsync(Project project);
        Task UpdateAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);

    }
}
