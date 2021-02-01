using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestORMCodeFirst.DAL;
using TestORMCodeFirst.Entities;
using TestORMCodeFirst.Persistence;
using Xunit;

namespace TestORMCodeFirst.DAL
{
    public class EFCoursRepositoryTest
    {
        private EFInscCoursRepository repoInscriptions;
        private EFEtudiantRepository repoEtudiants;
        private EFInscCoursRepository repoCours;

        private void setUp()
        {
            var builder = new DbContextOptionsBuilder<CegepContext>();
            builder.UseInMemoryDatabase(databaseName: "testInscription_db");   // Database en mémoire
            var context = new CegepContext(builder.Options);
            repoInscriptions = new EFInscCoursRepository(context);
            repoEtudiants = new EFEtudiantRepository(context);
            repoCours = new EFCoursRepository(context);
        }
    }
}
