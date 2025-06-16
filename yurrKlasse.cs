using AntMe.Deutsch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.yurr
{
    /// <summary>
    /// Diese Datei enthält die Beschreibung für deine Ameise. Die einzelnen Code-Blöcke 
    /// (Beginnend mit "public override void") fassen zusammen, wie deine Ameise in den 
    /// entsprechenden Situationen reagieren soll. Welche Befehle du hier verwenden kannst, 
    /// findest du auf der Befehlsübersicht im Wiki.
    /// 
    /// Wenn du etwas Unterstützung bei der Erstellung einer Ameise brauchst, findest du
    /// in den AntMe!-Lektionen ein paar Schritt-für-Schritt Anleitungen.
    ///
    /// Link zum Wiki: https://wiki.antme.net
    /// </summary>
    [Spieler(
        Volkname = "yurr",   // Hier kannst du den Namen des Volkes festlegen
        Vorname = "",       // An dieser Stelle kannst du dich als Schöpfer der Ameise eintragen
        Nachname = ""       // An dieser Stelle kannst du dich als Schöpfer der Ameise eintragen
    )]

    /// Kasten stellen "Berufsgruppen" innerhalb deines Ameisenvolkes dar. Du kannst hier mit
    /// den Fähigkeiten einzelner Ameisen arbeiten. Wie genau das funktioniert kannst du der 
    /// Lektion zur Spezialisierung von Ameisen entnehmen.
    [Kaste(
        Name = "Standard",                  // Name der Berufsgruppe
        AngriffModifikator = 0,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = 0, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = 0,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 0,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = 0,                // Tragkraft einer Ameise
        ReichweiteModifikator = 0,          // Ausdauer einer Ameise
        SichtweiteModifikator = 0           // Sichtweite einer Ameise
    )]
    public class yurrKlasse : Basisameise
    {
        public yurrKlasse()
        {
        }
        #region Kasten


        public override string BestimmeKaste(Dictionary<string, int> anzahl)
        {
            // Gibt den Namen der betroffenen Kaste zurück.
            return "Standard";
        }

        #endregion

        #region Fortbewegung

        
        public override void Wartet()
        {
            GeheGeradeaus();
        }

        
        public override void WirdMüde()
        {
        }

       
        public override void IstGestorben(Todesart todesart)
        {
        }

       
        public override void Tick()
        {
        }

        #endregion

        #region Nahrung


        public override void Sieht(Obst obst)
        {
            if (!(Ziel is Wanze))
            if (AktuelleLast == 0 && BrauchtNochTräger(obst))
            {
                GeheZuZiel(obst);
            }
        }

        public override void Sieht(Zucker zucker)
        {
            if (!( Ziel is Wanze))
            if (AktuelleLast == 0)

            {
                GeheZuZiel(zucker);
            }
        }

        public override void ZielErreicht(Obst obst)
        {
            if (BrauchtNochTräger(obst))
            {
                Nimm(obst);
                GeheZuBau();
            }
        }

        public override void ZielErreicht(Zucker zucker)
        {
            Nimm(zucker);
            GeheZuBau();
        }

        #endregion

        #region Kommunikation

        public override void RiechtFreund(Markierung markierung)
        {
        }

       
        public override void SiehtFreund(Ameise ameise)
        {
        }

        public override void SiehtVerbündeten(Ameise ameise)
        {
        }

        #endregion

        #region Kampf

       
        public override void SiehtFeind(Ameise ameise)
        {
        }


        
        public override void SiehtFeind(Wanze wanze)
        {
            LasseNahrungFallen();
            if (AnzahlAmeisenInSichtweite >= 2)
            {
                GreifeAn(wanze);
            }
            else
            {
                GeheWegVon(wanze);
            }
        }


        public override void WirdAngegriffen(Ameise ameise)
        {
        }


        public override void WirdAngegriffen(Wanze wanze)
        {
            if (AktuelleEnergie < MaximaleEnergie / 2)
            {
                GeheZuBau();
            }
        }

        #endregion
    }
}
