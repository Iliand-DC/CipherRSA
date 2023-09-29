namespace CipherRSA;
using System.Numerics;


public partial class MainPage : ContentPage
{
	Alphabet alphabet = new Alphabet();
	long decrypt;
	long encrypt;
	long n;
	long phi;
	long p;
	long q;

    public MainPage()
	{
		InitializeComponent();
	}

    private void OnCounterClicked(object sender, EventArgs e)
	{
        Random random = new Random();
        FindPrime findPrime = new FindPrime(random.NextInt64(1,20));
        p = findPrime.GetPrime();
        findPrime = new FindPrime(random.NextInt64(1,20));
        q = findPrime.GetPrime();

        //p = Convert.ToInt64(PNumber.Text);
        //q = Convert.ToInt64(QNumber.Text);
        n = p * q;

        phi = (p - 1) * (q - 1);

        FindCoprime findCoprime = new FindCoprime(phi);
        encrypt = findCoprime.GetE();

        //encrypt = Convert.ToInt64(EncryptKey.Text);


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
		EncryptMessage.Text = newWord;
	}

    void Decrypt_Clicked(System.Object sender, System.EventArgs e)
    {
		string newWord = EncryptMessage.Text;
		string[] words = newWord.Split(' ');
        newWord = "";

		//decrypt = Convert.ToInt64(DecryptKey.Text);
		decrypt = (1*phi + 1) / encrypt;
		Console.WriteLine(decrypt);

        foreach (var word in words)
		{
			BigInteger result = new BigInteger(Convert.ToInt32(word));
			result = BigInteger.Pow(result, Convert.ToInt32(decrypt));
			Console.WriteLine(result);
			result %= n;
			Console.WriteLine(result);
			char symbol = alphabet.GetSymbolByNumber(result);
			newWord += symbol;
		}
		Output.Text = newWord;
    }
}

