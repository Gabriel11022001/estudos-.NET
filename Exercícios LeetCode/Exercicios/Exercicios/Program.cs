using Exercicios.Classes;

try
{
    int opcaoExercicio = 0;
    int ultimoExercicio = 9;
    List<IExercicio> exercicios = GerarExercicios();

    while (opcaoExercicio == 0)
    {
        Console.WriteLine("Informe qual exercício você deseja executar:");
        opcaoExercicio = int.Parse(Console.ReadLine());

        if (opcaoExercicio <= 0 || opcaoExercicio > ultimoExercicio)
        {
            Console.WriteLine("Exercício inválido!");
            opcaoExercicio = 0;
        }
        else
        {
            IExercicio exercicioExecutar = null;

            if (opcaoExercicio == 1)
            {
                exercicioExecutar = new Exercicio1();
            }

            if (opcaoExercicio == 9)
            {
                exercicioExecutar = new Exercicio9();
            }

            exercicioExecutar.ExecutarExercicio();
        }

    }

}
catch (Exception e)
{
    Console.WriteLine("Erro: " + e.Message);
}

List<IExercicio> GerarExercicios()
{
    List<IExercicio> exercicios = new List<IExercicio>();
    exercicios.Add(new Exercicio1());
    exercicios.Add(new Exercicio9());

    return exercicios;
}