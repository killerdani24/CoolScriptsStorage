// 2020, Killerdani, https://github.com/killerdani24
// this Script takes the coordinates of Main Point(Pm) and Main Point Nether Portal(Pmn) and calculates the coordinates of corresponding Nether Portal Point of desired point

/* Extra information if interested, it's basically Pythagorean Theorem
	Pm(Xm, Zm)
	Pmn(Xmn, Zmn)
	P2(X2, Z2)
	P2n(X2n, Z2n)
	h2 = Zmn - Z2n
	w2 = Xmn - X2n
	d1 = ((w1 ** 2) + (h1 ** 2)) ** 0.5
	d2 = d1 / 8

	h1 = Zm - Z2;
	w1 = Xm - X2;
	h2 = h1 / 8;
	w2 = w1 / 8;
	X2n = Xmn - w2;
	Z2n = Zmn - h2;
*/

Console.WriteLine("Enter X coordinate of the overworld portal (start): ");
float Xm  = float.Parse(Console.ReadLine());
Console.WriteLine("Enter Z coordinate of the overworld portal (start): ");
float Zm  = float.Parse(Console.ReadLine());
Console.WriteLine("Enter X coordinate of the nether portal (start): ");
float Xmn = float.Parse(Console.ReadLine());
Console.WriteLine("Enter Z coordinate of the nether portal (start): ");
float Zmn = float.Parse(Console.ReadLine());
Console.WriteLine("Enter X coordinate of the destiantion in  over world (end): ");
float X2  = float.Parse(Console.ReadLine());
Console.WriteLine("Enter Z coordinate of the destiantion in  over world (end): ");
float Z2  = float.Parse(Console.ReadLine());

float X2n = Xmn - ((Xm - X2) / 8);
float Z2n = Zmn - ((Zm - Z2) / 8);
Console.WriteLine($"X coordinate of nether portal: {X2n}");
Console.WriteLine($"Z coordinate of nether portal: {Z2n}");
