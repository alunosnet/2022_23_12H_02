using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M15_ProjetoFutebol
{
    class Utils
    {
        static public byte[] ImagemParaVetor(string ficheiro)
        {
            FileStream fs = new FileStream(ficheiro, FileMode.Open, FileAccess.Read);
            byte[] dados = new byte[fs.Length];
            fs.Read(dados, 0, (int)fs.Length);
            fs.Close();
            return dados;
        }
        static public void VetorParaImagem(byte[] imagem, string ficheiro)
        {
            FileStream fs = new FileStream(ficheiro, FileMode.Create, FileAccess.Write);
            fs.Write(imagem, 0, imagem.GetUpperBound(0));
            fs.Close();
        }
        static public string pastaDoPrograma()
        {
            string pastaInicial = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            pastaInicial += @"\M14_15_TrabalhoModelo";
            if (System.IO.Directory.Exists(pastaInicial) == false)
                System.IO.Directory.CreateDirectory(pastaInicial);
            return pastaInicial;
        }
    }
}
