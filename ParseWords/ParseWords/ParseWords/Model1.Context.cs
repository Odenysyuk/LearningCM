﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParseWords
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CallanMethodEntities : DbContext
    {
        public CallanMethodEntities()
            : base("name=CallanMethodEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Sound> Sounds { get; set; }
    }
}
