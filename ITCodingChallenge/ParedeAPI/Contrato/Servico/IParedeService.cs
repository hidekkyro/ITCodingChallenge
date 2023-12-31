﻿namespace ParedeAPI.Contrato.Servico
{
    public interface IParedeService
    {
        int[][] GerarParedeExemplo();
        int[][] GerarParedeMassaGrande();
        bool IsParede(int[][]? parede);
        int MenorNumTijolosCortados(int[][] parede);
    }
}
