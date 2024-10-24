// Copyright (c) 2024 GoatrikWorks - Erik Elb
// Licensed under MIT License

using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Commands.CreateTask;
using TaskManagementSystem.Application.Commands.UpdateTaskStatus;
using TaskManagementSystem.Application.DTOs;
using TaskManagementSystem.Application.Queries.GetTaskById;
using TaskManagementSystem.API.Models.Requests;

namespace TaskManagementSystem.API.Controllers
{
    public class TasksController : BaseApiController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async System.Threading.Tasks.Task<ActionResult<TaskDto>> GetTask(Guid id)
        {
            var result = await Mediator.Send(new GetTaskByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async System.Threading.Tasks.Task<ActionResult<TaskDto>> Create([FromBody] CreateTaskCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetTask), new { id = result.Id }, result);
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async System.Threading.Tasks.Task<ActionResult<TaskDto>> UpdateStatus(Guid id, [FromBody] UpdateTaskStatusRequest request)
        {
            var command = new UpdateTaskStatusCommand
            {
                TaskId = id,
                NewStatus = request.NewStatus,
                UpdatedById = request.UpdatedById
            };

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
