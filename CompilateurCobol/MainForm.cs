using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CompilateurCobol
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        //
        //+--------------------------------------------------------+
        //|               Variables Globales                       |
        //+--------------------------------------------------------+
        //
        string RepertoireSource, RepertoireDestination, LigneDeCommande, LigneDeCommande2, ArgPrecompilation;
        
		public MainForm()
		{
			InitializeComponent();
		}
        //
        //+--------------------------------------------------------+
        //|               Au démarrage du programme                |
        //+--------------------------------------------------------+
        //
		void MainFormLoad(object sender, EventArgs e)
		{
            // Démarrage du timer
            timer1.Start();
            // Initialisation de l'extention du fichier de sortie
            comboBoxEXT.SelectedItem = 0;
            comboBoxEXT.SelectedIndex = 0;
		}
        //
        //+--------------------------------------------------------+
        //|                  COMPILATION                           |
        //+--------------------------------------------------------+
        //
		void ButtonCompilerClick(object sender, EventArgs e)
		{
			textBoxPreCompil.Text = "";
			textBoxOUTInfo.Text = "";
			if (textBoxFicSrc.Text != "" && textBoxFicSor.Text != "")
			{
            	string RepertoireGnuCOBOLsource = Environment.CurrentDirectory + "\\cobc\\SOURCE\\";
            	string RepertoireGnuCOBOLoutput = Environment.CurrentDirectory + "\\cobc\\OUTPUT\\";
            	string RepFicDLL = Environment.CurrentDirectory + "\\cobc\\bin2\\";
           
				RepertoireSource = Path.GetDirectoryName(textBoxFicSrc.Text);
				RepertoireDestination = Path.GetDirectoryName(textBoxFicSor.Text);		

                //+--------------------------------------------------+
                //|Création du répertoire de sortie : 'RepertoireBin'|
                //+--------------------------------------------------+
                string RepertoireBin = RepertoireDestination;
                Directory.CreateDirectory(RepertoireBin);
                //
                //+------------------------------------------+
                //|Copie du/des fichiers source dans 'SOURCE'|
                //+------------------------------------------+
                // Fichier - Programme principal
                if (File.Exists(textBoxFicSrc.Text))
                {
                    File.Copy(textBoxFicSrc.Text, RepertoireGnuCOBOLsource + Path.GetFileName(textBoxFicSrc.Text), true);
                }
                else
                {
                    MessageBox.Show("Fichier manquant : " + textBoxFicSrc.Text, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // listBoxSRCadd - Fichiers additionnels
                for (int i = 0; i < listBoxSRCadd.Items.Count; i++)
                {
                    string MonFichier = listBoxSRCadd.Items[i].ToString();
                    if (File.Exists(MonFichier))
                    {
                        File.Copy(MonFichier, RepertoireGnuCOBOLsource + Path.GetFileName(MonFichier), true);
                    }
                }                
                //
                //+----------------------------------------------------+
                //|Copie des DLL du 'RepFicDLL' dans le 'RepertoireBin'|
                //+----------------------------------------------------+
                string[] LesFichiersDLL = Directory.GetFiles(RepFicDLL);
                //
                foreach (string FichierDLL in LesFichiersDLL)
                {
                    // Remove path from the file name.
                    string fName = FichierDLL.Substring(RepFicDLL.Length);
                    //
                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(RepFicDLL, fName), Path.Combine(RepertoireBin, fName), true);
                }                
            	//
            	//+----------------------------------------------------+
            	//|Appel de la fonction de compilation                 |
           	 	//+----------------------------------------------------+

            	if (checkBoxEsqlOC.Checked)
            	{   // ---------------------------
            		// Avec Pré-compilation esqlOC
            		// ---------------------------
            		var result1 = ProcessPrecompilation(ArgPrecompilation);
           		 	// Résultat de la Pré-compilation
            		foreach (string r in result1)
            			{ textBoxPreCompil.Text += r + "\n"; }
            		//            	
            		// Puis compilation normale
            		//
            		var result2 = ProcessCmd(RepertoireSource, LigneDeCommande2);
            		// Résultat de la compilation
			  		textBoxOUTInfo.Text = "";
              		foreach (string r in result2)
                   		{ textBoxOUTInfo.Text += r + "\n"; }
            	}
            	else
            	{   // ---------------------------
            		// Sans Pré-compilation esqlOC           	
				    // ---------------------------
            		var result = ProcessCmd(RepertoireSource, LigneDeCommande);
			  	  // Résultat de la compilation
			  	  textBoxOUTInfo.Text = "";
             	   foreach (string r in result)
             	   { textBoxOUTInfo.Text += r + "\n"; }
            	}          
           		//
           	 	// Si compilation OK           
            	//
            	//+----------------------------------------+
            	//|Suppression fichier source dans 'SOURCE'|
            	//+----------------------------------------+
            	// Fichier - Programme principal
            	if (File.Exists(RepertoireGnuCOBOLsource + Path.GetFileName(textBoxFicSrc.Text)))
             		{ File.Delete(RepertoireGnuCOBOLsource + Path.GetFileName(textBoxFicSrc.Text)); }
            
            	// Fichier issu de la Pré-compilation
            	if (File.Exists(RepertoireGnuCOBOLsource + Path.GetFileNameWithoutExtension(textBoxFicSrc.Text) + "-2.cbl"))
                	{ File.Delete(RepertoireGnuCOBOLsource + Path.GetFileNameWithoutExtension(textBoxFicSrc.Text) + "-2.cbl"); }
            
            	// listBoxSRCadd - Fichier(s) additionnel(s)
            	for (int i = 0; i < listBoxSRCadd.Items.Count; i++)
            	{
                	string MonFichier = listBoxSRCadd.Items[i].ToString();
                	if (File.Exists(RepertoireGnuCOBOLsource + Path.GetFileName(MonFichier)))
                   		{ File.Delete(RepertoireGnuCOBOLsource + Path.GetFileName(MonFichier)); }
            	}
            	//
            	//+-----------------------------------------------------------------+
            	//|Déplacement des Fichiers de 'OUTPUT' vers 'RepertoireDestination'|
            	//+-----------------------------------------------------------------+
            	string[] LesFichiersOUT = Directory.GetFiles(RepertoireGnuCOBOLoutput);
            	//
            	foreach (string FichierOUT in LesFichiersOUT)
            	{
                	// Remove path from the file name.
	                string fName = FichierOUT.Substring(RepertoireGnuCOBOLoutput.Length);
    	            //
    	            // Si le fichier existe dans le repertoire de destination, on l'efface
    	            if (File.Exists(Path.Combine(RepertoireDestination, fName)))
    	            {
    	                File.Delete(Path.Combine(RepertoireDestination, fName));
    	                File.Move(Path.Combine(RepertoireGnuCOBOLoutput, fName), Path.Combine(RepertoireDestination, fName));
    	            }
    	            else
    	            {
    	                File.Move(Path.Combine(RepertoireGnuCOBOLoutput, fName), Path.Combine(RepertoireDestination, fName));
    	            }
    	        }
    	        MessageBox.Show("Compilation terminé", "Compilation", MessageBoxButtons.OK, MessageBoxIcon.Information);            
				}
				else
				{
					MessageBox.Show("Pas de fichier d'entrée !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
		}
        	//
        	//+--------------------------------------------------------+
        	//|               EXECUTION DE LA COMPILATION              |
        	//+--------------------------------------------------------+
        	// ---------------
        	// PRE-COMPILATION
        	// ---------------
        private static string[] ProcessPrecompilation(string argPreCompil)
        {
        	string[] outinfo;
        	
        	Process Precompiler = new Process();
        	string RepesqlOC = Environment.CurrentDirectory + "\\cobc\\bin\\";
        	Precompiler.StartInfo.FileName = RepesqlOC + "esqlOC.exe";
        	Precompiler.StartInfo.WorkingDirectory = RepesqlOC;
        	Precompiler.StartInfo.Arguments = argPreCompil;
        	Precompiler.StartInfo.UseShellExecute = false;
            Precompiler.StartInfo.RedirectStandardOutput = true;
            Precompiler.StartInfo.RedirectStandardError = true;
            Precompiler.Start();

            var test = Precompiler.StandardOutput.ReadToEnd();
            var test1 = Precompiler.StandardError.ReadToEnd();

            Console.WriteLine(Precompiler.StandardOutput.ReadToEnd());
            if (test != "")
            {
                outinfo = test.ToString().Split('\n');
            }
            else
            {
                outinfo = test1.ToString().Split('\n');
            }

            Precompiler.WaitForExit();
            return outinfo;
        }
        // -----------
        // COMPILATION
        // -----------
        private static string[] ProcessCmd(string repertoireSource, string ligneDeCommande)
        {
        	string[] outinfo;
        	
        	Process compiler = new Process();
            string Repertoire = Environment.CurrentDirectory + "\\cobc\\";
            compiler.StartInfo.FileName = Repertoire + "bin\\cobc.exe";
            compiler.StartInfo.WorkingDirectory = Repertoire;
            compiler.StartInfo.EnvironmentVariables["COB_MAIN_DIR"] = Repertoire;
            compiler.StartInfo.EnvironmentVariables["COB_CONFIG_DIR"] = Repertoire + "config";
          //compiler.StartInfo.EnvironmentVariables["COB_COPY_DIR"] = Repertoire + "copy";
            compiler.StartInfo.EnvironmentVariables["COB_COPY_DIR"] = repertoireSource;
          //compiler.StartInfo.EnvironmentVariables["COB_CFLAGS"] = "-I" + Repertoire + "include";
          //compiler.StartInfo.EnvironmentVariables["COB_LDFLAGS"] = "-L" + Repertoire + "lib";
            compiler.StartInfo.EnvironmentVariables["COB_LIBRARY_PATH"] = Repertoire + "extras";
            compiler.StartInfo.EnvironmentVariables["PATH"] = Repertoire + "bin";            
            compiler.StartInfo.Arguments = ligneDeCommande;
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.RedirectStandardError = true;
            compiler.Start();            
        	
            var test = compiler.StandardOutput.ReadToEnd();
            var test1 = compiler.StandardError.ReadToEnd();

            Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            if (test != "")
            {
                outinfo = test.ToString().Split('\n');
            }
            else
            {
                outinfo = test1.ToString().Split('\n');
            }

            compiler.WaitForExit();
            return outinfo;
        }
        //
        //+--------------------------------------------------------+
        //|            Sélectionner le fichier source              |
        //+--------------------------------------------------------+
        //        
		void Button1Click(object sender, EventArgs e)
		{
			string filename = textBoxFicSrc.Text;
			OpenFileDialog dlg = new OpenFileDialog();

	        //Si textBoxFicSrc.Text non vide, on prends
            if (textBoxFicSrc.Text != "")
            {
                if (!Directory.Exists(filename))
                {
                    dlg.InitialDirectory = Path.GetDirectoryName(filename);
                }
                else
                {
                    dlg.InitialDirectory = Environment.CurrentDirectory;
                }
            }
            // Quand fichier choisi, on met le chemin dans : textBoxFicSrc.Text
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string FileName;
                FileName = dlg.FileName;
                textBoxFicSrc.Text = FileName;
                string fichierOUT = Path.GetFileNameWithoutExtension(FileName);

                // Fichier en sortie
                filename = textBoxFicSrc.Text;
                string OutFileDirectory = Path.GetDirectoryName(filename) + "\\bin\\" + fichierOUT + comboBoxEXT.Text;
                textBoxFicSor.Text = OutFileDirectory;
            }            
		}
        //
        //+--------------------------------------------------------+
        //| Sélectionner des fichiers sources additionnels         |
        //+--------------------------------------------------------+
        //
		void Button2Click(object sender, EventArgs e)
		{
            OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "All Files *.txt | *.txt";
            open.Multiselect = true;
            open.Title = "Fichiers additionnels";
            listBoxSRCadd.Items.Clear();

            if (open.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in open.FileNames)
                {
                    listBoxSRCadd.Items.Add(file);
                }
            }
		}
        //
        //+--------------------------------------------------------+
        //| A chaque Tick du Timer                                 |
        //+--------------------------------------------------------+
        //
		void Timer1Tick(object sender, EventArgs e)
		{
            // Ligne de commande - SOURCE
            string FicEnt = "SOURCE\\" + Path.GetFileName(textBoxFicSrc.Text);
            string FicEnt2 = "SOURCE\\" + Path.GetFileNameWithoutExtension(textBoxFicSrc.Text) + "-2.cbl"; // Sera crée suite à la pré-compilation
            
            ArgPrecompilation = " -static -o \"" + Environment.CurrentDirectory + "\\cobc\\" + FicEnt2 + "\" \"" + Environment.CurrentDirectory + "\\cobc\\" + FicEnt + "\"";
            string FicSqlite = "sqlite\\cob-sqlite3.c sqlite\\sqlite3.c";                      
            
            string FichierACompiler = "";         
            string FichierACompiler2 = "";
            
            if (checkBoxSQLite.Checked)
            {
                FichierACompiler = FicEnt + " " + FicSqlite;
                FichierACompiler2 = FicEnt2 + " " + FicSqlite;
            }
            else
            {
                FichierACompiler = FicEnt;
                FichierACompiler2 = FicEnt2;
            }
            
            // Ligne de commande - OUTPUT
            string FicSor = "-o OUTPUT\\" + Path.GetFileNameWithoutExtension(textBoxFicSrc.Text);
            
            // Fichier(s) additionnel(s)
            string FicEntAdd = "";
            //
            if (listBoxSRCadd.Items.Count > 0)
            {
                for (int i = 0; i < listBoxSRCadd.Items.Count; i++)
                {
                    string MonFichier = listBoxSRCadd.Items[i].ToString();
                    FicEntAdd = FicEntAdd + " " + "SOURCE\\" + Path.GetFileName(MonFichier);
                }
            }
            //
            //+-------------------+
            //|Compilation en .exe|
            //+-------------------+
            if (comboBoxEXT.Text == ".exe")
            {
                LigneDeCommande = "-x " + FichierACompiler + FicEntAdd + " " + FicSor + ".exe";
                LigneDeCommande2 = "-x " + FichierACompiler2 + FicEntAdd + " " + FicSor + ".exe"; 
            }
            //+-------------------+
            //|Compilation en .dll|
            //+-------------------+
            if (comboBoxEXT.Text == ".dll")
            {
                LigneDeCommande = "-b " + FichierACompiler + FicEntAdd + " " + FicSor + ".dll";
                LigneDeCommande2 = "-b " + FichierACompiler2 + FicEntAdd + " " + FicSor + ".dll";
            }
            //+-------------------+
            //|Compilation en .c  |
            //+-------------------+
            //
            if (comboBoxEXT.Text == ".c")
            {
                LigneDeCommande = "-C " + FichierACompiler + FicEntAdd + " " + FicSor + ".c";
                LigneDeCommande2 = "-C " + FichierACompiler2 + FicEntAdd + " " + FicSor + ".c";
            }
            if (textBoxFicSor.Text != "")
            {
            	string CheminComplet = textBoxFicSor.Text;
            	string CheminSansExt = CheminComplet.Substring(0, CheminComplet.IndexOf("."));
            	textBoxFicSor.Text = CheminSansExt + comboBoxEXT.Text;
            }
            
		}
        //
        //+--------------------------------------------------------+
        //|         Effacer les fichiers additionnels              |
        //+--------------------------------------------------------+
        //
		void Button3Click(object sender, EventArgs e)
		{
			listBoxSRCadd.Items.Clear();	
		}
        //
        //+--------------------------------------------------------+
        //|         Ouvrir le dossier de sortie                    |
        //+--------------------------------------------------------+
        //
		void Button4Click(object sender, EventArgs e)
		{
			if (textBoxFicSor.Text != "")
			{
				string RepertoireBin = Path.GetDirectoryName(textBoxFicSor.Text);
				if(!Directory.Exists(RepertoireBin))
				{
					Directory.CreateDirectory(RepertoireBin);
				}
				Process.Start(RepertoireBin);
			}
			
	
		}
	}
}
