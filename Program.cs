using System;


// Stack yaratma
public class Stack
{
	public String veri;
	public Stack sonraki;
	public Stack(String veri, Stack top)
	{
		this.veri = veri;
		this.sonraki = top;
	}
}

// Stackin en üst değeri ve sayaç
public class MyStack
{
	public Stack top;
	public int sayac;
	public MyStack()
	{
		this.top = null; // ilk değere null verildi.
		this.sayac = 0;
	}
	
	// Stackin boyunu dönen fonksiyon
	public int size()
	{
		return this.sayac;
	}

	// Stack boş mu kontrolü
	public bool isEmpty()
	{
		if (this.size() > 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
	// Stack'e yeni eleman ekleme (push)
	public void push(String veri)
	{
		this.top = new Stack(veri, this.top); // Yeni eleman yaratıldı ve top değeri o oldu.
		this.sayac++;
	}

	// Stack'den eleman çekme (pop)
	public String pop()
	{
		var temp = ""; // geçici değişken tanımlandı.
		if (this.isEmpty() == false)
		{
			temp = this.top.veri;
			this.top = this.top.sonraki;
			this.sayac--;
		}
		return temp;
	}

	// Stackin en tepesindeki değeri dönen fonksiyon
	public String peek()
	{
		if (!this.isEmpty())
		{
			return this.top.veri;
		}
		else
		{
			return "";
		}
	}
}
public class Donusum
{
	// operatör kontrolü
	public bool isOperator(char text)
	{
		if (text == '+' || text == '-' ||
			text == '*' || text == '/' ||
			text == '^' || text == '%')
		{
			return true;
		}
		return false;
	}
	// işlenen kontrolü
	public bool isOperands(char text)
	{
		if ((text >= '0' && text <= '9') ||
			(text >= 'a' && text <= 'z') ||
			(text >= 'A' && text <= 'Z'))
		{
			return true;
		}
		return false;
	}

	// Prefixten infixe dönüştürme
	public void prefixToinfix(String prefix)
	{
		// boyut alınır
		var size = prefix.Length;
		// stack yaratılır
		var a = new MyStack();
		var ek = "";
		var operator1 = "";
		var operator2 = "";
		var gecerli = true;
		for (var i = size - 1; i >= 0; i--)
		{
			if (this.isOperator(prefix[i]))
			{
				if (a.size() > 1)
				{
					operator1 = a.pop();
					operator2 = a.pop();
					ek = "(" + operator1 + prefix[i] + operator2 + ")";
					a.push(ek);
				}
				else
				{
					gecerli = false;
				}
			}
			else if (this.isOperands(prefix[i]))
			{
				ek = prefix[i].ToString();
				a.push(ek);
			}
			else
			{
				// geçersiz operatör veya işlenen 
				gecerli = false;
			}
		}
		if (gecerli == false)
		{
			Console.WriteLine("Geçersiz prefix : " + prefix);
		}
		else
		{
			Console.WriteLine(" Infix  : " + a.pop());
		}
	}
	public static void Main()
	{
		var gorev = new Donusum();
		Console.Write("Prefix ifade gir: ");
		var prefix = Convert.ToString(Console.ReadLine());
		Console.WriteLine();
		gorev.prefixToinfix(prefix);
		Console.ReadKey();
	}
}