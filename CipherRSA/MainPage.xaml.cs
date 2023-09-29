namespace CipherRSA;
using System.Numerics;


public partial class MainPage : ContentPage
{
	Alphabet alphabet = new Alphabet();
	long decrypt;
	long encrypt;
	long n;
	long phi;

    public MainPage()
	{
		InitializeComponent();
	}

    private void OnCounterClicked(object sender, EventArgs e)
	{
		Random random = new Random();
		FindPrime findPrime = new FindPrime(random.NextInt64(1,20));
		long p = findPrime.GetPrime();
		findPrime = new FindPrime(random.NextInt64(1,20));
		long q = findPrime.GetPrime();

		n = p * q;

		phi = (p - 1) * (q - 1);

		FindCoprime findCoprime = new FindCoprime(phi);
		encrypt = findCoprime.GetE();

		string word = Input.Text;
		word = word.ToUpper();

		string newWord = "";

		for (int i = 0; i<word.Length; i++)
		{
			BigInteger result = new BigInteger(alphabet.GetNumberOfSymbol(word[i]));
			result = BigInteger.Pow(result, Convert.ToInt32(encrypt));
			result %= n;
			newWord += result.ToString();
			if (i != word.Length - 1)
				newWord += ' ';
		}
		Output.Text = newWord;
	}

    void Decrypt_Clicked(System.Object sender, System.EventArgs e)
    {
		string newWord = Output.Text;
		string[] words = newWord.Split(' ');
        newWord = "";

        decrypt = (1 / encrypt) % phi;
		if (decrypt == 0) decrypt = 1;

        foreach (var word in words)
		{
			BigInteger result = new BigInteger(Convert.ToUInt32(word));
			result = BigInteger.Pow(result, Convert.ToInt32(decrypt));
			result %= n;
			char symbol = alphabet.GetSymbolByNumber(result);
			newWord += symbol;
		}
		Output.Text = newWord;
    }
}

