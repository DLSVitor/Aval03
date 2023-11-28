using System;
using System.IO;

class Program
{

    //Vitor Henrique Cenatti
    static void Main()
    {
        string filePath = @"provinhaBarbadinha.txt";
        string ciphertext = File.ReadAllText(filePath);

        string textodecifrado = DeTeusPulosDecrypt(ciphertext);

        mostrarpalindromo(textodecifrado);

        string replacedText = SubstituirCaracteres(textodecifrado);
        replacedText = replacedText.Replace('@', '\n');

        Console.WriteLine("\nTexto decifrado:");
        Console.WriteLine(replacedText);

        Console.WriteLine($"\nNúmero de caracteres: {replacedText.Length}");

        Console.WriteLine($"\nQuantidade de palavras: {contadorpalavras(replacedText)}");

        Console.WriteLine("\nO texto com letras em maiúsculo:");
        Console.WriteLine(replacedText.ToUpper());
    }

    static string DeTeusPulosDecrypt(string ciphertext)
    {
        char[] letrasdecifradas = new char[ciphertext.Length];

        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (i % 5 == 0)
            {
                letrasdecifradas[i] = (char)(ciphertext[i] - 8);
            }
            else
            {
                letrasdecifradas[i] = (char)(ciphertext[i] - 16);
            }
        }

        return new string(letrasdecifradas);
    }

    static string SubstituirCaracteres(string texto)
    {
        texto = texto.Replace("arara", "gloriosa");
        texto = texto.Replace("ovo", "bondade");
        texto = texto.Replace("osso", "passam");

        return texto;
    }

    static int contadorpalavras(string text)
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static void mostrarpalindromo(string text)
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Palíndromos:");

        foreach (var word in words)
        {
            if (word.Length > 1 && epalindrome(word))
            {
                Console.WriteLine(word);
            }
        }
    }

    static bool epalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (word[left] != word[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }
}
