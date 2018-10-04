using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA (lange Syntax)
            Data.Lied klasseA1 = new Data.Lied();
            klasseA1.Titel = "Artikel 1";
            klasseA1.Künstler = "Michael Jackson";
            klasseA1.ReleaseDate = DateTime.Today;
            klasseA1.Playlist = Data.Playlist.LesenAttributWie("Artikelgruppe 1").FirstOrDefault();
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Lied klasseA in Data.Lied.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.LiedId + " Name:" + klasseA.Titel + " Artikelgruppe:" + klasseA.Playlist.PlaylistName);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Lied klasseA1 = Data.Lied.LesenID(1);
            klasseA1.Titel = "Artikel 1 nach Update";
            klasseA1.PlaylistId = 2;  // Wichtig: Fremdschlüssel muss über Id aktualisiert werden!
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Lied.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
        #region KlasseB
        // Create
        public static void DemoBCreate()
        {
            Debug.Print("--- DemoBCreate ---");
            // KlasseB (kurze Syntax)
            Data.Playlist klasseB1 = new Data.Playlist { PlaylistName = "Artikelgruppe 1", Favorisiert = true, ErstellDatum = DateTime.Today.AddDays(-1) };
            Int64 klasseB1Id = klasseB1.Erstellen();
            Debug.Print("Gruppe erstellt mit Id:" + klasseB1Id);
            Data.Playlist klasseB2 = new Data.Playlist { PlaylistName = "Artikelgruppe 2", Favorisiert = true, ErstellDatum = DateTime.Today };
            Int64 klasseB2Id = klasseB2.Erstellen();
            Debug.Print("Gruppe erstellt mit Id:" + klasseB2Id);
        }
        // Read
        public static void DemoBRead()
        {
            Debug.Print("--- DemoBRead ---");
            // Demo liest 1 Objekt
            Data.Playlist klasseB = Data.Playlist.LesenAttributGleich("Artikelgruppe 1").FirstOrDefault();
            Debug.Print("Auslesen einzelne Gruppe mit Name: " + klasseB.PlaylistName + " Datum" + klasseB.ErstellDatum.ToString("dd.MM.yyyy"));
            // Liste auslesen
            foreach(Data.Lied klasseA in klasseB.Lied)
            {
                Debug.Print("Artikelgruppe: " + klasseB.PlaylistName + " enthält Artikel:" + klasseA.Titel);
            }
        }
        // Update
        public static void DemoBUpdate()
        {
            Debug.Print("--- DemoBUpdate ---");
            Data.Playlist klasseB = Data.Playlist.LesenID(1);
            klasseB.PlaylistName = "Artikelgruppe 2 nach Update";
            klasseB.Aktualisieren();
            Debug.Print("Gruppe mit Name 'Artikelgruppe 1' verändert");
        }
        // Delete
        public static void DemoBDelete()
        {
            Debug.Print("--- DemoBDelete ---");
            // Achtung! Referentielle Integrität darf nicht verletzt werden!
            try
            {
                Data.Playlist klasseB = Data.Playlist.LesenID(1);
                klasseB.Loeschen();
                Debug.Print("Gruppe mit Id 1 gelöscht");
            } catch (Exception ex)
            {
                Debug.Print("Fehler beim Löschen:" + ex.Message);
            }
        }
        #endregion
    }
}
