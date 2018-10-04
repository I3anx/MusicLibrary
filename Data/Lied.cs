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
    public class Lied
    {
        #region Datenbankschicht
        [Key]
        public Int64 LiedId { get; set; }
        [Required]
        public String Titel { get; set; }
        [Required]
        public String Künstler { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Boolean BereitsInPlaylist { get; set; }
        public Int64 PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        #endregion
        #region Applikationsschicht
        public Lied() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Data.Lied> LesenAlle()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Lied.Include(x => x.Playlist) select record).ToList();
            }
        }
        public static Data.Lied LesenID(Int64 klasseAId)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Lied.Include(x => x.Playlist) where record.LiedId == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Data.Lied> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Lied.Include(x => x.Playlist) where record.Titel == suchbegriff select record).ToList();
            }
        }
        public static List<Data.Lied> LesenAttributWie(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Lied.Include(x => x.Playlist) where record.Titel.Contains(suchbegriff) select record).ToList();
            }
        }
        public static List<Data.Lied> LesenFremdschluesselGleich(Data.Playlist suchschluessel)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Lied.Include(x => x.Playlist) where record.Playlist == suchschluessel select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Titel == null || this.Titel == "") this.Titel = "leer";
            // Option mit Fehler statt Default Value
            // if (klasseA.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (this.ReleaseDate == null) this.ReleaseDate = DateTime.MinValue;
            using (var context = new Data.Context())
            {
                context.Lied.Add(this);
                //TODO Check ob mit null möglich, sonst throw Ex
                if (this.Playlist != null) context.Playlist.Attach(this.Playlist);
                context.SaveChanges();
                return this.LiedId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                this.Playlist = null;
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return this.LiedId;
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
            return LiedId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
