using System;
using System.Reflection.Emit;
using System.Text;


public class CodeGenerator
{
    private const string AllowedCharacters = "ACDEFGHKLMNPRTXYZ234579";

    private const int CodeLength = 8;

    private readonly Random random;

    private readonly List<string> GeneratedCodes = new List<string>();

    // Yapıcı metot, bir CodeGenerator nesnesi oluşturulduğunda çağrılır.
    public CodeGenerator()
    {
        // Rastgele nesnesi oluşturulurken Guid'in karma değeri kullanılır.
        random = new Random(Guid.NewGuid().GetHashCode());
    }

    // Belirli bir sayıda kod üretmek için kullanılan metot.
    public List<string> GenerateCodes(int count)
    {
        // Belirtilen sayıda kod üretmek için döngü oluşturulur.
        for (int i = 0; i < count; i++)
        {
            // Kod üretilir ve listeye eklenir.
            var code = GenerateCode();
            GeneratedCodes.Add(code);
        }
        // Oluşturulan kodların listesi döndürülür.
        return GeneratedCodes;
    }

    // Tek bir kod üretmek için kullanılan metot.
    public string GenerateCode()
    {
        // Kodu oluşturmak için StringBuilder kullanılır.
        StringBuilder codeBuilder = new StringBuilder();

        // Belirtilen uzunlukta kod oluşturulur.
        for (int i = 0; i < CodeLength; i++)
        {
            // Rastgele bir karakter seçilir ve kod oluşturucuya eklenir.
            int randomIndex = random.Next(0, AllowedCharacters.Length);
            char randomChar = AllowedCharacters[randomIndex];
            codeBuilder.Append(randomChar);
        }
        // Oluşturulan kod alınır.
        string code = codeBuilder.ToString();

        // Oluşturulan kod daha önce üretilmiş kodlar arasında yoksa kod döndürülür, aksi takdirde tekrar üretilir.
        return CheckCode(code) ? code : GenerateCode();
    }

    // Üretilen bir kodun daha önce üretilmiş kodlar arasında olup olmadığını kontrol eden metot.
    public bool CheckCode(string codeToCheck)
    {
        // Kodun listeye eklenip eklenmediği kontrol edilir.
        return GeneratedCodes.Contains(codeToCheck) ? false : true;
    }
}

// Ana uygulama sınıfı.
class Program
{
    // Programın giriş noktası.
    static void Main(string[] args)
    {
        // Kod üreticiyi başlatır.
        CodeGenerator generator = new CodeGenerator();

        // Belirtilen sayıda kod üretilir ve konsola yazdırılır.
        var value = generator.GenerateCodes(1000);
        foreach (var item in value)
        {
            Console.WriteLine(item);
        }
    }
}

