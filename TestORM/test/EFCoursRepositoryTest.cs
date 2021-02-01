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
        private EFCoursRepository repoCours;

        private void setUp()
        {
            var builder = new DbContextOptionsBuilder<CegepContext>();
            builder.UseInMemoryDatabase(databaseName: "testInscription_db");   // Database en mémoire
            var context = new CegepContext(builder.Options);
            repoInscriptions = new EFInscCoursRepository(context);
            repoEtudiants = new EFEtudiantRepository(context);
            repoCours = new EFCoursRepository(context);


            /*Etudiant etud = new Etudiant
            {
                Nom = "Simard",
                Prenom = "Serge",
                DateNaissance = Convert.ToDateTime("1977-10-10"),
                NoProgramme = 420
            };

            Etudiant etud2 = new Etudiant
            {
                Nom = "Tremblay",
                Prenom = "Sylvie",
                DateNaissance = Convert.ToDateTime("1982-10-10"),
                NoProgramme = 420
            };*/
        }
        [Fact]
        public void AjouterCoursShouldAddCours()
        {
            //Arrange
            setUp();
            Cours cours1 = new Cours
            {
                CodeCours = "10",
                Inscriptions = new List<InscriptionCours>(),
                NomCours = "Jeu vidéo"
            };
            //Act
            repoCours.AjouterCours(cours1);
            //Assert
            var result = repoCours.ObtenirListeCours();
            Assert.Single(result);
            Assert.Same(cours1, result.First());
        }

        [Fact]
        public void ObtenirListeCoursShouldReturnListOfCours()
        {
            //Arrange
            setUp();
            //Act
            var result = repoCours.ObtenirListeCours();
            //Assert
            Assert.NotNull(result);
        }
    }
}
