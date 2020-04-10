//using Microsoft.EntityFrameworkCore;
//using Petible_api.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Petible_api.DatabaseContext
//{
//    public class PetibleContext : DbContext
//    {
//        public PetibleContext(DbContextOptions<PetibleContext> options) : base(options)
//        {
//        }

//        public DbSet<AnimalShelter> animalShelters { get; set; }
//        public DbSet<ChatMessages> chatMessages { get; set; }
//        public DbSet<Matches> matches { get; set; }
//        public DbSet<PersonalityTraits> personalityTraits { get; set; }
//        public DbSet<Pet> pets { get; set; }
//        public DbSet<Pet_has_PersonalityTraits> petPersonalityTraits { get; set; }
//        public DbSet<Reviews> reviews { get; set; }
//        public DbSet<User> users { get; set; }
//        public DbSet<UserInfo> userInfos { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//            //modelBuilder.Entity<AnimalShelter>().ToTable("AnimalShelter");
//            //modelBuilder.Entity<ChatMessages>().ToTable("ChatMessages");
//            //modelBuilder.Entity<Matches>().ToTable("Matches");
//            //modelBuilder.Entity<PersonalityTraits>().ToTable("PersonalityTraits");
//            //modelBuilder.Entity<Pet>().ToTable("Pet");
//            //modelBuilder.Entity<Pet_has_PersonalityTraits>().ToTable("Pet_has_PersonalityTraits");
//            //modelBuilder.Entity<Reviews>().ToTable("Reviews");
//            //modelBuilder.Entity<User>().ToTable("User");
//            //modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
//        }
//    }
//}
