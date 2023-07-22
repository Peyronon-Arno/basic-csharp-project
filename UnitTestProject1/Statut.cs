using Bibliotheque.DAL;
using Bibliotheque.entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TestStatut
    {
        [TestMethod]
        public void TestCreateStatut()
        {
            using (ContextDA context = new ContextDA())
            {
                Statut statut = new Statut
                {
                    Libelle = "Nouveau Statut"
                };

                context.Statuts.Add(statut);
                context.SaveChanges();

                Assert.IsTrue(statut.Id > 0, "Le statut n'a pas été créé avec succès.");
                Statut retrievedStatut = context.Statuts.Find(statut.Id);
                Assert.IsNotNull(retrievedStatut, "Le statut n'a pas été trouvé dans la base de données.");
                Assert.AreEqual(statut.Libelle, retrievedStatut.Libelle, "Le libellé du statut ne correspond pas.");
                context.Statuts.Remove(retrievedStatut);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestReadStatut()
        {
            using (ContextDA context = new ContextDA())
            {
                Statut statut = context.Statuts.FirstOrDefault();
                Assert.IsNotNull(statut);
            }
        }

        [TestMethod]
        public void TestUpdateStatut()
        {
            using (ContextDA context = new ContextDA())
            {
                Statut statut = context.Statuts.FirstOrDefault();
                Assert.IsNotNull(statut);

                statut.Libelle = "Nouveau Libellé";
                context.SaveChanges();

                Statut updatedStatut = context.Statuts.FirstOrDefault();
                Assert.AreEqual("Nouveau Libellé", updatedStatut.Libelle);
            }
        }

        [TestMethod]
        public void TestDeleteStatut()
        {
            using (ContextDA context = new ContextDA())
            {
                Statut statut = context.Statuts.FirstOrDefault();
                Assert.IsNotNull(statut);

                context.Statuts.Remove(statut);
                context.SaveChanges();

                Statut deletedStatut = context.Statuts.Find(statut.Id);
                Assert.IsNull(deletedStatut);
            }
        }
    }
}
