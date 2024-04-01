using System;
using System.Collections.Generic;
using System.Text;

public class CodeGenerator
{
    public List<string> UniqueCodes { get; set; } = new List<string>();

    // Geçerli karakterlerin tanımlanması
    private const string AllowedCharacters = "ACDEFGHKLMNPRTXYZ234579";

    // Kod uzunluğunun tanımlanması
    private const int CodeLength = 8;

    // Rastgele sayı üretmek için nesne oluşturulması
    private readonly Random random = new Random();

    public CodeGenerator()
    {
        // Tüm karakter kombinasyonlarının üretilmesi ve UniqueCodes listesine eklenmesi
        string uniqueCode = string.Empty;
        foreach (var x in AllowedCharacters)
        {
            foreach (var y in AllowedCharacters)
            {
                foreach (var z in AllowedCharacters)
                {
                    uniqueCode = x.ToString() + y + z;
                    UniqueCodes.Add(uniqueCode);
                }
            }   
        }
    }

    // Tek bir kod üretme metodu
    public string GenerateCode()
    {
        // Önceden oluşturulmuş benzersiz kodların rastgele seçilmesi
        StringBuilder codeBuilder = new StringBuilder();
        int randomIndex = random.Next(0, UniqueCodes.Count);
        string randomChar = UniqueCodes[randomIndex];
        codeBuilder.Append(randomChar);
        UniqueCodes.Remove(randomChar);

        // Geriye kalan karakterlerin rastgele seçilip eklenmesi
        for (int i = 0; i < CodeLength-3; i++)
        {
            int randomIndex1 = random.Next(0, AllowedCharacters.Length);
            char randomChar1 = AllowedCharacters[randomIndex1];

            codeBuilder.Append(randomChar1);
        }

        return codeBuilder.ToString();
    }

    // Belirli bir sayıda kod üretme metodu
    public List<string> GenerateCodes(int count)
    {
        List<string> codes = new List<string>();

        while (codes.Count < count)
        {
            var code = GenerateCode();
            codes.Add(code);
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
