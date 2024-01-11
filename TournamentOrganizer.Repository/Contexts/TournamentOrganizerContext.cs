using Microsoft.EntityFrameworkCore;
using TournamentOrganizer.Repository.Entities;

namespace TournamentOrganizer.Repository.Contexts;

public class TournamentOrganizerContext : DbContext
{
	public DbSet<Tournament> Tournaments { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseInMemoryDatabase(databaseName: "TournamentOrganizerDb");
	}
}
