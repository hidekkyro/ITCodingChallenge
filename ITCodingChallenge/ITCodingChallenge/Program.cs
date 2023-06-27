// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ITCodingChallenge;

BenchmarkRunner.Run<Parede>();

Console.WriteLine("Hello, World!");

Parede parede = new Parede();
int[][] wall = parede.GerarParedeExemplo();
//int menor = parede.MenorQtdTijoloCortado();
//int menor = parede.ContaParede(wall);
int menor = parede.MenorNumTijolosCortados(wall);


Console.WriteLine($"Parede: \n {parede.Status(wall)}");
Console.WriteLine($"Menor: \n {menor}");

