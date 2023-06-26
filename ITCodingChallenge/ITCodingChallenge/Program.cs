// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using ITCodingChallenge;

BenchmarkRunner.Run<Parede>();

Console.WriteLine("Hello, World!");

Parede parede = new Parede();
parede.GerarParedeExemplo();
//int menor = parede.MenorQtdTijoloCortado();
int menor = parede.ContaParede(parede.parede);


Console.WriteLine($"Parede: \n {parede.Status()}");
Console.WriteLine($"Menor: \n {menor}");

