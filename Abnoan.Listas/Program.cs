using Abnoan.Listas;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Inicializacao
        //Inicialização Vazia
        List<int> numeros = [];

        //Inicialização com Valores Iniciais:
        List<string> frutas = ["Maçã", "Banana", "Abacaxi"];

        //Inicialização com Capacidade Específica
        List<double> temperaturas = new(50);

        //Listas de Objetos
        List<User> usuarios = new();
        var usuario = new User { Nome = "Antonio", Idade = 32 };
        //Listas de Tipos Complexo
        List<DateTime> datasImportantes = new();
        #endregion

        #region Add - AddRange

        frutas.Add("Mamão");
        frutas.Add("Melão");

        List<string> frutasAsiaticas = ["Rambutan", "Durian", "Tamarillo"];
        frutas.AddRange(new string[] { "Cereja", "Manga" });
        frutas.AddRange(frutasAsiaticas);

        // Adiciona o número 10 à lista
        numeros.Add(10);
        // Adiciona vários números de uma vez
        numeros.AddRange(new int[] { 20, 30, 40 });

        // Adiciona um usuário
        usuarios.Add(new User { Nome = "Carlos", Idade = 25 });
        // Adiciona uma lista de usuários
        usuarios.AddRange(new List<User>
                        {
                            new User { Nome = "Diana", Idade = 28 },
                            new User { Nome = "Eva", Idade = 35 }
                        });

        #endregion

        #region ElementAt, First, Last.
        frutas = new List<string> { "Maçã", "Banana", "Cereja" };

        string primeiraFruta = frutas[0];  // Acessa o primeiro elemento: "Maçã"

        string terceiraFruta = frutas.ElementAt(2);  // Retorna "Cereja"

        string primeira = frutas.First();   // Retorna "Maçã"
        string ultima = frutas.Last();      // Retorna "Cereja"

        #endregion

        #region Modificando Itens

        frutas = new List<string> { "Maçã", "Banana", "Cereja" };
        frutas[1] = "Manga";  // Substitui "Banana" por "Manga"

        for (int i = 0; i < frutas.Count; i++)
        {
            if (frutas[i] == "Maçã")
            {
                frutas[i] = "Abacaxi";  // Substitui "Maçã" por "Abacaxi"
            }
        }

        for (int i = 0; i < frutas.Count; i++)
        {
            // Suponha que queremos substituir todas as frutas por "Kiwi"
            frutas[i] = "Kiwi";
        }
        #endregion

        #region Remove, RemoveAt, RemoveAll.

        frutas = new List<string> { "Maçã", "Banana", "Cereja", "Banana" };
        frutas.Remove("Banana");  // Remove a primeira "Banana"

        frutas.RemoveAt(0);  // Remove o primeiro item, "Maçã"

        // Remove todas as frutas que começam com "B"
        frutas.RemoveAll(f => f.StartsWith("B"));

        #endregion

        #region Loops

        List<int> numerosPares = new List<int> { 2, 4, 6, 8, 10 };
        for (int i = 0; i < numerosPares.Count; i++)
        {
            numerosPares[i] *= 2;  // Dobra o valor de cada elemento
        }

        var carros = new List<string> { "Chevete", "Fusca", "Opala" };
        foreach (var carro in carros)
        {
            Console.WriteLine(carro);
        }


        // Remove elementos ímpares da lista durante a iteração
        for (int i = numeros.Count - 1; i >= 0; i--)
        {
            if (numeros[i] % 2 != 0)
            {
                numeros.RemoveAt(i);
            }
        }

        #endregion

        #region Metodos Uteis - LINQ

        #region Consulta e Transformação
        numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var novosNumerosPares = numeros.Where(n => n % 2 == 0);

        var quadrados = numeros.Select(n => n * n);

        var ordenado = numeros.OrderBy(n => n);
        var ordenadoDesc = numeros.OrderByDescending(n => n);

        var grupos = numeros.GroupBy(n => n % 2 == 0 ? "Par" : "Ímpar");
        #endregion

        #region Manipulação e Conversão


        bool contemCinco = numeros.Contains(5);

        int[] arrayNumeros = numeros.ToArray();
        List<int> lista = arrayNumeros.ToList();

        numeros.Clear();



        #endregion

        #endregion

        #region Encadeamento Aluno
        List<Aluno> alunos = new List<Aluno>
        {
            new Aluno { Nome = "Ana", Idade = 20, Curso = "Biologia" },
            new Aluno { Nome = "Lucas", Idade = 22, Curso = "Biologia" },
            new Aluno { Nome = "Marta", Idade = 21, Curso = "Física" },
            new Aluno { Nome = "João", Idade = 23, Curso = "Química" },
            new Aluno { Nome = "Felipe", Idade = 24, Curso = "Química" },
            new Aluno { Nome = "Sofia", Idade = 25, Curso = "Biologia" },
            new Aluno { Nome = "Clara", Idade = 19, Curso = "Física" },
            new Aluno { Nome = "Ricardo", Idade = 26, Curso = "Química" },
            new Aluno { Nome = "Juliana", Idade = 20, Curso = "Física" },
            new Aluno { Nome = "Pedro", Idade = 21, Curso = "Matemática" },
            new Aluno { Nome = "Beatriz", Idade = 22, Curso = "Matemática" },
            new Aluno { Nome = "Carla", Idade = 24, Curso = "Biologia" },
            new Aluno { Nome = "Daniel", Idade = 25, Curso = "Química" },
            new Aluno { Nome = "Eva", Idade = 21, Curso = "Matemática" },
            new Aluno { Nome = "Marco", Idade = 23, Curso = "Física" }
        };
        
        // Verifica se há algum aluno no curso de Matemática
        bool temAlunoMatematica = alunos.Any(a => a.Curso == "Matemática");

        // Verifica se não há alunos no curso de Literatura
        bool naoTemAlunoLiteratura = !alunos.Any(a => a.Curso == "Literatura");

        //Agrupar Alunos por Curso e Listar Alunos por Curso
        var alunosPorCurso = alunos
            .GroupBy(a => a.Curso)
            .Select(group => new
            {
                Curso = group.Key,
                Alunos = group.OrderBy(a => a.Nome)
            });

        //Contar Alunos por Curso
        var quantidadeAlunosPorCurso = alunos
            .GroupBy(a => a.Curso)
            .Select(group => new
            {
                Curso = group.Key,
                Quantidade = group.Count()
            });

        //Filtrar Alunos por Idade e Ordenar por Nome
        var alunosFiltrados = alunos
            .Where(a => a.Idade >= 21)
            .OrderBy(a => a.Nome)
            .Select(a => new { a.Nome, a.Idade, a.Curso });

        //Encontrar o Aluno Mais Velho em Cada Curso
        var alunoMaisVelhoPorCurso = alunos
            .GroupBy(a => a.Curso)
            .Select(g => new
            {
                Curso = g.Key,
                AlunoMaisVelho = g.OrderByDescending(a => a.Idade).FirstOrDefault()
            });

        //Listar Alunos e Seus Cursos em Ordem Alfabética de Curso
        var alunosOrdenadosPorCurso = alunos
            .OrderBy(a => a.Curso)
            .ThenBy(a => a.Nome)
            .Select(a => new { a.Nome, a.Curso });

        //Agrupar Alunos por Idade e Contar Cada Grupo
        var grupoPorIdade = alunos
            .GroupBy(a => a.Idade)
            .Select(g => new
            {
                Idade = g.Key,
                Quantidade = g.Count(),
                Alunos = g.Select(a => a.Nome)
            });

        //Listar Alunos que Possuem 'a' no Nome e Classificar por Curso e Idade
        var alunosComA = alunos
            .Where(a => a.Nome.ToLower().Contains('a'))
            .OrderBy(a => a.Curso)
            .ThenByDescending(a => a.Idade)
            .Select(a => new { a.Nome, a.Curso, a.Idade });
        #endregion


        #region Exercicio
        List<Livro> biblioteca = new List<Livro>
        {
            new Livro { Titulo = "A História do Amanhã", Autor = "Yuval Noah Harari", NumeroDePaginas = 500, Categoria = "História" },
            new Livro { Titulo = "Sapiens", Autor = "Yuval Noah Harari", NumeroDePaginas = 450, Categoria = "Antropologia" },
            new Livro { Titulo = "1984", Autor = "George Orwell", NumeroDePaginas = 328, Categoria = "Ficção" },
            new Livro { Titulo = "O Sol é Para Todos", Autor = "Harper Lee", NumeroDePaginas = 384, Categoria = "Ficção" },
            new Livro { Titulo = "A Revolução dos Bichos", Autor = "George Orwell", NumeroDePaginas = 112, Categoria = "Ficção" },
            new Livro { Titulo = "Cem Anos de Solidão", Autor = "Gabriel García Márquez", NumeroDePaginas = 417, Categoria = "Ficção" },
            new Livro { Titulo = "Os Miseráveis", Autor = "Victor Hugo", NumeroDePaginas = 1463, Categoria = "Ficção Histórica" },
            new Livro { Titulo = "Crime e Castigo", Autor = "Fyodor Dostoevsky", NumeroDePaginas = 671, Categoria = "Ficção" },
            new Livro { Titulo = "Breves Respostas para Grandes Questões", Autor = "Stephen Hawking", NumeroDePaginas = 256, Categoria = "Ciência" },
            new Livro { Titulo = "Uma Breve História do Tempo", Autor = "Stephen Hawking", NumeroDePaginas = 212, Categoria = "Ciência" },
            new Livro { Titulo = "Os Elementos da Experiência do Usuário", Autor = "Jesse James Garrett", NumeroDePaginas = 208, Categoria = "Design" },
            new Livro { Titulo = "Design de Interação", Autor = "Jenny Preece", NumeroDePaginas = 809, Categoria = "Design" },
            new Livro { Titulo = "O Poder do Hábito", Autor = "Charles Duhigg", NumeroDePaginas = 400, Categoria = "Autoajuda" },
            new Livro { Titulo = "Como Fazer Amigos e Influenciar Pessoas", Autor = "Dale Carnegie", NumeroDePaginas = 288, Categoria = "Autoajuda" },
            new Livro { Titulo = "Subliminar", Autor = "Leonard Mlodinow", NumeroDePaginas = 304, Categoria = "Psicologia" },
            new Livro { Titulo = "Freakonomics", Autor = "Steven D. Levitt", NumeroDePaginas = 336, Categoria = "Economia" },
            new Livro { Titulo = "Outliers", Autor = "Malcolm Gladwell", NumeroDePaginas = 336, Categoria = "Psicologia" },
            new Livro { Titulo = "Don't Make Me Think", Autor = "Steve Krug", NumeroDePaginas = 200, Categoria = "Tecnologia" },
            new Livro { Titulo = "O Andar do Bêbado", Autor = "Leonard Mlodinow", NumeroDePaginas = 272, Categoria = "Ciência" },
            new Livro { Titulo = "O Gene Egoísta", Autor = "Richard Dawkins", NumeroDePaginas = 360, Categoria = "Biologia" },
            new Livro { Titulo = "O Mundo Assombrado pelos Demônios", Autor = "Carl Sagan", NumeroDePaginas = 480, Categoria = "Ciência" }
        };

        //Implementar a listagem de livros por categoria, ordenada por título:
        var livrosPorCategoria = biblioteca
            .GroupBy(l => l.Categoria)
            .Select(group => new
            {
                Categoria = group.Key,
                Livros = group.OrderBy(l => l.Titulo)
            });
        //Filtrar livros com mais de 400 páginas:
        var livrosLongos = biblioteca.Where(l => l.NumeroDePaginas > 400);

        //Contar livros por autor:
        var livrosPorAutor = biblioteca
            .GroupBy(l => l.Autor)
            .Select(group => new
            {
                Autor = group.Key,
                NumeroDeLivros = group.Count()
            });

        //Encontrar livros que contêm "História" no título:
        var livrosComHistoria = biblioteca.Where(l => l.Titulo.Contains("História"));

        //Identificar autores com mais de três livros publicados:
        var autoresProlificos = livrosPorAutor.Where(a => a.NumeroDeLivros > 3);


        #endregion

    }
}