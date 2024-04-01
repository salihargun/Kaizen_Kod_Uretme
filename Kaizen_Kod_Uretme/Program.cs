using System;
using System.Collections.Generic;
using System.Text;

public class CodeGenerator
{
    // Geçerli karakterlerin tanımlanması
    private const string AllowedCharacters = "ACDEFGHKLMNPRTXYZ234579";

    // Kod uzunluğunun tanımlanması
    private const int CodeLength = 8;

    // Rastgele sayı üretmek için nesne oluşturulması
    private readonly Random random = new Random();

    // Tek bir kod üretmek için kullanılan metot.
    public string GenerateCode()
    {
        // Kod oluşturmak için string builder oluşturma
        StringBuilder codeBuilder = new StringBuilder();

        // Belirtilen uzunlukta kod oluşturmak için döngü
        for (int i = 0; i < CodeLength; i++)
        {
            // Rastgele bir karakter seçme
            int randomIndex = random.Next(0, AllowedCharacters.Length);
            char randomChar = AllowedCharacters[randomIndex];

            // Seçilen karakteri kodun sonuna ekleme
            codeBuilder.Append(randomChar);
        }

        // Oluşturulan kodu string'e dönüştürme ve döndürme
        return codeBuilder.ToString();
    }

    // Belirtilen sayıda kod üretmek için kullanılan metot.
    public List<string> GenerateCodes(int count)
    {
        HashSet<string> generatedCodes = new HashSet<string>();
        List<string> codes = new List<string>();

        // Belirtilen sayıda benzersiz kod üretmek için döngü
        while (codes.Count < count)
        {
            var code = GenerateCode();
            if (!generatedCodes.Contains(code))
            {
                generatedCodes.Add(code);
                codes.Add(code);
            }
        }

        return codes;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Kod üretici nesnesinin oluşturulması
        CodeGenerator generator = new CodeGenerator();

        // Belirtilen sayıda kod üretilmesi
        var codes = generator.GenerateCodes(1000);

        // Üretilen kodların yazdırılması
        foreach (var code in codes)
        {
            Console.WriteLine(code);
        }
    }
}
