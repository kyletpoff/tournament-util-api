using System;

namespace TournamentOrganizer.Repository.Entities;

public class Tournament
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTimeUtc { get; set; }
    public DateTime? EndTimeUtc { get; set; }
    public string OwnerId { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public int AllowedTeams { get; set; }
}