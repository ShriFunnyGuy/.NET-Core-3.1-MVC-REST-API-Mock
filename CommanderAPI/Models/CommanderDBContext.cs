using Microsoft.EntityFrameworkCore;

namespace CommanderAPI.Models {
    public class CommanderDBContext : DbContext {
        public CommanderDBContext() { }
        public CommanderDBContext(DbContextOptions<CommanderDBContext> options) : base (options) { }

        //Entity Famework Service and SQL connection from appsettings.json
        //or
        //Add a service in Startup.cs class
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
            //or
           optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CommondConnectStr"));
        }*/

        public DbSet<Command> Commands { get; set; }
    }
}