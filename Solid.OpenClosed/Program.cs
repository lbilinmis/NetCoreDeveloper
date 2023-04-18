// See https://aka.ms/new-console-template for more information
//using Solid.OpenClosed.Bad;
using Solid.OpenClosed.Good;

Console.WriteLine("Hello, World!");


//open closed prensibine aykırı kod yazılı 1.Durum
//SalaryCalculate salaryCalculate = new SalaryCalculate();
//Console.WriteLine("Low Salary : "+salaryCalculate.Calculate(1000,SalaryType.Low));
//Console.WriteLine("Middle Salary : "+salaryCalculate.Calculate(1000,SalaryType.Middle));
//Console.WriteLine("High Salary : "+salaryCalculate.Calculate(1000,SalaryType.High));


SalaryCalculate salaryCalculate = new SalaryCalculate();
Console.WriteLine("Low Salary : " + salaryCalculate.Calculate(1000, new LowSalaryCalculate()));
Console.WriteLine("Middle Salary : " + salaryCalculate.Calculate(2000, new MiddleSalaryCalculate()));
Console.WriteLine("High Salary : " + salaryCalculate.Calculate(3000, new HighSalaryCalculate()));
Console.WriteLine("High Salary : " + salaryCalculate.Calculate(4000, new HighOnSalaryCalculate()));
