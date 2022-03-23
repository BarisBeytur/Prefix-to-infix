using System;

public class StackNode
{
	public String veri;
	public StackNode sonraki;
	public StackNode(String veri, StackNode top)
	{
		this.veri = veri;
		this.sonraki = top;
	}
}
public class MyStack
{
	public StackNode top;
	public int sayac;
	public MyStack()
	{
		this.top = null;
		this.sayac = 0;
	}
	
	public int size()
	{
		return this.sayac;
	}
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
	// Stack'e yeni eleman ekleme
	public void push(String veri)
	{
		this.top = new StackNode(veri, this.top);
		this.sayac++;
	}
	public String pop()
	{
		var temp = "";
		if (this.isEmpty() == false)
		{
			temp = this.top.veri;
			this.top = this.top.sonraki;
			this.sayac--;
		}
		return temp;
	}
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
public class Conversion
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
		var s = new MyStack();
		var ek = "";
		var op1 = "";
		var op2 = "";
		var isValid = true;
		for (var i = size - 1; i >= 0; i--)
		{
			if (this.isOperator(prefix[i]))
			{
				if (s.size() > 1)
				{
					op1 = s.pop();
					op2 = s.pop();
					ek = "(" + op1 + prefix[i] + op2 + ")";
					s.push(ek);
				}
				else
				{
					isValid = false;
				}
			}
			else if (this.isOperands(prefix[i]))
			{
				ek = prefix[i].ToString();
				s.push(ek);
			}
			else
			{
				// geçersiz operatör veya işlenen 
				isValid = false;
			}
		}
		if (isValid == false)
		{
			Console.WriteLine("Geçersiz prefix : " + prefix);
		}
		else
		{
			Console.WriteLine(" Infix  : " + s.pop());
		}
	}
	public static void Main(String[] args)
	{
		var task = new Conversion();
		Console.Write("Prefix ifade gir: ");
		var prefix = Convert.ToString(Console.ReadLine());
		Console.WriteLine();
		task.prefixToinfix(prefix);
		Console.ReadKey();
	}
}