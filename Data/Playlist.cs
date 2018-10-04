using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Playlist
    {
        #region Datenbankschicht
        [Key]
        public Int64 PlaylistId { get; set; }
        [Required]
        public String PlaylistName { get; set; }
        [Required]
        public DateTime ErstellDatum { get; set; }
        [Required]
        public Boolean Favorisiert { get; set; }
        public ICollection<Lied> Lied { get; set; }
        #endregion
        #region Applikationsschicht
        public Playlist() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Data.Playlist> LesenAlle()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Playlist.Include(x => x.Lied) select record).ToList();
            }
        }
        public static Data.Playlist LesenID(Int64 klasseBId)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Playlist.Include(x => x.Lied) where record.PlaylistId == klasseBId select record).FirstOrDefault();
            }
        }
        public static List<Data.Playlist> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                var klasseBquery = (from record in context.Playlist.Include(x => x.Lied) where record.PlaylistName == suchbegriff select record).ToList();
                return klasseBquery;
            }
        }
        public static List<Data.Playlist> LesenAttributWie(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Playlist.Include(x => x.Lied) where record.PlaylistName.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.PlaylistName == null || this.PlaylistName == "") this.PlaylistName = "leer";
            // Option mit Fehler statt Default Value
            // if (klasseB.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (this.ErstellDatum == null) this.ErstellDatum = DateTime.MinValue;
            using (var context = new Data.Context())
            {
                context.Playlist.Add(this);
                context.SaveChanges();
                return this.PlaylistId;
            }
        }
        public void Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Loeschen()
        {
            using (var context = new Data.Context())
            {
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return PlaylistId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
