using Application.Exceptions;
using Application.Interface.Interface;
using Application.Interface.InterfaceCommand;
using Application.Interface.InterfaceQueries;
using Application.Interface.InterfaceService;
using Application.Models.RequestDTO;
using Application.Models.ResponseDTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TasksService : ITasksService
    {
        private readonly ITasksCommand _command;
        private readonly ITasksQuery _query;
        private readonly IProjectsQuery _projectQuery;
        private readonly IUsersQuery _usersQuery;
        private readonly ITaskStatusQuery _taskStatusQuery;

        public TasksService(ITasksCommand command, ITasksQuery query, IProjectsQuery projectQuery, IUsersQuery usersQuery, ITaskStatusQuery taskStatusQuery)
        {
            _command = command;
            _query = query;
            _projectQuery = projectQuery;
            _usersQuery = usersQuery;
            _taskStatusQuery = taskStatusQuery;
        }

        public async Task<TasksResponseDTO> AddTask(TasksRequestDTO dto, Guid ProjectID)
        {
            bool existProject = await _projectQuery.GetByID(ProjectID) != null;
            if (existProject)
            {
                if (await _usersQuery.GetByID(dto.user) == null)
                    throw new NotFoundException($"The user entered was not found");

                if (await _taskStatusQuery.GetByID(dto.status) == null)
                    throw new NotFoundException($"The status entered was not found");

                Tasks objModel = new Tasks
                {
                    ProjectID = ProjectID,
                    Name = dto.name,
                    DueDate = dto.dueDate,
                    AssignedTo = dto.user,
                    Status = dto.status,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.MinValue
                };
                Tasks objCreate = await _command.InsertTask(objModel);
                return new TasksResponseDTO
                {
                    id = objCreate.TaskID,
                    name = objCreate.Name,
                    dueDate = objCreate.DueDate,
                    projectId = objCreate.ProjectID,
                    status = new TaskStatusResponseDTO
                    {
                        id = objCreate.TaskStatus.Id,
                        name = objCreate.TaskStatus.Name,
                    },
                    userAssigned = new UsersResponseDTO
                    {
                        id = objCreate.Users.UserID,
                        name = objCreate.Users.Name,
                        email = objCreate.Users.Email,
                    },
                };
            }
            else
                throw new NotFoundException($"The project with the ID {ProjectID} was not found.");
        }

        public async Task<TasksResponseDTO> RenewTask(TasksUpdateRequestDTO dto,Guid id) 
        {
            bool existTask = await _query.GetByID(id) != null;
            if (existTask)
            {
                if (dto == null)
                    throw new ModelNullException($"No data to modify has been entered.");

                Tasks objModel = new Tasks();

                if (string.IsNullOrEmpty(dto.name) || dto.name == "string")
                    objModel.Name = null;
                else
                    objModel.Name = dto.name;

                if (dto.dueDate != null && (dto.dueDate.Value - DateTime.UtcNow).TotalSeconds > 1)
                    objModel.DueDate = dto.dueDate.Value;

                if (dto.user != 0 )
                {
                    if (await _usersQuery.GetByID(dto.user) == null)
                        throw new NotFoundException($"The user entered was not found");
                    objModel.AssignedTo = dto.user;
                }
                if (dto.status != 0)
                {
                    if (await _taskStatusQuery.GetByID(dto.status) == null)
                        throw new NotFoundException($"The status entered was not found");
                    objModel.Status = dto.status;
                }

                Tasks objCreate = await _command.UpdateTask(objModel, id);

                return new TasksResponseDTO
                {
                    id = objCreate.TaskID,
                    name = objCreate.Name,
                    dueDate = objCreate.DueDate,
                    projectId = objCreate.ProjectID,
                    status = new TaskStatusResponseDTO
                    {
                        id = objCreate.TaskStatus.Id,
                        name = objCreate.TaskStatus.Name,
                    },
                    userAssigned = new UsersResponseDTO
                    {
                        id = objCreate.Users.UserID,
                        name = objCreate.Users.Name,
                        email = objCreate.Users.Email,
                    },
                };
            }
            else 
                throw new NotFoundException($"The Task with the ID {id} was not found.");
        }
    }
}
