using Microsoft.EntityFrameworkCore;
using MitarbeiterVewaltung.Lib.Modell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVewaltung.Lib.Context
{
    public class MitarbeiterContext : DbContext
    {
        public DbSet<Mitarbeiter> Mitarbeiterinnen { get; set; }

        private string _path;

        public MitarbeiterContext(string path)
        {
            _path = path;
            this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_path}");
    }
}
