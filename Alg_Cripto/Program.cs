using System;

class CriptoanaliseDiferencial
{
    /*
     Como Funciona:
        O XOR é uma operação bit a bit que retorna 1 quando os bits são diferentes e 0 quando são iguais. 
        Por exemplo, 5 ^ 3 resultaria em 6.
        Na criptografia real, essa função seria muito mais complexa, incluindo múltiplas operações como substituições, 
        permutações e rodadas de operações.*/
    static int CipherFunction(int input, int key)
    {
        return input ^ key;
    }

    static void DiferencialCriptoanalise(int[] textosPlanos, int chave)
    {
        Console.WriteLine("Iniciando a Criptoanálise Diferencial...");

        for (int i = 0; i < textosPlanos.Length - 1; i++)
        {
            int textoPlano1 = textosPlanos[i];
            int textoPlano2 = textosPlanos[i + 1];

            int textoCifrado1 = CipherFunction(textoPlano1, chave);
            int textoCifrado2 = CipherFunction(textoPlano2, chave);

            int diferencaPlano = textoPlano1 ^ textoPlano2;
            int diferencaCifrado = textoCifrado1 ^ textoCifrado2;

            Console.WriteLine($"Texto Plano 1: {textoPlano1}, Texto Plano 2: {textoPlano2}");
            Console.WriteLine($"Texto Cifrado 1: {textoCifrado1}, Texto Cifrado 2: {textoCifrado2}");
            Console.WriteLine($"Diferença entre textos planos: {diferencaPlano}");
            Console.WriteLine($"Diferença entre textos cifrados: {diferencaCifrado}\n");

            // Análise básica: Se a diferença entre os textos cifrados corresponde
            // à diferença esperada (pode ser modelado de acordo com o algoritmo real)
            if (diferencaCifrado == diferencaPlano)
            {
                Console.WriteLine("Possível correspondência encontrada!");
            }
        }
    }
    /*
     Como Funciona:
        Iteração Sobre Pares de Textos Planos:
        A função recebe um array de textos planos (textosPlanos) e uma chave (chave).
        Ela percorre cada par de textos planos consecutivos. Por exemplo, se o array de textos planos contiver 4 elementos,
        a função analisará os pares (1,2), (2,3) e (3,4).
        Cifragem dos Textos Planos:
        Para cada par de textos planos, a função aplica a cifra (usando CipherFunction) com a chave fornecida. 
        Isso gera dois textos cifrados correspondentes.
        Cálculo das Diferenças:
        A função calcula a diferença entre os dois textos planos (diferencaPlano) e a diferença entre os dois textos cifrados 
        (diferencaCifrado). Novamente, essa diferença é calculada usando a operação XOR.
        Comparação das Diferenças:
        A função compara diferencaPlano e diferencaCifrado. Em criptoanálise diferencial, esperamos que, se a diferença entre 
        os textos cifrados for semelhante à diferença entre os textos planos, isso pode indicar que estamos nos aproximando 
        da chave correta ou que a função de cifra tem uma vulnerabilidade que pode ser explorada.
        Detecção de Correspondência:
        Se a diferença calculada dos textos cifrados corresponde à diferença esperada (baseada nos textos planos), 
        isso pode sugerir que há uma relação entre a chave usada e a saída cifrada, o que pode ajudar a deduzir a chave.*/

    static void Main(string[] args)
    {
        int chave = 0x6B; // 107 em decimal

        // Conjunto de textos planos para análise
        int[] textosPlanos = { 0x65, 0x6C, 0x6C, 0x6F }; // "hello" em ASCII

        DiferencialCriptoanalise(textosPlanos, chave);
    }
    /*
     Propósito:
        Define uma chave para a cifragem e um conjunto de textos planos que serão analisados.
        Chama a função de criptoanálise para realizar o ataque diferencial usando esses textos e a chave.
    */
}
