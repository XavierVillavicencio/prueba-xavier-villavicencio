using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class backendContext : DbContext
    {
        public backendContext (DbContextOptions<backendContext> options)
            : base(options)
        {
        }

        public DbSet<backend.Models.Buttons> Buttons { get; set; } = default!;
        public DbSet<backend.Models.Forms> Forms { get; set; } = default!;
        public DbSet<backend.Models.FormInputs> FormInputs { get; set; } = default!;
        public DbSet<backend.Models.FormAnswers> FormAnswers { get; set; } = default!;
    }
}
