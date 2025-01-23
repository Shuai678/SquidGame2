using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
//using System.Windows.Media;

using NAudio.Wave; // Per NAudio
using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;


namespace SquidGame_2
{
    public partial class Form1 : Form
    {
        private List<Giocatore> giocatori = new List<Giocatore>();
        private Random casuale = new Random();
        private bool giocoIniziato = false; 
        private bool luceVerde = true; 
        private Thread threadSemaforo;
        private System.Windows.Media.MediaPlayer mediaPlayer;
        private IWavePlayer waveOut;
        private AudioFileReader audioFile;
        private int tempoSemaforo;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permette alla finestra di intercettare i tasti premuti
            this.KeyDown += Form1_KeyDown; // Aggiunge l'evento KeyDown
            CheckForIllegalCrossThreadCalls = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            etichettaSemaforo.Text = "";
            //areaGioco.Visible = false;
            
            
            /*
            string filePath = @"C:\Users\ziyis\OneDrive\Desktop\SquidGame_2\Resources\Squid Game - Stagione 2  Trailer ufficiale  Netflix Italia.mp3";

            if (System.IO.File.Exists(filePath))
            {
                System.Windows.Media.MediaPlayer mediaPlayer = new System.Windows.Media.MediaPlayer();
                mediaPlayer.Open(new Uri(filePath));
                mediaPlayer.Play();
                //MessageBox.Show("trovato");
            }
            else
            {
                MessageBox.Show($"File non trovato: {filePath}");
            }
            */
        }

        private void MediaPlayer_MediaOpened(object sender, EventArgs e)
        {

                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    double durataAudio = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds; // Durata del file audio
                    tempoSemaforo = casuale.Next(1000, 5000) ; // Tempo iniziale per il semaforo (in secondi)

                    if (durataAudio > 0)
                    {
                        mediaPlayer.SpeedRatio = durataAudio/ (tempoSemaforo/1000); 
                    }

                    mediaPlayer.Play();
                }
        }


        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {

            mediaPlayer.Position = TimeSpan.Zero; // Riporta la posizione dell'audio all'inizio
            mediaPlayer.Play(); // Riproduci di nuovo

        }



        private void AvviaGioco_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\ziyis\OneDrive\Desktop\SquidGame_2\Resources\squidgame-audio.mp3";


            if (System.IO.File.Exists(filePath))
            {
                mediaPlayer = new System.Windows.Media.MediaPlayer();
                mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
                mediaPlayer.MediaEnded += MediaPlayer_MediaEnded; // riprodurre l'audio in loop
                mediaPlayer.Open(new Uri(filePath));
                mediaPlayer.Volume = 1.0; 
            }
            else
            {
                MessageBox.Show($"File non trovato: {filePath}");
            }

            // movimento per ciascun giocatore
            foreach (var giocatore in giocatori)
            {
                var giocatoreCorrente = giocatore; 
                Thread threadGiocatore = new Thread(() => MuoviGiocatore(giocatoreCorrente.Imagine));
                //threadGiocatore.IsBackground = true; // Per terminare il thread automaticamente quando l'app si chiude
                threadGiocatore.Start();
            }
            AvviaGioco.Visible = false;
            /*
            System.Windows.Media.MediaPlayer mediaPlayer = new System.Windows.Media.MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\Users\ziyis\OneDrive\Desktop\SquidGame_2\Resources\Squid Game - Stagione 2  Trailer ufficiale  Netflix Italia.mp3"));
            mediaPlayer.Volume = 1.0; 
            mediaPlayer.Play();
            */

            /*
            string filePath = @"C:\Users\ziyis\OneDrive\Desktop\SquidGame_2\Resources\Squid Game - Stagione 2  Trailer ufficiale  Netflix Italia.mp3";

            if (System.IO.File.Exists(filePath))
            {
                System.Windows.Media.MediaPlayer mediaPlayer = new System.Windows.Media.MediaPlayer();
                mediaPlayer.Open(new Uri(filePath));
                mediaPlayer.Play();
                //MessageBox.Show("trovato");
            }
            else
            {
                MessageBox.Show($"File non trovato: {filePath}");
            }
            */


            
            threadSemaforo = new Thread(ControllaSemaforo);
            threadSemaforo.IsBackground = true;
            threadSemaforo.Start();

        }

        private void ControllaSemaforo()
        {
            Thread.Sleep(3000); 

            while (giocoIniziato)
            {
                luceVerde = !luceVerde;

                this.Invoke((Action)(() =>
                {
                    
                    imagineSemaforo.Image = luceVerde ? Properties.Resources.verde : Properties.Resources.rosso;
                    etichettaSemaforo.Text = luceVerde ? "luceVerde" : "luceRosso";
                    etichettaSemaforo.ForeColor = luceVerde ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                    if (luceVerde)
                    {
                        // Calcola un nuovo tempo semaforo e aggiorna la velocità dell'audio
                        tempoSemaforo = casuale.Next(3000, 5000); 
                        double durataAudio = mediaPlayer.NaturalDuration.HasTimeSpan ?
                                             mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds : 0;

                        if (durataAudio > 0)
                        {
                            mediaPlayer.SpeedRatio = durataAudio / (tempoSemaforo / 1000.0); 
                        }

                        mediaPlayer.Play(); 

                        
                        foreach (var giocatore in giocatori)
                        {
                            giocatore.Fermo = false;
                        }

                        AggiornaTastiGiocatori();
                    }
                    else
                    {
                        
                        mediaPlayer.Position = TimeSpan.Zero;
                        mediaPlayer.Pause();
                    }
                }));

                Thread.Sleep(tempoSemaforo); 
            }
        }



        private void AggiornaTastiGiocatori()
        {
            foreach (var giocatore in giocatori)
            {
                char nuovoTasto = GeneraTastoCasuale();
                giocatore.TastoRichiesto = nuovoTasto;

                if (giocatore.EtichettaTasto != null)
                {
                    giocatore.EtichettaTasto.Text = $"Premi: {nuovoTasto}";
                }
            }
        }
        private char GeneraTastoCasuale()
        {
            return (char)casuale.Next(65, 91); //A- Z
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var giocatore in giocatori)
            {
                if (e.KeyCode.ToString() == giocatore.TastoRichiesto.ToString())
                {
                    giocatore.Fermo = true;

                    if (giocatore.EtichettaTasto != null)
                    {
                        giocatore.EtichettaTasto.Text = "Fermo!";
                    }
                }
            }
        }


        private void Esci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void conferma_Click(object sender, EventArgs e)
        {
            AvviaGioco.Visible = true;
            if (giocoIniziato) return;
            giocoIniziato = true;

            
            int numeroGiocatore = Convert.ToInt32(NumeroGiocatore.Value);

            
            PictureBox[] Giocatore = new PictureBox[numeroGiocatore];
            Label[] EtichettaTasto = new Label[numeroGiocatore];

            for (int i = 0; i < numeroGiocatore; i++)
            {

                Giocatore[i] = new PictureBox
                {
                    Name = $"Giocatore{i + 1}",
                    Size = new Size(50, 50),
                    Location = new Point(3 + (i * 60), 350), 
                    /*
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Blue 
                    */
                    BackgroundImage = Image.FromFile(@"C:\Users\ziyis\OneDrive\Desktop\SquidGame_2\Resources\giocatore1.png"),
                    BackgroundImageLayout = ImageLayout.Stretch
                };


                EtichettaTasto[i] = new Label
                {
                    Name = $"EtichettaTasto{i + 1}",
                    Text = $"Giocatore {i + 1}",
                    Location = new Point(3 + (i * 60), 380), 
                    AutoSize = true
                };


                
                areaGioco.Controls.Add(EtichettaTasto[i]);
                areaGioco.Controls.Add(Giocatore[i]);

                
                giocatori.Add(new Giocatore(Giocatore[i], EtichettaTasto[i], '-', false));
            }

            
            AggiornaTastiGiocatori();

            /*
            // Avvia il movimento per ciascun giocatore
            foreach (var giocatore in giocatori)
            {
                var giocatoreCorrente = giocatore; // Per evitare problemi di cattura della variabile
                Thread threadGiocatore = new Thread(() => MuoviGiocatore(giocatoreCorrente.Imagine));
                //threadGiocatore.IsBackground = true; // Per terminare il thread automaticamente quando l'app si chiude
                threadGiocatore.Start();
            }


            // Avvia il semaforo
            threadSemaforo = new Thread(ControllaSemaforo);
            threadSemaforo.IsBackground = true;
            threadSemaforo.Start();
            */
        }

        private void MuoviGiocatore(PictureBox giocatorePictureBox)
        {
            while (giocoIniziato)
            {
                // Trova il giocatore associato
                var giocatore = giocatori.FirstOrDefault(g => g.Imagine == giocatorePictureBox);

                if (giocatore == null) return;

                if (!giocatore.Fermo && luceVerde)
                {
                    
                    giocatorePictureBox.Top -= casuale.Next(1, 3);

                    if (giocatorePictureBox.Top <= 0)
                    {
                        MessageBox.Show($"{giocatorePictureBox.Name} ha vinto!");
                        giocoIniziato = false;
                    }
                }
                else if (!giocatore.Fermo && !luceVerde)
                {
                    

                    Eliminati.Text =($"{giocatorePictureBox.Name} è stato eliminato!");
                    giocatori.Remove(giocatore);
                    giocatorePictureBox.Visible = false; 


                    return;
                }

                Thread.Sleep(100); 
            }
        }
    }
}
