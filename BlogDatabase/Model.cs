using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext
{
    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "blogging.db");
    }

    public DbSet<Artist> Artists { get; set; }

    public DbSet<Song> Songs { get; set; }

    public string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Song
{
    public int SongId { get; set; }

    public List<Artist> Artists { get; set; }

    public string Name { get; set; }
}

public class Artist
{
    public int ArtistId { get; set; }

    public List<Song> Songs { get; set; }

    public string Name { get; set; }
}