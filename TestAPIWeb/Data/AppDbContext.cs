using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using TestAPIWeb.Models;

namespace TestAPIWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Association> Associations { get; set; }

        public DbSet<ObjetSocial> ObjetSocials { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Association>()
            //    .HasOne(a => a.ObjetSocial1)
            //    .WithMany(o => o.AssociationsLien1)
            //    .HasForeignKey(a => a.ObjetSocial1ID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Association>()
            //    .HasOne(a => a.ObjetSocial2)
            //    .WithMany(o => o.AssociationsLien2)
            //    .HasForeignKey(a => a.ObjetSocial2ID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ObjetSocial>().HasData(GetObjetSocials());
            modelBuilder.Entity<Association>().HasData(GetAssociations());
        }

        private static IEnumerable<Association> GetAssociations()
        {
            string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "rna_import_20241001_dpt_48.csv" };
            var csvFilePath = Path.Combine(p);
            var associations = new List<Association>();

            using (var reader = new StreamReader(csvFilePath))
            {
                using (var parser = new TextFieldParser(reader))
                {
                    parser.SetDelimiters(";");
                    parser.HasFieldsEnclosedInQuotes = true;
                    int idToIncrement = 1;
                    while (!parser.EndOfData)
                    {
                        var values = parser.ReadFields();
                        if (values != null)
                        {
                            if (values[0].Contains("id")) continue; //c'est l'entête donc on passe à la ligne suivante

                            //pour les champ date
                            DateOnly date_creat;
                            DateOnly.TryParse(values[4], out date_creat);
                            DateOnly date_publi;
                            DateOnly.TryParse(values[5], out date_publi);
                            DateTime maj_time = DateTime.Parse(values[22].Trim('"'));

                            var association = new Association
                            {
                                Id = idToIncrement,
                                IdRNA = values[0],
                                DateCreation = date_creat,
                                DatePublication = date_publi,
                                Titre = values[8],
                                Description = values[9],
                                ObjetSocial1ID = int.Parse(values[10]),
                                ObjetSocial2ID = int.Parse(values[11]),
                                //ObjetSocial1ID = int.Parse(values[10]) != 0 ? int.Parse(values[10]) : null,
                                //ObjetSocial2ID = int.Parse(values[11]) != 0 ? int.Parse(values[11]) : null,
                                Adresse1 = values[12],
                                Adresse2 = values[13],
                                Adresse3 = values[14],
                                CodePostal = values[15],
                                Ville = values[16],
                                SiteWeb = values[18],
                                Position = Convert.ToChar(values[20]),
                                LastUpdate = maj_time
                            };
                            associations.Add(association);
                            idToIncrement++;
                        }
                    }
                }
            }
            return associations;
        }

        private static IEnumerable<ObjetSocial> GetObjetSocials()
        {
            string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "rna-associations-nomenclature-waldec.csv" };
            var csvFilePath = Path.Combine(p);
            var waldecRNAs = new List<ObjetSocial>();
            using (var reader = new StreamReader(csvFilePath))
            {
                using (var parser = new TextFieldParser(reader))
                {
                    parser.SetDelimiters(";");
                    parser.HasFieldsEnclosedInQuotes = true;

                    while (!parser.EndOfData)
                    {
                        var values = parser.ReadFields();
                        if (values != null)
                        {
                            if (values[0].Contains("objet_social_parent_id")) continue; //c'est l'entête donc on passe à la ligne suivante

                            var waldecRNA = new ObjetSocial
                            {
                                ObjetSocialParentID = int.Parse(values[0]),
                                ObjetSocialParentLib = values[1],
                                ObjetSocialID = int.Parse(values[2]),
                                ObjetSocialLib = values[3]
                            };
                            waldecRNAs.Add(waldecRNA);
                        }
                    }
                }
            }
            return waldecRNAs;
        }
    }
}
