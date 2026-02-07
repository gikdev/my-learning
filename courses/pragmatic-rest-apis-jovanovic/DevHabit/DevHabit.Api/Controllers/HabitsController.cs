using DevHabit.Api.Database;
using DevHabit.Api.DTOs.Habits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabit.Api.Controllers;

[ApiController]
[Route("habits")]
public sealed class HabitsController(AppDbCtx db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<HabitsCollectionDto>> GetHabits()
    {
        var habits = await db.Habits.Select(h => new HabitDto
        {
            CreatedAtUtc = h.CreatedAtUtc,
            UpdatedAtUtc = h.UpdatedAtUtc,
            Id = h.Id,
            Name = h.Name,
            Description = h.Description,
            Type = h.Type,
            Frequency = new FrequencyDto
            {
                Type = h.Frequency.Type,
                TimesPerPeriod = h.Frequency.TimesPerPeriod
            },
            IsArchived = h.IsArchived,
            Status = h.Status,
            Target = new TargetDto
            {
                Unit = h.Target.Unit,
                Value = h.Target.Value,
            },
            EndDate = h.EndDate,
            LastCompletedAtUtc = h.LastCompletedAtUtc,
            Milestone = h.Milestone == null ? null : new MilestoneDto
            {
                Current = h.Milestone.Current,
                Target = h.Milestone.Target
            },
        }).ToListAsync();

        var habitsCollectionDto = new HabitsCollectionDto
        {
            Data = habits,
        };

        return Ok(habitsCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitDto>> GetHabits(string id)
    {
        var habit = await db.Habits.Where(h => h.Id == id).Select(h => new HabitDto
        {
            CreatedAtUtc = h.CreatedAtUtc,
            UpdatedAtUtc = h.UpdatedAtUtc,
            Id = h.Id,
            Name = h.Name,
            Description = h.Description,
            Type = h.Type,
            Frequency = new FrequencyDto
            {
                Type = h.Frequency.Type,
                TimesPerPeriod = h.Frequency.TimesPerPeriod
            },
            IsArchived = h.IsArchived,
            Status = h.Status,
            Target = new TargetDto
            {
                Unit = h.Target.Unit,
                Value = h.Target.Value,
            },
            EndDate = h.EndDate,
            LastCompletedAtUtc = h.LastCompletedAtUtc,
            Milestone = h.Milestone == null ? null : new MilestoneDto
            {
                Current = h.Milestone.Current,
                Target = h.Milestone.Target
            },
        }).FirstOrDefaultAsync();

        if (habit is null)
        {
            return NotFound();
        }

        return Ok(habit);
    }
}
