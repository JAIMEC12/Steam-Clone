using Microsoft.EntityFrameworkCore;
using Steam.Domain.Database.SqlServer.Entities;

namespace Steam.Domain.Database.SqlServer.Context;

public partial class SteamContext : DbContext
{
    public SteamContext()
    {
    }

    public SteamContext(DbContextOptions<SteamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Dlc> Dlcs { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameGenre> GameGenres { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewAnswer> ReviewAnswers { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchievement> UserAchievements { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;User=sa;Password=Admin1234@;Database=Steam;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330E0EB2F97CE");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Game).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Achieveme__GameI__5165187F");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.HasKey(e => e.DeveloperId).HasName("PK__Develope__DE084CD10B8DCF7B");

            entity.ToTable("Developer");

            entity.Property(e => e.DeveloperId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("DeveloperID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.DeveloperName).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<Dlc>(entity =>
        {
            entity.HasKey(e => e.Dlcid).HasName("PK__DLCs__8EAFB3394CB36093");

            entity.ToTable("DLCs");

            entity.Property(e => e.Dlcid).HasColumnName("DLCID");
            entity.Property(e => e.AddedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Dlcname)
                .HasMaxLength(200)
                .HasColumnName("DLCName");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Game).WithMany(p => p.Dlcs)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__DLCs__GameID__6EF57B66");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.FriendId }).HasName("PK__Friends__3DA43AFA0DFB1C0C");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FriendId).HasColumnName("FriendID");
            entity.Property(e => e.AddedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.FriendNavigation).WithMany(p => p.FriendFriendNavigations)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friends__FriendI__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.FriendUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friends__UserID__412EB0B6");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Games__2AB897DDC98BF083");

            entity.Property(e => e.GameId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GameID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Developer).WithMany(p => p.Games)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("FK__Games__Developer__4D94879B");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Games)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("FK__Games__Publisher__4E88ABD4");
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(e => e.GameGenreId).HasName("PK__Game_Gen__B56670D508653F1B");

            entity.ToTable("Game_Genre");

            entity.Property(e => e.GameGenreId).HasColumnName("GameGenreID");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");

            entity.HasOne(d => d.Game).WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Game_Genr__GameI__73BA3083");

            entity.HasOne(d => d.Genre).WithMany(p => p.GameGenres)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Game_Genr__Genre__74AE54BC");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385055EDBF535A9");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.LibraryId).HasName("PK__Library__A13647BFB9891FCB");

            entity.ToTable("Library");

            entity.Property(e => e.LibraryId).HasColumnName("LibraryID");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Game).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Library__GameID__628FA481");

            entity.HasOne(d => d.User).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Library__UserID__619B8048");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PK__Offers__8EBCF0B129AAF147");

            entity.Property(e => e.OfferId).HasColumnName("OfferID");
            entity.Property(e => e.GameId).HasColumnName("GameID");

            entity.HasOne(d => d.Game).WithMany(p => p.Offers)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Offers__GameID__778AC167");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PK__Publishe__4C657E4BA091E1BC");

            entity.Property(e => e.PublisherId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PublisherID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PublisherName).HasMaxLength(150);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE3A990E2B");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Game).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Reviews__GameID__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__59063A47");
        });

        modelBuilder.Entity<ReviewAnswer>(entity =>
        {
            entity.HasKey(e => new { e.ReviewId, e.UserId }).HasName("PK__ReviewAn__A5C4F50419C3B434");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ReviewAnswersId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewAnswers)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReviewAns__Revie__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.ReviewAnswers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReviewAns__UserI__5EBF139D");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F4927076D47EFF");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Game).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Sessions__GameID__6B24EA82");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sessions__UserID__6A30C649");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2043D332BCC9");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ShowName).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC2C113310");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B3AB02CB").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Users__StatusID__3D5E1FD2");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => e.UserAchievementId).HasName("PK__UserAchi__07E627D624A24F75");

            entity.Property(e => e.UserAchievementId).HasColumnName("UserAchievementID");
            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__UserAchie__Achie__5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserAchie__UserI__5441852A");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PK__Wishlist__233189CB4CE88B4F");

            entity.ToTable("Wishlist");

            entity.Property(e => e.WishlistId).HasColumnName("WishlistID");
            entity.Property(e => e.AddedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.GameId).HasColumnName("GameID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Game).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__Wishlist__GameID__6754599E");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Wishlist__UserID__66603565");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
