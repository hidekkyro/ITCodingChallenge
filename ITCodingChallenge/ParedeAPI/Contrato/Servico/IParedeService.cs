namespace ParedeAPI.Contrato.Servico
{
    public interface IParedeService
    {
        int[][] GerarParedeExemplo();
        bool IsParede(int[][]? parede);
        int ContaParede(int[][] parede);
    }
}
