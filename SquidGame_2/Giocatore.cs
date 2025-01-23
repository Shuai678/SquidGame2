using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquidGame_2
{
    public class Giocatore
    {
        public PictureBox Imagine { get; set; } // PictureBox che rappresenta il giocatore
        public Label EtichettaTasto { get; set; } // Etichetta che mostra il tasto da premere
        public char TastoRichiesto { get; set; } // Tasto richiesto
        public bool Fermo { get; set; } // Indica se il giocatore è fermo

        public Giocatore(PictureBox imagine, Label etichettaTasto, char tastoRichiesto, bool fermo)
        {
            Imagine = imagine;
            EtichettaTasto = etichettaTasto;
            TastoRichiesto = tastoRichiesto;
            Fermo = fermo;
        }
    }
}
