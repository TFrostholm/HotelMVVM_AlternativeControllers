namespace AltHotel_WS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewsContext : DbContext
    {
        public ViewsContext()
            : base("name=ViewsContext1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Guestlist> Guestlist { get; set; }
        public virtual DbSet<Guestlist2> Guestlist2 { get; set; }
        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<SingleRoomsRoskilde> SingleRoomsRoskilde { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guestlist>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<Guestlist>()
                .Property(e => e.GuestName)
                .IsUnicode(false);

            modelBuilder.Entity<Guestlist2>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<Guestlist2>()
                .Property(e => e.GuestName)
                .IsUnicode(false);

            modelBuilder.Entity<HotelRooms>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HotelRooms>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SingleRoomsRoskilde>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
